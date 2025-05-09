

namespace TestAPI.DTOs
{
    public class EditPersonDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsActive { get; set; }
    }
}