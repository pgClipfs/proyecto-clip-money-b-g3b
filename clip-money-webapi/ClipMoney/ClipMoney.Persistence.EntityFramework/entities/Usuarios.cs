
namespace ClipMoney.Persistence.EntityFramework.entities
{
    public partial class Usuarios
    {
        public int id { get; set; }
        public string nombre_usuario { get; set; }
        public string password { get; set; }
        public string hashed_password { get; set; }
        public string salt { get; set; }
        public string foto_frente { get; set; }
        public string foto_dorso { get; set; }
        public int? estado { get; set; }
    }
}
