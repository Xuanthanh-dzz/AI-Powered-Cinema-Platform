# KẾ HOẠCH PHÁT TRIỂN SỰ NGHIỆP — PHIÊN BẢN 3.2 FINAL

> Tổng hợp từ: Kế hoạch gốc + Grok + DeepSeek + Claude + Gemini  
> Cập nhật: 05/2026  
> Mục tiêu: Remote / Công ty nước ngoài — $2,500–$4,000 USD/tháng (tối đa $4,500 nếu pass Toptal)  
> Lộ trình: Vietnam Top Product Company → Personal Brand → Foreign Ready

---

## TỔNG QUAN 4 GIAI ĐOẠN

| GIAI ĐOẠN | THỜI GIAN | MỤC TIÊU CHÍNH |
|---|---|---|
| 0 — Chuẩn bị | Ngay – 23/05/2026 | Thu thập dữ liệu cũ, setup môi trường, Case Study |
| 1 — Build & Learn | 24/05/2026 – 30/04/2027 | Cinema Platform MVP + Nền tảng kỹ năng toàn diện |
| 2 — Vietnam Company | 05/2027 – 12/2028 | Kinh nghiệm thực tế, Personal Brand, IELTS, AZ-305 |
| 3 — Foreign Ready | 01/2029 – 08/2029 | Refine profile, mock interview EN, apply remote |

---

## GIAI ĐOẠN 0 — CHUẨN BỊ KHẨN CẤP (Ngay – 23/05/2026)

Cường độ: 3–4h/ngày  
Nguyên tắc: Những việc này KHÔNG làm lại được sau khi nghỉ việc

### Việc 1 — Thu thập số liệu 3 dự án cũ

| DỰ ÁN | CẦN GHI LẠI |
|---|---|
| Yamaha Bizzone | Số user, số module, volume data, vấn đề performance đã gặp, kết quả đo được |
| HRM | Số nhân viên quản lý, tính năng phức tạp nhất, tech stack chi tiết |
| Quản lý cư dân | Quy mô dữ liệu, tính năng đặc thù, vấn đề bạn tự giải quyết |

### Việc 2 — Viết 3 câu chuyện STAR

Mỗi dự án 1 câu chuyện. Bắt buộc có số liệu cụ thể và vai trò cá nhân rõ ràng.

- S (Situation): Bối cảnh, vấn đề xảy ra
- T (Task): Nhiệm vụ cụ thể của bạn
- A (Action): Bạn đã làm gì, quyết định kỹ thuật thế nào
- R (Result): Kết quả đo được — thời gian, hiệu suất, số liệu

✓ Ví dụ TỐT: "Query báo cáo chạy 8 giây, tôi phân tích execution plan, thêm composite index và rewrite subquery → còn 0.4 giây, giảm 95%"  
✗ Ví dụ TỆ: "Tôi làm module quản lý nhân viên"

### Việc 3 ★ — Reverse Engineering Case Study

Viết nháp (không công khai) về 2–3 lỗi nặng nhất từng gặp tại công ty.

- Lỗi: [Triệu chứng]
- Nguyên nhân kỹ thuật dự đoán: [N+1 query / thiếu index / sync code blocking]
- Cách fix: [query optimization / Redis cache / async refactor]
- Kết quả kỳ vọng: [giảm X%, từ Xs xuống Ys]

### Việc 4 — Technical Setup

- Docker + WSL2, tối ưu .wslconfig (memory=10GB, processors=4)
- Tạo GitHub repo cinema-platform, skeleton .NET 10 Clean Architecture
- Tạo Obsidian/Notion: tracker tiến độ + nhật ký kỹ thuật
- Đọc 1 lần ByteByteGo System Design primer (free trên GitHub)
- Tạo file ARCHITECTURE_DECISIONS.md trong repo

### Checklist Giai đoạn 0

- [ ] Đã ghi số liệu 3 dự án
- [ ] Đã viết nháp 3 câu chuyện STAR
- [ ] Đã viết Reverse Engineering Case Study (2–3 lỗi cũ)
- [ ] GitHub repo đã tạo, skeleton .NET 10 đã chạy
- [ ] Docker + docker-compose chạy được SQL Server + MinIO
- [ ] Đã đọc xong ByteByteGo primer

