

namespace TestAPI.DTOs
{
    public class EditPersonDto : CreatePersonDto
    {
       public bool IsActive { get; set; }
    }
}