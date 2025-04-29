using FluentValidation;

namespace BookStore.Application.DTO.Vlidators;

public class BookRequestDtoValidator : AbstractValidator<BookRequestDto>
{
    public BookRequestDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Название книги должно быть не пустым");

        RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage("Автор обязателен")
            .MaximumLength(50)
            .WithMessage("Имя автора не должно превышать 50 символов");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Цена должна быть больше 0");

        RuleFor(x => x.PagesCount)
            .GreaterThan(0)
            .WithMessage("Количество страниц должно быть больше 0");
    }
}