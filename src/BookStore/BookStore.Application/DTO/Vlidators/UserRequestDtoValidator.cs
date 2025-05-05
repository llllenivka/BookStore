using FluentValidation;

namespace BookStore.Application.DTO.Vlidators;

public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
{
    public UserRequestDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty();
    
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
    
        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Роль обязательна к заполнению")
            .Must(role => role is "Admin" or "User")
            .WithMessage("Роль должна быть либо 'Admin', либо 'User'.");
    }

}