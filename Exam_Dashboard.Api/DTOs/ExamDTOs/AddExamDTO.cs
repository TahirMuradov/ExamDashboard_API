namespace Exam_Dashboard.Api.DTOs.ExamDTOs
{
    public class AddExamDTO
    {
  
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }
        public Guid LessonId { get; set; }
        public Guid PupilId { get; set; }

    }
}
