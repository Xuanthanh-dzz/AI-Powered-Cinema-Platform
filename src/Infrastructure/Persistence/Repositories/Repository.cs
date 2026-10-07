using CinemaPlatform.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaPlatform.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CinemaDbContext _context;
    private readonly DbSet<T> _set;

    public Repository(CinemaDbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _set.FindAsync([id], cancellationToken);

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        // AsNoTracking: truy vấn chỉ đọc thì không cần EF theo dõi thay đổi,
        // giảm bộ nhớ và tăng tốc — áp dụng cho mọi query trả về danh sách.
        => await _set.AsNoTracking().ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _set.AddAsync(entity, cancellationToken);

    public void Update(T entity) => _set.Update(entity);

    public void Delete(T entity) => _set.Remove(entity);

    // Vì mọi Repository<T> trong cùng 1 request dùng chung 1 CinemaDbContext (scoped),
    // SaveChanges ở đây ghi xuống DB toàn bộ thay đổi đang chờ của cả request —
    // đây là ranh giới transaction cho luồng đặt vé (Booking + Seat cùng 1 lần lưu).
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => _context.SaveChangesAsync(cancellationToken);
}
