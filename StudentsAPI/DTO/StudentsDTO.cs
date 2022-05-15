namespace StudentsAPI.DTO
{
    public class StudentsDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }    

        public List<CourseDTO> Courses { get; set; }
    }
}
