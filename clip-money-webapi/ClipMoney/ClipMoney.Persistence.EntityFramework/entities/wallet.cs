using System;
using System.Collections.Generic;

namespace ClipMoney.Persistence.EntityFramework.entities
{
    public partial class wallet
    {
        public int id { get; set; }
        public int? id_user { get; set; }
        public double? funds { get; set; }

        public virtual Usuarios id_userNavigation { get; set; }
    }
}
