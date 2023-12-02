using LinqToDB.Mapping;

namespace Apteka.Backend.Model
{
    public class Payment
    {
        [Identity]
        public Guid Id { get; set; }
        public decimal AllMoney { get; set; }
        public decimal Salary { get; set; }
        public decimal AnotherExpense { get; set; }
    }
}
