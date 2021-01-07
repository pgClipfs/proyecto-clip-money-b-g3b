using System;
using System.Collections.Generic;

namespace ClipMoney.Persistence.EntityFramework.entities
{
    public partial class transaction
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public int? transaction_type { get; set; }
        public double? amount { get; set; }

        public virtual Usuarios id_userNavigation { get; set; }
        public virtual transaction_type transaction_typeNavigation { get; set; }
    }
}
