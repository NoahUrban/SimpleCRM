using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleCRM.Models;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimpleCRM.Controllers
{
    public class ProductSalesController : Controller
    {
        private readonly IProductSalesRepository _repo;
        private readonly IDbConnection _conn;

        public ProductSalesController(IProductSalesRepository repo, IDbConnection conn)
        {
            _repo = repo;
            _conn = conn;
        }

        public IActionResult Index()
        {
            ViewBag.Statuses = new SelectList(StatusList());

            var sales = _repo.GetAllSales().OrderBy(x => x.OrderNumber);
            return View(sales);
        }

        public IActionResult AddOrder()
        {
            ViewBag.Statuses = new SelectList(StatusList());

            ViewBag.ProductCodes = new SelectList(ProductCodeList());

            ViewBag.OrderNumber = LastOrderNumber();

            ViewBag.UID = RandomUID();

            return View();
        }

        public IActionResult InsertSaleToDatabase(ProductSales sale)
        {
            _repo.InsertSale(sale);
            return RedirectToAction("Index");
        }

        public List<string> StatusList()
        {
            var statuses = _repo.GetAllSales().GroupBy(x => x.Status).Select(x => x.First().Status).ToList();

            return statuses;
        }

        public List<string> ProductCodeList()
        {
            var productCodes = _repo.GetAllSales().GroupBy(x => x.ProductCode).Select(x => x.First().ProductCode).ToList();

            return productCodes;
        }

        public int LastOrderNumber()
        {
            var lastOrderNumber = _repo.GetAllSales().GroupBy(x => x.OrderNumber).Select(x => x.First().OrderNumber).ToList().Max() + 1;

            return lastOrderNumber;
        }

        public int RandomUID()
        {
            var uidList = _repo.GetAllSales().Select(x => x.uid).ToList();
            int uid;

            Random rnd = new Random();
            do
            {
                uid = rnd.Next(1, 99999);
            } while (uidList.Contains(uid));

            return uid;
        }
    }
}

