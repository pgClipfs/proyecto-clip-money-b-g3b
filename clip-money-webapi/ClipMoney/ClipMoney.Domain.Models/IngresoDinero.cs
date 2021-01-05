using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
	public class IngresoDinero
	{
		private int idCuenta;
		private decimal monto;

		public int IdCuenta
		{
			get { return idCuenta; }
			set { idCuenta = value; }
		}

		public decimal Monto
		{
			get { return monto; }
			set { monto = value; }
		}
	}
}
