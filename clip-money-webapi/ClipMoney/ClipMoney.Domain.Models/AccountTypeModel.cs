using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
	public class AccountTypeModel
	{

		public int Id_Account_type { get; set; }
		public string Type { get; set; }
		public CoinModel Coin { get; set; }

	}
}
