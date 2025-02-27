using Microsoft.AspNetCore.Mvc;
using RCP.MVC.Models;
using RCP.MVC.Services;
using System.Diagnostics;

namespace RCP.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISupplierService _supplierService;

        public HomeController(ILogger<HomeController> logger, ISupplierService supplierService)
        {
            _logger = logger;
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index()
        {
            var supplier = await _supplierService.GetSupplierFromServiceAsync(11);
            return View(supplier);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
