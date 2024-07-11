using Exam_Dashboard.Api.DTOs.PupilDTO;
using FluentValidation;

namespace Exam_Dashboard.Api.FluentValidation.PupilValidationDTOs
{
    public class AddPupilDTOValidatior:AbstractValidator<AddPupilDTO>
    {
        public AddPupilDTOValidatior()
        {
            RuleFor(student => student.FirstName)
           .NotEmpty()
           .MaximumLength(30);

            RuleFor(student => student.LastName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(student => student.PupilNumber)
                .InclusiveBetween(1, 99999);

            RuleFor(student => student.Class)
                .InclusiveBetween(1, 12);
        }
    }
}
