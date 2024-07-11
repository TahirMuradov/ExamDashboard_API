using Exam_Dashboard.Api.DTOs.AuthDTOs;
using FluentValidation;

namespace Exam_Dashboard.Api.FluentValidation.AuthDTOValidtor
{
    public class LoginDTOValidator:AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithName("E-poçt");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithName("Şifrə");
        }
    }
}
