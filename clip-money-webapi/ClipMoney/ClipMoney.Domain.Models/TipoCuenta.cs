using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
	class TipoCuenta
	{
		private string nombre;
		private int id;

		public string Nombre
		{
			get
			{
				return nombre;
			}
			set
			{
				nombre = value;
			}
		}
	}
}
