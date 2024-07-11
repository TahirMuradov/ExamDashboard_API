namespace Exam_Dashboard.Api.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
       
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public int Class { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
  
        public List<Exam> Exams { get; set; }
    



    }
}
