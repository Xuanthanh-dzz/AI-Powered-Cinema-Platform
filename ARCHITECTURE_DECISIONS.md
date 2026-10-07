# Architecture Decision Records (ADR)

> File này ghi lại các quyết định kiến trúc quan trọng của dự án **AI-Powered-Cinema-Platform**.
> Mỗi ADR bao gồm: Context (bối cảnh), Options (các lựa chọn), Decision (quyết định), Consequences (hệ quả).
> Nguyên tắc: Không sửa ADR cũ — nếu đổi ý thì viết ADR mới.

---

## ADR-0001: Clean Architecture + CQRS

**Ngày:** 14/06/2026

### Context (Bối cảnh)

Cinema Platform là hệ thống đặt vé xem phim với các yêu cầu:
- Domain nghiệp vụ phức tạp: đặt vé, quản lý suất chiếu, quản lý ghế, thanh toán, đề xuất phim AI
- Cần tích hợp nhiều external services: SQL Server, Kafka, Redis, MinIO, OpenAI API
- Yêu cầu testability cao: unit test cho business logic, integration test cho API
- Dự án phát triển trong 11 tháng, cần dễ maintain và mở rộng

### Options đã cân nhắc

| Option | Mô tả |
|--------|-------|
| **A. Clean Architecture + CQRS** | Tách domain, application, infrastructure rõ ràng. CQRS tách biệt command (ghi) và query (đọc) |
| **B. N-tier truyền thống** | Controller → Service → Repository, 3 lớp |
| **C. Vertical Slices** | Tính năng là đơn vị chính, mỗi slice độc lập |
| **D. DDD thuần (Domain-Driven Design)** | Tập trung vào domain model phong phú, ít quan tâm infrastructure |

### Decision (Quyết định)

**Chọn Option A: Clean Architecture + CQRS**

Lý do:
1. **Domain độc lập**: Domain layer không phụ thuộc framework hay database — dễ test, dễ thay đổi business logic
2. **CQRS phù hợp với đặt vé**: Command (đặt vé, hủy vé) khác xa Query (xem danh sách phim, thống kê doanh thu). Tách riêng tối ưu từng bên
3. **Infrastructure là plugin**: SQL Server, Kafka, Redis, MinIO đều implement interface ở Application layer — dễ swap hoặc thêm mới
4. **Testable**: Application layer chứa use cases, có thể unit test hoàn toàn bằng mock, không cần database thật
5. **Kinh nghiệm thực tế**: Team có kinh nghiệm với Clean Architecture từ các dự án trước

### Consequences (Hệ quả)

**Positive:**
- Business logic tập trung ở Domain + Application, dễ bảo trì
- Dễ thêm tính năng mới mà không ảnh hưởng code cũ
- Có thể test business logic riêng biệt, không phụ thuộc infrastructure

**Negative (Trade-offs):**
- Boilerplate code nhiều hơn: mỗi use case cần 1 Command/Query + Handler + Validator
- Cần kỷ luật giữ đúng boundaries giữa các layer
- Thời gian setup ban đầu lâu hơn so với N-tier

---

## ADR-0002: MediatR cho CQRS

**Ngày:** 14/06/2026

### Context

Cần một thư viện để triển khai CQRS pattern: gửi Command/Query từ Controller đến Handler tương ứng mà không cần dependency trực tiếp.

### Options

| Option | Mô tả |
|--------|-------|
| **A. MediatR** | Thư viện phổ biến nhất cho CQRS trong .NET, implement Mediator pattern |
| **B. Tự implement Mediator** | Tự viết dispatcher, ít dependency hơn |
| **C. Không dùng mediator** | Gọi Handler trực tiếp từ Controller |

### Decision

**Chọn Option A: MediatR**

Lý do:
- Được cộng đồng .NET sử dụng rộng rãi (hơn 100M downloads)
- Tích hợp sẵn pipeline behaviors (validation, logging, performance tracking)
- Giảm coupling: Controller không cần biết Handler nào xử lý request

### Consequences

- Thêm 1 external dependency
- Pipeline behaviors giúp cross-cutting concerns (validation, logging) gọn gàng

