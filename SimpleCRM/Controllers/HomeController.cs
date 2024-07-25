using System.Diagnostics;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Models;

namespace SimpleCRM.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductSalesRepository _salesRepo;

    public HomeController(ILogger<HomeController> logger, IProductSalesRepository salesRepo)
    {
        _logger = logger;
        _salesRepo = salesRepo;
    }

    public IActionResult Index()
    {
        var allSales = _salesRepo.GetAllSales().OrderBy(x => x.OrderNumber).ToList();

        ViewBag.TotalAwaitingSale = CalculateTotalItemsAwaiting(allSales);
        ViewBag.PendingOrders = CalculatePendingOrders(allSales);
        ViewBag.SumPendingOrders = CalculateValuePendingOrders(allSales);

        return View(allSales);
    }

    private string CalculateTotalItemsAwaiting(List<ProductSales> allSales)
    {
        return allSales.Where(x => x.Status == "In Process").Sum(x => x.QuantityOrdered).ToString("0,000");
    }

    private int CalculatePendingOrders(List<ProductSales> allSales)
    {
        return allSales.Count(x => x.Status == "In Process"); 
    }

    private string CalculateValuePendingOrders(List<ProductSales> allSales)
    {
        return allSales.Where(x => x.Status == "In Process").Sum(x => x.Sales).ToString("000,000.00");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

