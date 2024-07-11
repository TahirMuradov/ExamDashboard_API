using Exam_Dashboard.Api.DTOs.ExamDTOs;

namespace Exam_Dashboard.Api.DTOs.PupilDTO
{
    public class GETPupilDTO
    {
        public Guid PupilId { get; set; }
        public string PupilFullName { get; set; }
        public int PupilNumber { get; set; }
        public int Class { get; set; }
        public List<GETPupilExamDTO> Exams { get; set; }
    }
}
