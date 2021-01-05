using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
	public class CuentaModel
	{
		private int id;
		private long cvu;
		private string alias;
		private decimal saldo;
		private string estado;
		private Transaccion[] transaccions;
		private DateTime fechaAlta;
		private TipoCuenta tipoCuenta;
		public Cuenta(string est, long cvu, string alias, decimal saldo, DateTime fechaAlta, TipoCuenta tipoCuenta)
		{
			this.estado = est;
			this.alias = alias;
			this.cvu = cvu;
			this.saldo = saldo;
			this.fechaAlta = fechaAlta;
			this.tipoCuenta = tipoCuenta;
		}

		public string Alias
		{
			get { return alias; }
			set { alias = value; }
		}
		public long Cvu
		{
			get { return cvu; }
			set { cvu = value; }
		}
		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public TipoCuenta TipoCuenta
		{
			get { return tipoCuenta; }
			set { tipoCuenta = value; }
		}
		public string Estado
		{
			get { return estado; }
			set { estado = value; }
		}

		public decimal Saldo
		{
			get { return saldo; }
			set { saldo = value; }

		}
	}
}
