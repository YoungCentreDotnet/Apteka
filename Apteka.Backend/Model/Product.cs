using LinqToDB.Mapping;

namespace Apteka.Backend.Model
{
    public class Product
    {
        [Identity]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Discraption { get; set; }
        public decimal Price { get; set; }
    }
}
