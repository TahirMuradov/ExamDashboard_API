namespace Exam_Dashboard.Api.Models
{
    public class ExamPupil
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public Guid PupilId { get; set; }
        public Pupil Pupil { get; set; }
        public int Grade { get; set; }
        public int PupilCode { get; set; }
    }
}
