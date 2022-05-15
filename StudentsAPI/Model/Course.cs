using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.Model
{
    public class Course
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<CourseStudent> CourseStudents { get; set; }
    }
}