---

## GIAI ĐOẠN 1 — BUILD & LEARN (24/05/2026 – 30/04/2027)

Thời gian: 11 tháng  
Cường độ: 7–8h/ngày chất lượng cao  
Nguyên tắc: Code + lý thuyết song song mỗi ngày, không tách riêng

### Lịch ngày điển hình — Pomodoro Style

| GIỜ | HOẠT ĐỘNG | THỜI LƯỢNG |
|---|---|---|
| 06:00 – 06:30 | Vệ sinh cá nhân, vận động nhẹ | Khởi động |
| 07:00 – 08:00 | Pomodoro 1 — Code / task khó nhất | Não minh mẫn nhất |
| 08:15 – 09:15 | Pomodoro 2 — Code tiếp | Tiếp tục task |
| 09:30 – 10:30 | Pomodoro 3 — System Design / .NET Internals | Đổi mode |
| 10:45 – 11:45 | Pomodoro 4 — Code hoặc bài tập nhỏ | Áp dụng lý thuyết |
| 11:45 – 13:30 | Nghỉ trưa (ăn + ngủ 20–30 phút) | Bắt buộc |
| 13:30 – 14:30 | Pomodoro 5 — System Design / tài liệu | — |
| 14:45 – 15:45 | Pomodoro 6 — .NET Internals / Leetcode | — |
| 17:00 – 18:00 | Pomodoro 7 — Code tiếp / review ngày | Session cuối |
| 20:00 – 21:00 | Tiếng Anh (đọc nhẹ, nghe podcast) | Nhẹ nhàng |
| 21:00 – 22:00 | Nhật ký + lên kế hoạch ngày mai | 15p viết + 15p plan |

Tổng: ~7 Pomodoro × 1h = 7h + 1h Tiếng Anh = ~8h/ngày

---

## CINEMA PLATFORM — MVP & Chi tiết từng tháng

**MVP:** Đặt vé realtime (SignalR) + Kafka + AI/RAG (pgvector) + Deploy AKS + Observability đầy đủ

### Tháng 6–7/2026 — Nền tảng

- Clean Architecture + CQRS + MediatR
- Core domain: Booking, Seat, Showtime, Movie
- Unit Test (Application) + Integration Test (API)
- Keycloak: auth + phân quyền admin
- MinIO: upload trailer + presigned URL
- Thi AZ-900 cuối tháng 7
- Viết ADR đầu tiên: tại sao Clean Architecture + CQRS

### Tháng 8/2026 — Realtime & Observability

- SignalR: dashboard realtime số vé, doanh thu theo giờ
- Health check, readiness/liveness probe (cho K8s)
- OpenTelemetry → Azure Monitor
- Serilog + Structured Logging → ELK Stack hoặc Seq
- Load test k6: đo baseline (RPS, P99 latency)
- BenchmarkDotNet: benchmark 2–3 chỗ quan trọng

### Tháng 9/2026 — Event-Driven & Resilience ★

- Kafka: publish BookingCreated, consumer lưu BookingAnalytics
- Saga Pattern: booking flow với compensating transaction
- Dead letter queue cho failed events
- Circuit Breaker với Polly cho mọi external API call
- Idempotency API: đặt vé/thanh toán 2 lần chỉ xử lý 1 lần
- Distributed Locking (Redis): giải quyết 1000 người đặt 1 ghế cuối cùng
- Viết ADR: tại sao Kafka thay RabbitMQ

### Tháng 10/2026 — AI Core ★ (TRỌNG TÂM)

- Semantic Kernel (Microsoft): orchestrate AI
- RAG pipeline: AI Chatbot dựa trên dữ liệu phim trong DB
- pgvector: embedding phim, gợi ý phim tương tự
- Hybrid Search: Full-text + Vector Search
- OpenAI API: dự báo doanh thu 7 ngày + phân tích hành vi
- AI Rate Limiting Middleware
- Fallback (Polly): OpenAI down → thuật toán gợi ý cơ bản
- Viết ADR: RAG vs fine-tuning, tại sao chọn RAG

### Tháng 11/2026 — Container & CI/CD

