namespace Exam_Dashboard.Api.DTOs.LessonDTOs
{
    public class GetLessonDTO
    {
        public Guid Id { get; set; }
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public int Class { get; set; }
        public string TeacherName { get; set; }
        public List<DateTime> ExamsDate { get; set; }
    }
}
