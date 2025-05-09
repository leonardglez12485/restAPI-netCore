using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.DTOs
{
    public class CreatePersonDto
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
         public DateTime BirthDate { get; set; }
   
    }
}