---

## ADR-0003: Azure Blob Storage (Azurite) thay MinIO cho lưu trữ file

**Ngày:** 07/10/2026

### Context (Bối cảnh)

Roadmap ban đầu chọn MinIO làm object storage (nơi lưu trữ file) cho môi trường phát triển local, phục vụ upload trailer phim và sinh presigned URL (URL tạm thời có chữ ký, cho phép client tải file trực tiếp mà không đi qua API).

Ngày 11–12/09/2026, MinIO xóa toàn bộ image Docker khỏi Docker Hub. Ngày 24/09/2026, registry riêng của MinIO (quay.io) cũng ngừng cho tải ẩn danh. Đã kiểm chứng trực tiếp trên máy phát triển:

| Image | Kết quả |
|---|---|
| `minio/minio:latest` | ❌ pull access denied |
| `quay.io/minio/minio:latest` | ❌ 401 UNAUTHORIZED |

Đây là hệ quả của việc MinIO rút lui khỏi mã nguồn mở: đổi giấy phép Apache 2.0 → AGPLv3 (2021), bỏ admin console khỏi bản cộng đồng (05/2025), ngừng phát hành binary/Docker (10/2025), tuyên bố chế độ bảo trì (12/2025), lưu trữ kho GitHub (02/2026). Nhiều dự án lớn (Apache Flink, Apache Sedona, Airbyte, Litestream) cũng vỡ CI vì sự kiện này.

### Options đã cân nhắc

| Option | Mô tả |
|--------|-------|
| **A. Azurite (Azure Storage emulator)** | Trình giả lập Azure Blob Storage của Microsoft, image trên mcr.microsoft.com |
| **B. SeaweedFS** | Object storage mã nguồn mở, tương thích API S3, giấy phép Apache-2.0 |
| **C. ghcr.io/netvark/minio** | Image MinIO do cộng đồng dựng lại từ bản sao mã nguồn |
| **D. Hoãn quyết định** | Bỏ object storage khỏi milestone Tháng 6–7, quyết định ở Tháng 11 |

### Decision (Quyết định)

**Chọn Option A: Azurite + Azure Blob SDK**

Lý do:
1. **Nhất quán với mục tiêu deploy**: roadmap triển khai lên Azure (AKS, Key Vault, Managed Identity, Azure Monitor). Dùng Azure Blob SDK ngay từ local nghĩa là code local và code production giống hệt nhau — chỉ đổi connection string, không phải viết lại tầng storage khi deploy
2. **Presigned URL → SAS token**: khái niệm tương đương, chuyển đổi thẳng
3. **Image ổn định**: nằm trên mcr.microsoft.com, cùng registry với SQL Server, do Microsoft bảo trì — không có rủi ro biến mất như MinIO
4. **Option C bị loại vì rủi ro chuỗi cung ứng (supply chain)**: image không do tổ chức chính thức phát hành, không ai bảo đảm vá lỗ hổng bảo mật trong 3 năm tới — không phù hợp với repo portfolio dài hạn
5. **Option B bị loại vì lệch hướng**: SeaweedFS dạy API S3, nhưng đích đến của dự án là Azure, không phải AWS

### Consequences (Hệ quả)

**Positive:**
- Không phải viết lại tầng lưu trữ khi deploy lên Azure
- Học trực tiếp Azure Blob SDK + SAS token — kiến thức dùng được cho AZ-305
- Image do Microsoft bảo trì, không phụ thuộc bên thứ ba

**Negative (Trade-offs):**
- **Không học được API S3** — kỹ năng này không chuyển sang AWS được. Nếu sau này muốn làm với AWS, phải học riêng
- Azurite không hỗ trợ đầy đủ mọi tính năng của Azure Blob thật (lifecycle policy, một số storage tier)
- Không có web console như MinIO — cần Azure Storage Explorer để xem file trực quan
- Key tài khoản của Azurite là key dev công khai, cố định (`devstoreaccount1`), không cấu hình được — chỉ dùng cho local

---

*(Các ADR tiếp theo sẽ được bổ sung theo lộ trình)*