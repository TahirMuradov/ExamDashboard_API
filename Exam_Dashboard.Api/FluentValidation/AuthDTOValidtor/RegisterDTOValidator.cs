using Exam_Dashboard.Api.DTOs.AuthDTOs;
using FluentValidation;

namespace Exam_Dashboard.Api.FluentValidation.AuthDTOValidtor
{
    public class RegisterDTOValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(user => user.Firstname)
           .NotEmpty()
           .MaximumLength(50);

            RuleFor(user => user.Lastname)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(user => user.Username)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(user => user.Password)
                .NotEmpty();
                //.MinimumLength(6);

            RuleFor(user => user.ConfirmPassword)
                .NotEmpty()
                .Equal(user => user.Password);
        }
    }
}
