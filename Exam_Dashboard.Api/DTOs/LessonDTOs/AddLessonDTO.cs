namespace Exam_Dashboard.Api.DTOs.LessonDTOs
{
    public class AddLessonDTO
    {
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public int Class { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
    }
}
