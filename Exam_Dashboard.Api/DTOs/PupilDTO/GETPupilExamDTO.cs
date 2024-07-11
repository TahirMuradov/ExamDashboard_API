namespace Exam_Dashboard.Api.DTOs.PupilDTO
{
    public class GETPupilExamDTO
    {
        public Guid ExamId { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }
    }
}
