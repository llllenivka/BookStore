using FluentValidation;

namespace BookStore.Application.DTO.Vlidators;

public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
{
    public UserRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Имя должно быть не пустым");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Почта обязательна к заполнению")
            .EmailAddress()
            .WithMessage("Не подходит к формату почты");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Не заполнено поле пароля")
            .MinimumLength(8)
            .WithMessage("Пароль должен быть больше 8 символов");
    }
    // public string Name { get; set; }
    // public string Email { get; set; }
    // public string Password { get; set; }
}