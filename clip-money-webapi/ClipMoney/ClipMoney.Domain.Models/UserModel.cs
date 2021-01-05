

namespace ClipMoney.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string HashedContraseña { get; set; }
        public string Salt { get; set; }
        public string FotoFrente { get; set; }
        public int FotoDorso { get; set; }
        public int Estado { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public int idCuenta { get; set; }
    }
}
