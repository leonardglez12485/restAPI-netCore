
namespace TestAPI.DTOs
{
    public class CreatePersonDto
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
         public DateTime BirthDate { get; set; }
   
    }
}