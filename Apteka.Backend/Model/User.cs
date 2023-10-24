namespace Apteka.Backend.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DataOfBrith { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


    }
}