- Dockerfile multi-stage, docker-compose toàn stack
- Azure Container Registry + GitHub Actions (build → test → push → deploy)
- Deploy AKS, Key Vault + Managed Identity
- Viết blog bài 1 (tiếng Anh): Kiến trúc tổng thể Cinema Platform

### Tháng 12/2026 – 04/2027 — Hoàn thiện & Ôn phỏng vấn

- Performance optimization dựa trên k6 report (before/after)
- README hoàn chỉnh tiếng Anh + video demo 5–7 phút
- CV + LinkedIn polish
- Mock system design 3 lần/tuần (record + tự nghe lại)
- Hoàn thiện STAR stories + Case Study

---

## SYSTEM DESIGN — Song song từ Tháng 6

| THÁNG | TÀI LIỆU | MỤC TIÊU |
|---|---|---|
| T6–8 | ByteByteGo Vol.1 → Grokking | Nắm framework, 5 hệ thống đầu |
| T9–11 | Designing Data-Intensive Applications ch.1–9 | CAP, replication, partitioning |
| T12–4/2027 | Mock tự luyện 3 buổi/tuần | Record + tự nghe lại + cải thiện |

### 10 hệ thống phải nhuần nhuyễn

1. URL Shortener — caching, hashing, redirect
2. Cinema Booking System — concurrency, seat locking
3. News Feed / Timeline — fanout, pagination
4. Chat System realtime — WebSocket, message ordering
5. Rate Limiter — token bucket, sliding window
6. Notification System — push/pull, fan-out
7. Typeahead Search — trie, caching
8. Video Streaming Platform — chunked upload, CDN
9. Distributed Cache — consistent hashing, eviction
10. Web Crawler — BFS, politeness, deduplication

### 3 bài toán 'đinh' phải giải được thực tế ★

1. **Distributed Locking:** 1000 người đặt 1 ghế cuối trong 1ms → Redis SETNX, Redlock algorithm
2. **Idempotency:** User nhấn thanh toán 2 lần do lag → Idempotency key trong header
3. **Saga Consistency:** Trừ ghế → trừ tiền → gửi email, trừ tiền fail thì hoàn ghế thế nào?

### Framework 4 bước trả lời mọi bài design

- **Bước 1 — Clarify (2–3 phút):** Scale (DAU, QPS, storage), Functional + Non-functional requirements
- **Bước 2 — High-level (5–10 phút):** Diagram tổng quan, identify bottleneck chính
- **Bước 3 — Deep dive (15–20 phút):** Focus 1–2 component khó, trade-offs cụ thể
- **Bước 4 — Wrap up (2–3 phút):** Tóm tắt + nêu cải tiến nếu có thêm thời gian

---

## .NET INTERNALS — 1h/ngày song song từ Tháng 6

| CHỦ ĐỀ | THÁNG | NỘI DUNG CHÍNH |
|---|---|---|
| Async/Await sâu | T6–7 | State machine, ConfigureAwait, Deadlock 3 cách, ValueTask vs Task |
| GC & Memory | T7–8 | Gen 0/1/2, LOH, IDisposable, memory leak phổ biến |
| ★ Diagnostics Tools | T8–9 | dotnet-counters, dotnet-dump, dotnet-trace, BenchmarkDotNet |
| Dependency Injection | T9 | Singleton/Scoped/Transient, Captive dependency, tự implement DI |
| EF Core sâu | T10 | N+1 query, AsNoTracking, Compiled Queries, migration production |
| ASP.NET Core Pipeline | T11 | Middleware order, Minimal API vs Controller, IHostedService |

> ★ Bài tập Diagnostics: cố tình tạo memory leak trong Cinema Platform → dùng dotnet-dump để tìm và fix.

---

## CHỨNG CHỈ

| CHỨNG CHỈ | THỜI ĐIỂM | GHI CHÚ |
|---|---|---|
| AZ-900 (Azure Fundamentals) | Cuối tháng 7/2026 | Ôn 3–4 tuần song song với code |
| AI-200 | Theo kế hoạch gốc | Theo lộ trình đã có |
| AZ-305 (Solutions Architect Expert) | Q1–Q3/2028 | Sau khi có kinh nghiệm Azure thực tế |

