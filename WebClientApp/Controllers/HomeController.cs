using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ObjectPool;
using SynergyClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebClientApp.Models;

namespace WebClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ObjectPool<SynergyMethods> _pool;

        public HomeController(ILogger<HomeController> logger, ObjectPool<SynergyMethods> pool)
        {
            _logger = logger;
            _pool = pool;
        }

        public IActionResult Index()
        {
            SynergyClient.SynergyMethods client = _pool.Get();

            try
            {
                ArrayList customers;
                client.GetAllCustomers(out customers);
                _pool.Return(client);

                client = _pool.Get();
                Customer c = (Customer)customers[1];
                ArrayList contacts;
                client.GetCustomerContacts(c.Customer_id, out contacts);
            }
            finally
            {
                _pool.Return(client);
            }

            return View();
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
