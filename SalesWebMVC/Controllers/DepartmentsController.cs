using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {

            List<Department> list = new List<Department>(); // Criar lista de departamentos
            list.Add(new Department { Id = 1, Name = "Eletronics" }); // Instanciar o departamento 
            list.Add(new Department { Id = 2, Name = "Fashion" });


            return View(list); // Enviar a lista para a view
        }
    }
}
