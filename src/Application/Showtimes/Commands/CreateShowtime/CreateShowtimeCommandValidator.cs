using FluentValidation;

namespace CinemaPlatform.Application.Showtimes.Commands.CreateShowtime;

public class CreateShowtimeCommandValidator : AbstractValidator<CreateShowtimeCommand>
{
    public CreateShowtimeCommandValidator()
    {
        RuleFor(v => v.MovieId)
            .NotEmpty().WithMessage("Phải chọn phim cho suất chiếu");

        RuleFor(v => v.AuditoriumId)
            .NotEmpty().WithMessage("Phải chọn phòng chiếu");

        RuleFor(v => v.StartTime)
            .NotEmpty().WithMessage("Giờ bắt đầu không được để trống");

        RuleFor(v => v.BasePrice)
            .GreaterThan(0).WithMessage("Giá vé cơ bản phải lớn hơn 0");
    }
}
