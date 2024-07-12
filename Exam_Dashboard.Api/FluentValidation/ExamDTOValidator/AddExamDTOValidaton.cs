using Exam_Dashboard.Api.DTOs.ExamDTOs;
using FluentValidation;

namespace Exam_Dashboard.Api.FluentValidation.ExamDTOValidator
{
    public class AddExamDTOValidaton:AbstractValidator<AddExamDTO>
    {
        public AddExamDTOValidaton()
        {
         

         

            //RuleFor(exam => exam.ExamDate)
            //    .GreaterThan(DateTime.Now);

            RuleFor(exam => exam.Grade)
                .InclusiveBetween(0, 10);

            RuleFor(exam => exam.LessonId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(exam => exam.PupilId)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
