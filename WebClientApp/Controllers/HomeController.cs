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
            _pool = pool;       //Instance of pool from Dependency Injection
        }

        public IActionResult Index()
        {
            //Get a SynergyMethods client object from the pool
            SynergyMethods client = _pool.Get();

            try
            {
                //Use the object to make an xfServerPlus method call
                ArrayList customers;
                client.GetAllCustomers(out customers);

                //Use the object to make a second xfServerPlus method call
                Customer c = (Customer)customers[1];
                ArrayList contacts;
                client.GetCustomerContacts(c.Customer_id, out contacts);
            }
            finally
            {
                //When done, return the SynergyMethods object to the pool
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
