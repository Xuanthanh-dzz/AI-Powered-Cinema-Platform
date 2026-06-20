using FluentValidation;

namespace cinemaPlatform.Application.Movies.Commands.CreateMovie;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Tên phim không được để trống")
            .MaximumLength(200).WithMessage("Tên phim tối đa 200 ký tự");

        RuleFor(v => v.Genre)
            .NotEmpty().WithMessage("Thể loại không được để trống")
            .MaximumLength(100).WithMessage("Thể loại tối đa 100 ký tự");

        RuleFor(v => v.DurationInMinutes)
            .GreaterThan(0).WithMessage("Thời lượng phải lớn hơn 0");

        RuleFor(v => v.ReleaseDate)
            .NotEmpty().WithMessage("Ngày phát hành không được để trống");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Mô tả không được để trống")
            .MaximumLength(2000).WithMessage("Mô tả tối đa 2000 ký tự");
    }
}
