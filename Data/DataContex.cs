
using Microsoft.EntityFrameworkCore;
using TestAPI.Entities;

namespace TestAPI.Data
{
    public class DataContex : DbContext
    {
        public DataContex(DbContextOptions<DataContex> options)
               : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}