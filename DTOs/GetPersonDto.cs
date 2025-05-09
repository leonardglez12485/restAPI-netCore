namespace TestAPI.DTOs
{
    public class GetPersonDto: CreatePersonDto
    {
        public int Age => (int)(DateTime.UtcNow - BirthDate).TotalDays / 365;
        public bool IsActive { get; set; }
    }
}