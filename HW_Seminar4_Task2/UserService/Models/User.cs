namespace UserService.Models
{
    public class User
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Registred { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
    }
}
