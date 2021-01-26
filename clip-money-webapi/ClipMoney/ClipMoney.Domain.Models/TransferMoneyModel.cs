using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
    public class TransferMoneyModel
    {
        public long Cvu { get; set; }
        public double Mount { get; set; }
        public string OwnerUser { get; set; }
    }
}
