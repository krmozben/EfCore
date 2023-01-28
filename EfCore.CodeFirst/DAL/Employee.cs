namespace EfCore.CodeFirst.DAL
{
    public class Employee
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public Person Person { get; set; }

    }
}
