# AGENTS.md — AI-Powered-Cinema-Platform

> Hướng dẫn chung cho **mọi công cụ AI** làm việc trong repo này (Claude Code, Cline, Cursor, GitHub Copilot, Codex, Windsurf, Aider, Gemini CLI...).
>
> Đây là file cấu hình **duy nhất** của dự án. Không tạo file riêng cho từng công cụ (`.clinerules`, `.cursorrules`, `.github/copilot-instructions.md`...). Sửa quy tắc thì sửa tại đây — mọi AI đều phải đọc và tuân theo file này.
>
> Chuẩn: [AGENTS.md](https://agents.md) — do Agentic AI Foundation (Linux Foundation) quản lý, không thuộc về hãng nào.

---

## Bối cảnh dự án

Nền tảng đặt vé xem phim. Đây là dự án portfolio phục vụ mục tiêu apply remote ra nước ngoài, nên **chất lượng code và lịch sử git đều được người khác đọc và đánh giá**.

| Hạng mục | Chi tiết |
|---|---|
| Stack | .NET 10, C# 14, Clean Architecture + CQRS (MediatR) |
| Dữ liệu | SQL Server 2022 (EF Core) |
| Lưu trữ file | Azure Blob Storage — local dùng Azurite |
| Hạ tầng local | Docker Desktop + WSL2 — `docker compose up -d` |
| Kiến trúc | Mọi quyết định ghi ở `ARCHITECTURE_DECISIONS.md` (ADR) |
| Lộ trình | `docs/ROADMAP.md` |

**Nguyên tắc ADR:** không sửa ADR cũ. Đổi ý thì viết ADR mới ghi đè quyết định cũ.

---

## Luật 1 — Ngôn ngữ

Luôn trả lời bằng tiếng Việt.

## Luật 2 — Giải thích thuật ngữ chuyên ngành

Gặp thuật ngữ chuyên ngành tiếng Anh thì giải thích ngắn gọn trong ngoặc đơn ngay sau.

Ví dụ: CQRS (kiến trúc tách biệt lệnh đọc và ghi dữ liệu).

## Luật 3 — Viết code trực tiếp, kèm giải thích

Viết code trực tiếp, không cần chờ từ khóa `/code`. Luôn giải thích ngắn gọn logic và lý do đằng sau đoạn code vừa viết — mục tiêu là hiểu để trả lời phỏng vấn, không phải nhận code chạy được.

## Luật 4 — Giải thích kiến trúc và quyết định kỹ thuật

Khi trả lời về kiến trúc hoặc quyết định kỹ thuật, nêu rõ lý do, trade-off (sự đánh đổi) và ưu/nhược điểm.

## Luật 5 — Làm rõ câu hỏi mơ hồ

Câu hỏi quá rộng hoặc mơ hồ thì hỏi lại để làm rõ, không tự suy đoán.

## Luật 6 — Tập trung một vấn đề

Mỗi câu trả lời chỉ tập trung vào một vấn đề, không lan man.

## Luật 7 — Hướng dẫn từng bước nhỏ

Chia việc thành bước nhỏ, hỏi user đã hoàn thành chưa trước khi đi tiếp.

## Luật 8 — Ưu tiên stack của dự án

Có nhiều cách giải quyết thì ưu tiên cách phù hợp nhất với .NET, C#, SQL Server và giải thích ngắn tại sao.
