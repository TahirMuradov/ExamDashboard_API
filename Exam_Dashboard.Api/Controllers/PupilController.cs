using Exam_Dashboard.Api.DBContext;
using Exam_Dashboard.Api.DTOs.PupilDTO;
using Exam_Dashboard.Api.FluentValidation.PupilValidationDTOs;
using Exam_Dashboard.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_Dashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public PupilController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("[action]")]
        public IActionResult AddPupil([FromBody] AddPupilDTO addPupilDTO)
        {

            AddPupilDTOValidatior validation = new AddPupilDTOValidatior();
            var ValidateResult = validation.Validate(addPupilDTO);
            if (!ValidateResult.IsValid) return BadRequest(validation);
            Pupil pupil = new Pupil()
            {
                Class = addPupilDTO.Class,
                FirstName = addPupilDTO.FirstName,
                LastName = addPupilDTO.LastName,
                PupilNumber = addPupilDTO.PupilNumber
            };
            try
            {
                _dbContext.Pupils.Add(pupil);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }



        }

        [HttpGet("[action]")]
        public IActionResult GetAllPupil()
        {
            var pupils = _dbContext.Pupils.AsNoTracking().Include(x => x.ExamPupils).ThenInclude(x => x.Exam).ThenInclude(x => x.Lesson)
                .Select(x => new GETPupilDTO
                {
                    Class = x.Class,
                    PupilNumber = x.PupilNumber,
                    PupilFullName = x.FirstName + " " + x.LastName,
                    PupilId=x.Id,
                    Exams=x.ExamPupils.Select(y=>new GETPupilExamDTO
                    {
                        ExamDate=y.Exam.ExamDate,
                        ExamId=y.ExamId,
                        Grade=y.Grade,
                        LessonCode = y.Exam.Lesson.LessonCode,
                        LessonName=y.Exam.Lesson.LessonName,
                        TeacherFirstName=y.Exam.Lesson.TeacherFirstName,
                        TeacherLastName=y.Exam.Lesson.TeacherLastName
                        
                        
                    }).ToList()


                });

            return Ok(pupils);
        }
        [HttpDelete("[action]")]
        public IActionResult DeletePupil(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var data = _dbContext.Pupils.FirstOrDefault(x => x.Id.ToString() == id);
            if (data == null) return NotFound("Pupils is NotFound!");
            try
            {
                _dbContext.Pupils.Remove(data);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
