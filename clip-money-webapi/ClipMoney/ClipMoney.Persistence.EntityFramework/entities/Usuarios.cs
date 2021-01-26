using System;
using System.Collections.Generic;

namespace ClipMoney.Persistence.EntityFramework.entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            giro_descubierto = new HashSet<giro_descubierto>();
            transaction = new HashSet<transaction>();
            wallet = new HashSet<wallet>();
        }

        public int id { get; set; }
        public string nombre_usuario { get; set; }
        public string password { get; set; }
        public string hashed_password { get; set; }
        public string salt { get; set; }
        public string foto_frente { get; set; }
        public string foto_dorso { get; set; }
        public int? estado { get; set; }

        public virtual ICollection<giro_descubierto> giro_descubierto { get; set; }
        public virtual ICollection<transaction> transaction { get; set; }
        public virtual ICollection<wallet> wallet { get; set; }
    }
}
