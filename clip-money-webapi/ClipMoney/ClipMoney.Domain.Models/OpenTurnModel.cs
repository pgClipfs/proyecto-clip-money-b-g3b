using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
    public class OpenTurnModel
    {
        public int Id { get; set; }
        public int? Id_user { get; set; }
        public double? Amount { get; set; }
        public double?  Balance { get; set; }
    }
}
