using System.ComponentModel.DataAnnotations;

namespace StudentsAPI.Model
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public List<CourseStudent> CourseStudents { get; set; }
    }
}
