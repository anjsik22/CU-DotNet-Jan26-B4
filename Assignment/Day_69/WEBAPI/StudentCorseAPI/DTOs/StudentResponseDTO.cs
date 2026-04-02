namespace StudentCorseAPI.DTOs
{
    public class StudentResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public List<CourseDTO> Courses { get; set; }
    }
}
