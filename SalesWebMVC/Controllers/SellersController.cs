using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;
using SalesWebMVC.Services.Exceptions;
using System.Diagnostics;

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

        public async Task<IActionResult> Index() // Controller - chamamos o controlador
        {
            var list = await _sellerService.FindAllAsync(); // Model  - controlador acessa o model e pega os dados em lista

            return View(list); // View - controlador encaminha os dados para view
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel); // Recebe os departamento
        }

        [HttpPost] // Anotation - indica ação de post
        [ValidateAntiForgeryToken]
        /* Previnir ataque CSRF - Cross-site Request Forgery (CSRF) é um tipo de ataque de websites maliciosos.
        Um ataque CSRF às vezes é chamado de ataque de um clique ou transporte de sessão. Esse tipo de ataque
        envia solicitações desautorizadas de um usuário no qual o website confia.*/
        public async Task<IActionResult> Create(Seller seller)
        {
            if (!ModelState.IsValid) // Verificar se os campos foram validados 
            {
                var departments = await _departmentService.FindAllAsync(); // Carrega os departamentos
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments }; // Cria o ViewModel passando o seller e o department  
                return View(viewModel); // Enquanto os campos não forem validados ele retorna a tela de create
            }

            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index)); // Redireciona para a pagina index/seller.
        }

        public async Task<IActionResult> Delete(int? id) //int? - opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" }); // Retorna uma resposta básica
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Department> departments = await _departmentService.FindAllAsync(); // Carrega lista de departamentos.
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid) // Verificar se os campos foram validados 
            {
                var departments = await _departmentService.FindAllAsync(); // Carrega os departamentos
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments }; // Cria o ViewModel passando o seller e o department  
                return View(viewModel); // Enquanto os campos não forem validados ele retorna a tela de create
            }

            if (id != seller.Id) // Se o Id do vendedor for diferente do Id da requisição
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }            
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
