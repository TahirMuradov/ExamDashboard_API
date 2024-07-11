using Exam_Dashboard.Api.DBContext;
using Exam_Dashboard.Api.DTOs.LessonDTOs;
using Exam_Dashboard.Api.FluentValidation.LessonDTOsValidator;
using Exam_Dashboard.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exam_Dashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly AppDBContext _dbContext;

        public LessonController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("[action]")]
        public IActionResult GetAllLesson()
        {
            var data =_dbContext.Lessons.AsNoTracking().AsSplitQuery().AsQueryable();
            return Ok(data);
        }
        [HttpPost("[action]")]
        public IActionResult AddLesson([FromBody] AddLessonDTO addLessonDTO)
        {
            var validator = new AddLessonDTOValidator();
            var ValidatorResult= validator.Validate(addLessonDTO);
            if (!ValidatorResult.IsValid) return BadRequest(ValidatorResult.Errors);
            Lesson lesson = new Lesson()
            {
                Class = addLessonDTO.Class,
                LessonCode=addLessonDTO.LessonCode,
                LessonName=addLessonDTO.LessonName,
                TeacherFirstName=addLessonDTO.TeacherFirstName,
                TeacherLastName = addLessonDTO.TeacherLastName,
                
            };
            try
            {
                _dbContext.Lessons.Add(lesson);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
       
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteLesson(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            var data = _dbContext.Lessons.FirstOrDefault(x => x.Id.ToString() == id);
            if (data == null) return NotFound();
            try
            {
                _dbContext.Lessons.Remove(data);
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
