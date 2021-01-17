using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
	public class AccountModel
	{

		//private int id;
		//private long cvu;
		//private string alias;
		//private decimal saldo;
		//private string estado;
		//private TransacctionModel[] transacciones;
		//private DateTime fechaAlta;
		//private AccountTypeModel tipoCuenta;

		//public Account()
		//{
		//}
		//public Account(string est, string alias, long cvu, decimal saldo, DateTime fechaAlta, AccountTypeModel tipoCuenta)
		//{
		//	this.estado = est;
		//	this.alias = alias;
		//	this.cvu = cvu;
		//	this.saldo = saldo;
		//	this.fechaAlta = fechaAlta;
		//	this.tipoCuenta = tipoCuenta;
		//}

		//public string Alias
		//{
		//	get { return alias; }
		//	set { alias = value; }
		//}
		//public long Cvu
		//{
		//	get { return cvu; }
		//	set { cvu = value; }
		//}
		//public int Id
		//{
		//	get { return id; }
		//	set { id = value; }
		//}
		//public AccountTypeModel TipoCuenta
		//{
		//	get { return tipoCuenta; }
		//	set { tipoCuenta = value; }
		//}
		//public string Estado
		//{
		//	get { return estado; }
		//	set { estado = value; }
		//}

		//public decimal Saldo
		//{
		//	get { return saldo; }
		//	set { saldo = value; }

		//}

		//public DateTime FechaAlta { get { return fechaAlta; } set { fechaAlta = value; } }
		//public TransacctionModel[] Transacction { get { return transacciones; } set { transacciones = value; } }
		public int Id_Account {get; set;}

		public string State { get; set;}

		public double Amount { get; set;}

		public long Cvu { get; set; }

		public string Alias { get; set; }

		public AccountTypeModel Account_type { get; set; }

		public TransacctionModel[]? Transacction { get; set; }
	}
}
