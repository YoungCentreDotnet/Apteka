using LinqToDB.Mapping;

namespace Apteka.Backend.Model
{
    public class Employe
    {
        [Identity]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTimeOffset DataOfBrith { get; set; }
       
    }
}
