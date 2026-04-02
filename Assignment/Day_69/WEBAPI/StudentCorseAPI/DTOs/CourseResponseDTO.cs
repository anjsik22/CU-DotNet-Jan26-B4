namespace StudentCorseAPI.DTOs
{
    public class CourseResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public List<StudentDTO> Students { get; set; }
    }
}
