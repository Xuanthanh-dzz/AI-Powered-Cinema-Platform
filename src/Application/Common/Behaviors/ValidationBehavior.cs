using FluentValidation;
using MediatR;

namespace CinemaPlatform.Application.Common.Behaviors;

/// <summary>
/// Chạy TẤT CẢ validator của một Command/Query trước khi Handler được gọi.
/// Nhờ vậy Handler không cần tự kiểm tra dữ liệu đầu vào, chỉ tập trung nghiệp vụ.
/// </summary>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // Không có validator nào cho request này thì đi tiếp luôn, không tốn chi phí.
        if (!_validators.Any())
        {
            return await next(cancellationToken);
        }

        var context = new ValidationContext<TRequest>(request);
        var results = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = results
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count != 0)
        {
            // Ném ValidationException để tầng Api bắt và trả về HTTP 400 kèm chi tiết lỗi.
            throw new ValidationException(failures);
        }

        return await next(cancellationToken);
    }
}
