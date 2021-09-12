using CustomerOrdersManagerment.Models;
using DBStore.DAO;
using DBStore.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrdersManagerment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        #region order
        
        public IActionResult Index()
        {
            return View(OrderDAO.GetListTable());
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            return View(OrderDAO.GetTable(id));
        }
        public IActionResult Details(string id)
        {
            return View(OrderDAO.GetTable(id));
        }
        public IActionResult Delete(string id)
        {
            return View(OrderDAO.GetTable(id));
        }
        [HttpPost]
        public IActionResult Create(OrderDTO table)
        {
            OrderDAO.InsertTable(table);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(OrderDTO table)
        {
            OrderDAO.UpdateTable(table);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(OrderDTO table)
        {
            OrderDAO.DeleteTable(table.Id);
            return RedirectToAction("Index");
        }
        #endregion

        #region product
        public IActionResult HomeProduct()
        {
            return View(ProductDAO.GetListTable());
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        public IActionResult EditProduct(string id)
        {
            return View(ProductDAO.GetTable(id));
        }
        public IActionResult DetailsProduct(string id)
        {
            return View(ProductDAO.GetTable(id));
        }
        public IActionResult DeleteProduct(string id)
        {
            return View(ProductDAO.GetTable(id));
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductDTO table)
        {
            ProductDAO.InsertTable(table);
            return RedirectToAction("HomeProduct");
        }
        [HttpPost]
        public IActionResult EditProduct(ProductDTO table)
        {
            ProductDAO.UpdateTable(table);
            return RedirectToAction("HomeProduct");
        }
        [HttpPost]
        public IActionResult DeleteProduct(ProductDTO table)
        {
            ProductDAO.DeleteTable(table.Id);
            return RedirectToAction("HomeProduct");
        }
        #endregion

        #region customer
        public IActionResult HomeCustomer()
        {
            return View(CustomerDAO.GetListTable());
        }
        public IActionResult CreateCustomer(string id)
        {
            return View();
        }
        public IActionResult EditCustomer(string id)
        {
            return View(CustomerDAO.GetTable(id));
        }
        public IActionResult DetailsCustomer(string id)
        {
            return View(CustomerDAO.GetTable(id));
        }
        public IActionResult DeleteCustomer(string id)
        {
            return View(CustomerDAO.GetTable(id));
        }
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDTO table)
        {
            CustomerDAO.InsertTable(table);
            return RedirectToAction("HomeCustomer");
        }
        [HttpPost]
        public IActionResult EditCustomer(CustomerDTO table)
        {
            CustomerDAO.UpdateTable(table);
            return RedirectToAction("HomeCustomer");
        }
        [HttpPost]
        public IActionResult DeleteCustomer(CustomerDTO table)
        {
            CustomerDAO.DeleteTable(table.Id);
            return RedirectToAction("HomeCustomer");
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
