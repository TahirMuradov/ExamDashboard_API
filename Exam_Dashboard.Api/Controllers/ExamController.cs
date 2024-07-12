using Exam_Dashboard.Api.DBContext;
using Exam_Dashboard.Api.DTOs.ExamDTOs;
using Exam_Dashboard.Api.FluentValidation.ExamDTOValidator;
using Exam_Dashboard.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_Dashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public ExamController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("[action]")]
        public IActionResult AddExam([FromBody] AddExamDTO addExamDTO)
        {
            var validator = new AddExamDTOValidaton();
            var resultValidator= validator.Validate(addExamDTO);
            if (!resultValidator.IsValid) return BadRequest();
            var CehcekedPupilId = _dbContext.Pupils.FirstOrDefault(x => x.Id == addExamDTO.PupilId);
            if (CehcekedPupilId is null) return NotFound("Pupil is NotFound");
            var checkedLessonId = _dbContext.Lessons.FirstOrDefault(x => x.Id == addExamDTO.LessonId);
            if (checkedLessonId is null) return NotFound("Lesson is NotFound");
          
            Exam exam = new Exam()
            {
                ExamDate = addExamDTO.ExamDate,
             
                LessonCode = checkedLessonId.LessonCode,
            
                LessonId=checkedLessonId.Id,
          
                
            };
            try
            {
                _dbContext.Exams.Add(exam);
                
                ExamPupil examPupil = new ExamPupil()
                {
                    ExamId=exam.Id,
                    PupilId= CehcekedPupilId.Id,
                    PupilCode= CehcekedPupilId.PupilNumber,
                    Grade=addExamDTO.Grade,
                    
                };
                _dbContext.ExamPupils.Add(examPupil);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

            return BadRequest(ex.Message);
                
            }
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteExam(string id)
        {
            if(string.IsNullOrEmpty(id)) return BadRequest();

            var data = _dbContext.Exams.FirstOrDefault(x => x.Id.ToString() == id);
            if (data is null) return NotFound("exam Is NotFound!");
            try
            {
                _dbContext.Exams.Remove(data);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [HttpGet("[action]")]
        public IActionResult GetAllExam()
        {
            var data = _dbContext.Exams
                .Include(x=>x.Lesson)
                .Include(x=>x.ExamPupils)
                .ThenInclude(x=>x.Pupil)
               
                .Select(x=>new GetExamDTO
                {
                    Class=x.Lesson.Class,
                    ExamDate=x.ExamDate,
                    ExamId=x.Id,
                    LessonCode=x.Lesson.LessonCode,
                    LessonName=x.Lesson.LessonName,
                    TeacherFirstName=x.Lesson.TeacherFirstName,
                    TeacherLastName=x.Lesson.TeacherLastName,
                    
                    
                }).ToList();

             //.AsNoTracking()
             //.AsSplitQuery()
             //.AsQueryable();



            return Ok(data);
        }
    }
}
