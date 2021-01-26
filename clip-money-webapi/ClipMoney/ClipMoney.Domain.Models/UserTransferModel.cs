using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
    public class UserTransferModel
    {
        public string NombreUsuario { get; set; }
        public long? Cvu { get; set; }
        public string CountOwner { get; set; }


    }
}
