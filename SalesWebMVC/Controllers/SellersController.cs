using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService; // Declarar a depedencia do SellerService.
        private readonly DepartmentService _departmentService; // Declarar a depedencia do DepartmentService.

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index() // Controller - chamamos o controlador
        {
            var list = _sellerService.FindAll(); // Model  - controlador acessa o model e pega os dados em lista

            return View(list); // View - controlador encaminha os dados para view
        } 
        
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel); // Recebe os departamento
        }

        [HttpPost] // Anotation - indica ação de post
        [ValidateAntiForgeryToken] 
        /* Previnir ataque CSRF - Cross-site Request Forgery (CSRF) é um tipo de ataque de websites maliciosos.
        Um ataque CSRF às vezes é chamado de ataque de um clique ou transporte de sessão. Esse tipo de ataque
        envia solicitações desautorizadas de um usuário no qual o website confia.*/
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); // Redireciona para a pagina index/seller.
        }

        public IActionResult Delete(int? id) //int? - opcional
        {
            if(id == null)
            {
                return NotFound(); // Retorna uma resposta básica
            }

            var obj = _sellerService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Retorna uma resposta básica
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


    }
}
