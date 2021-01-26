using System;
using System.Collections.Generic;

namespace ClipMoney.Persistence.EntityFramework.entities
{
    public partial class giro_descubierto
    {
        public int id { get; set; }
        public int? id_user { get; set; }
        public double? amount { get; set; }
        public double? balance { get; set; }

        public virtual Usuarios id_userNavigation { get; set; }
    }
}
