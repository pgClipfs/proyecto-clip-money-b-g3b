using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
	public class TransacctionModel
	{
		public int Id_Transacction { get; set; }
		public DateTime? Init_Date { get; set; }
		public TransacctionTypeModel Transacction_Type { get; set; }
		public CommissionModel Commission { get; set; }
		public TransacctionDetailModel[] TransacctionDetail { get; set; }
	}
}
