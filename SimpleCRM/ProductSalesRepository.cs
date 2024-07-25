using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using SimpleCRM.Models;

namespace SimpleCRM
{
    public class ProductSalesRepository : IProductSalesRepository
    {
        private readonly IDbConnection _conn;

        public ProductSalesRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<ProductSales> GetAllSales()
        {
            return _conn.Query<ProductSales>("SELECT * FROM sales;");
        }

        public void InsertSale(ProductSales sale)
        {
            _conn.Execute("INSERT INTO sales (ORDERNUMBER, QUANTITYORDERED, PRICEEACH, CUSTOMERNAME, PRODUCTCODE, ORDERDATE, SALES, STATUS, UID) VALUES (@OrderNumber, @QuantityOrdered, @PriceEach, @CustomerName, @ProductCode, @OrderDate, @Sales, @Status, @UID);",
                new { OrderNumber = sale.OrderNumber, QuantityOrdered = sale.QuantityOrdered, PriceEach = sale.PriceEach, CustomerName = sale.CustomerName, ProductCode = sale.ProductCode, OrderDate = sale.OrderDate, Sales = sale.Sales, Status = sale.Status, UID = sale.uid});
        }

    }
}
