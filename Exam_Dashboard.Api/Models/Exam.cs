namespace Exam_Dashboard.Api.Models
{
    public class Exam
    {
        public Guid Id { get; set; }
        public string LessonCode { get; set; }
    
        public DateTime ExamDate { get; set; }
    
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public List <ExamPupil> ExamPupils { get; set; }


    }
}
