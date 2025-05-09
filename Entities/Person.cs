using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime BirthDate { get; set; }
        public int Age => (int)(DateTime.UtcNow - BirthDate).TotalDays / 365;
    }
}