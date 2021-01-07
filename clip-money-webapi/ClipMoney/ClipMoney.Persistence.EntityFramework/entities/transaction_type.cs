using System;
using System.Collections.Generic;

namespace ClipMoney.Persistence.EntityFramework.entities
{
    public partial class transaction_type
    {
        public transaction_type()
        {
            transaction = new HashSet<transaction>();
        }

        public int id { get; set; }
        public string description { get; set; }

        public virtual ICollection<transaction> transaction { get; set; }
    }
}
