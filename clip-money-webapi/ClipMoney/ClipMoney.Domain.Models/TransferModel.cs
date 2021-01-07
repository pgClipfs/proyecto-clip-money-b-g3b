using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
    public class TransferModel
    {
        public int Id_user { get; set; }
        public int? Transaction_type { get; set; }
        public double? Amount { get; set; }
    }
}