---

## LEETCODE — 3–4 buổi/tuần, 1h/buổi

Mục tiêu: 80–90 bài Medium. Rule: Stuck >30 phút → xem gợi ý → hiểu → tự viết lại không nhìn.

| THÁNG | CHỦ ĐỀ | SỐ BÀI |
|---|---|---|
| T6 | Array, String, HashMap | 15 bài |
| T7 | Two Pointers, Sliding Window | 15 bài |
| T8 | Stack, Queue, LinkedList | 12 bài |
| T9 | Binary Search, Tree traversal | 15 bài |
| T10 | Graph, BFS/DFS | 15 bài |
| T11–T4 | Dynamic Programming cơ bản + ôn tổng hợp | 18 bài |

---

## TIẾNG ANH — Giai đoạn 1 (thực dụng, KHÔNG IELTS)

Mục tiêu: Đọc docs không cần dịch, viết README tự nhiên, nghe podcast hiểu ~70%

### Hàng ngày (1h):
- 20 phút đọc: Microsoft Blog, andrewlock.net, dev.to
- 20 phút nghe: ByteByteGo YouTube + Exponent YouTube
- 20 phút Daily Tech Journaling — viết 3–5 câu tiếng Anh về những gì làm hôm nay

### Hàng tuần:
- Viết README của 1 tính năng mới hoàn toàn bằng tiếng Anh
- Nghe 1 video giải System Design (Exponent/ByteByteGo)

---

## PERSONAL BRAND — Bắt đầu từ Tháng 11/2026

| BÀI | THỜI ĐIỂM | CHỦ ĐỀ |
|---|---|---|
| 1 | T11/2026 | Kiến trúc tổng thể Cinema Platform |
| 2 | T1/2027 | RAG pipeline thực tế |
| 3 | T3/2027 | Distributed Locking — 1000 người 1 ghế |
| 4 | T6/2027 | Bài học sau 6 tháng dùng Clean Architecture |
| 5 | T9/2027 | System Design: từ lý thuyết đến production |
| 6+ | 2028 | Từ kinh nghiệm thực tế tại công ty mới |

Đăng: dev.to + Viblo (tiếng Anh)

---

## QUẢN LÝ RỦI RO

| RỦI RO | DẤU HIỆU | CÁCH XỬ LÝ |
|---|---|---|
| Burnout | Làm <5h/ngày, mất hứng >3 ngày | Giảm còn 5–6h hoặc nghỉ 2–3 ngày không guilt |
| Scope creep | Thêm tính năng ngoài MVP | Hard stop — ghi vào backlog, không làm ngay |
| Cert overload | AZ-900 chiếm >2h/ngày | Chỉ 1 cert trong giai đoạn 1 |
| Stuck kỹ thuật | >2h không ra | Hỏi ngay: Reddit (.NET), Discord, AI assistant |
| Tiếng Anh bị quên | Không mở docs EN >3 ngày | Đưa vào lịch cố định, không optional |

---

## GIAI ĐOẠN 2 — VIETNAM PRODUCT COMPANY (05/2027 – 12/2028)

### Thứ tự ưu tiên công ty:

**Ưu tiên 1 — Product Company:** Base.vn, Got It, Sky Mavis, VNG, Timo, Jio Health, Abivin, KiotViet, MISA tech  
**Ưu tiên 2 — Outsourcing tier-2 (backup):** KMS, NashTech, FPT Software squad chất lượng cao

### CV checklist khi apply:
- 1 trang, tiếng Anh
- Cinema Platform: link GitHub (README đẹp + video demo) + tech stack highlight
- AZ-900 + AI-200
- GitHub: commit đều 11 tháng, CI badge, coverage badge

**Mức lương expect:** 25–35 triệu

---

## GIAI ĐOẠN 3 — FOREIGN READY & APPLY (01/2029 – 08/2029)

### Checklist profile trước khi apply

