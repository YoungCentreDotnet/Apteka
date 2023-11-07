using LinqToDB.Mapping;

namespace Apteka.Backend.Model
{
    public class Employee
    {
        public int id { get; set; }
        public string FistName { get; set; }
        public string Lastname { get; set; }
        public DateTimeOffset DataOfBrith { get; set; }
        public ICollection<Payment> Payments  { get; set;}
        public ICollection<Product> Products { get; set;}

    }
}