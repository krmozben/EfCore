using Microsoft.EntityFrameworkCore;

namespace EfCore.CodeFirst.DAL
{
    [Owned]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
