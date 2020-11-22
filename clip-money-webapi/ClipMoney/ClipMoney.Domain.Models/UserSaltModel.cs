
namespace ClipMoney.Domain.Models
{
    public class UserSaltModel
    {
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
    }
}
