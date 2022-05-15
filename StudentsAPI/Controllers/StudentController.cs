using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsAPI.DTO;
using StudentsAPI.Model;

namespace StudentsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly Context context;

        public StudentController(ILogger<StudentController> logger, Context context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet(Name = "Students")]
        public IEnumerable<StudentsDTO> Get()
        {
            using (context)
            {
                DataBaseInitializer.InitializeIfEmpty(context, 50);

                return context.Students.Include(s => s.EnrolledCourses)
                                       .ThenInclude(c => c.Course)                                       
                                       .Select(s => new StudentsDTO
                                                     {
                                                         Id = s.Id,
                                                         Name = s.Name,
                                                         Courses = s.EnrolledCourses.Select(c => new CourseDTO()
                                                         { 
                                                            Id = c.CourseId,
                                                            Name = c.Course.Name
                                                         }).ToList(),
                                                     })
                                       .ToList();
            }
        }
    }
}