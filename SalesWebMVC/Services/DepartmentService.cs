using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        // Operação Síncrona
        /*public List<Department> FindAll() 
        {
            return _context.Department.OrderBy(x => x.Name).ToList(); // Retorna lista de departamentos ordenados.
        }*/

        // Operação Assíncrona - Evita que o método bloquei a aplicação durante a execução
        public async Task<List<Department>> FindAllAsync() 
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync(); // Retorna lista de departamentos ordenados.
        }
    }
}
