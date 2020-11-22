using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
    public class UserInLoggedModel
    {
        public string NombreUsuario { get; set; }
        public string Estado { get; set; }
        public string Token { get; set; }
    }
}
