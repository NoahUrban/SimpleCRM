using System;
namespace SimpleCRM.Models
{
	public class ProductSales
	{
		public int OrderNumber { get; set; }

		public int QuantityOrdered { get; set; }

        public double PriceEach { get; set; }

        public string CustomerName { get; set; }

        public string ProductCode { get; set; }

        public string OrderDate { get; set; }

        public double Sales { get; set; }

        public string Status { get; set; }

        public int uid { get; set; }

    }
}

