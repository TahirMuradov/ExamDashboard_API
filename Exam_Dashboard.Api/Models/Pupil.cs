namespace Exam_Dashboard.Api.Models
{
    public class Pupil
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PupilNumber { get; set; }
        public int Class { get; set; }
        public List<ExamPupil>? ExamPupils { get; set; }

    }
}