| HẠNG MỤC | CHECKLIST |
|---|---|
| Kinh nghiệm | 4+ năm .NET · Cinema Platform maintain tốt · 1 merged PR open source |
| Chứng chỉ | AZ-900 ✓ · AI-200 ✓ · AZ-305 ✓ |
| Tiếng Anh | IELTS 6.5–7.0 · Mock interview 10+ buổi |
| CV & Portfolio | 1 trang ATS-friendly · Bullet points có số liệu · 4–6 bài blog EN |
| Personal Brand | Video demo Cinema · LinkedIn 500+ connections · 1 repo GitHub 50+ stars |

### Kênh apply & Mức lương

| KÊNH | PHÙ HỢP CHO |
|---|---|
| arc.dev | Remote dev, vetting kỹ, rate cao |
| Wellfound | Startup Series A–B |
| LinkedIn filter Remote + .NET | Broad search |
| Toptal | Khó nhất, lương cao nhất ($40–80/h) |
| Remotive, RemoteOK, Otta | Job board tổng hợp |

| PROFILE | MỨC LƯƠNG REALISTIC |
|---|---|
| Không có personal brand, chứng chỉ cơ bản | $1,800 – $2,500/tháng |
| Có blog + AZ-305 + open source PR ← TARGET | $2,500 – $4,000/tháng |
| Pass Toptal | $4,000 – $7,000/tháng |

---

## MILESTONE TỔNG QUAN

| THỜI ĐIỂM | CHECKPOINT | NẾU KHÔNG ĐẠT |
|---|---|---|
| 23/05/2026 | STAR + Case Study + Repo ready | Gia hạn 1 tuần |
| 31/07/2026 | AZ-900 passed + T6–7 Cinema xong | Review scope, cắt tính năng |
| 30/09/2026 | Kafka + Distributed Lock + Idempotency xong | OK nếu chậm 1–2 tuần |
| 30/11/2026 | AI Core xong + Blog bài 1 published | Delay apply sang T4/2027 |
| 30/04/2027 | Cinema MVP hoàn chỉnh + 80 Leetcode Medium | Ưu tiên MVP, bỏ tính năng phụ |
| 06/2027 | Đang làm tại product company | Mở rộng sang outsourcing tier-2 |
| 10/2028 | IELTS 6.5–7.0 + AZ-305 passed | Delay Phase 3 thêm 3 tháng |
| 08/2029 | Có offer remote hoặc đang final round | — |

---

## NHẬT KÝ HÀNG NGÀY (Template)

```
# Ngày DD/MM/YYYY

## Code hôm nay
- Hoàn thành: ...
- Khó khăn: ...
- Giải quyết: ...

## Lý thuyết hôm nay (.NET / System Design / Leetcode)
- Chủ đề: ...
- 3 điểm quan trọng: 1. ... 2. ... 3. ...

## Tiếng Anh hôm nay (viết bằng tiếng Anh)
Today I learned / built / solved: ...
The main challenge was: ...
Tomorrow I will: ...

## Tiến độ tổng thể
- Cinema Platform: __% | Leetcode: __/90 | System Design: ch__/__ | Blog: __/6

## Tự đánh giá (1–10): Hiểu bài: /10 · Tập trung: /10 · Energy: /10
```

---

## 7 YẾU TỐ QUYẾT ĐỊNH THÀNH BẠI

| # | YẾU TỐ | TẠI SAO QUAN TRỌNG |
|---|---|---|
| 1 | Nhịp độ bền vững (7–8h chất lượng) | 12h/ngày rồi burnout sau 2 tháng tệ hơn 7h/ngày đều 11 tháng |
| 2 | System Design từ ngày đầu | Đây là vòng rớt nhiều nhất ở product company |
| 3 | Hiểu sâu Cinema Platform | Phải defend được mọi quyết định kỹ thuật |
| 4 | Target Product Company trước | Kinh nghiệm product có giá trị hơn outsourcing khi apply nước ngoài |
| 5 | Personal Brand sớm và đều | 6 bài blog từ 2026–2028 sẽ có traffic thật khi apply 2029 |
| 6 | Reverse Engineering Case Study | Tư liệu phỏng vấn không ai copy được |
| 7 | Sức khỏe & nghỉ ngơi hợp lý | Đầu tư dài hạn cho 3 năm marathon |

---

*Phiên bản 3.2 Final · Tổng hợp: Kế hoạch gốc + Grok + DeepSeek + Claude + Gemini · 05/2026*
