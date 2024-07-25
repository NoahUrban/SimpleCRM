using System;
using SimpleCRM.Models;

namespace SimpleCRM
{
	public interface IProductSalesRepository
	{
		IEnumerable<ProductSales> GetAllSales();
        public void InsertSale(ProductSales sale);
    }
}

