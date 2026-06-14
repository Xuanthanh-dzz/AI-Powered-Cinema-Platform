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

*(Các ADR tiếp theo sẽ được bổ sung theo lộ trình)*