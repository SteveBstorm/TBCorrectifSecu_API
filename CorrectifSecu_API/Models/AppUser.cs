namespace CorrectifSecu_API.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }

        public string Token { get; set; }
    }
}
