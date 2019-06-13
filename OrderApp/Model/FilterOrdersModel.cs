using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Model
{
	public class FilterOrdersModel
	{
		public long? OxId { get; set; }
		public int? InvoiceNumber { get; set; }
		public byte? OrderStatus { get; set; }
		public DateTime? OrderDatetimeStart { get; set; }
		public DateTime? OrderDatetimeEnd { get; set; }


	}
}
