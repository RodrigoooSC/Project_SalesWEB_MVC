using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService; // Declarar a depedencia do SellerService.

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index() // Controller - chamamos o controlador
        {
            var list = _sellerService.FindAll(); // Model  - controlador acessa o model e pega os dados em lista

            return View(list); // View - controlador encaminha os dados para view
        }         
    }
}
