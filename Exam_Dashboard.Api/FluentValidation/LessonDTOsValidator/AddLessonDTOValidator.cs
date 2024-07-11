using Exam_Dashboard.Api.DTOs.LessonDTOs;
using FluentValidation;

namespace Exam_Dashboard.Api.FluentValidation.LessonDTOsValidator
{
    public class AddLessonDTOValidator:AbstractValidator<AddLessonDTO>
    {
        public AddLessonDTOValidator()
        {
            RuleFor(lesson => lesson.LessonCode)
                .NotEmpty()
                .MaximumLength(3);

            RuleFor(lesson => lesson.LessonName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(lesson => lesson.Class)
                .InclusiveBetween(1, 12);

            RuleFor(lesson => lesson.TeacherFirstName)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(lesson => lesson.TeacherLastName)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
