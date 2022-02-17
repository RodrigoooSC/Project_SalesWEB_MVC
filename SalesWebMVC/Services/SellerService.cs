using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;// readonly - Previnir que a dependência seja alterada.

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll() // Retorna uma lista com todos os vendedores do BD.
        {
            return _context.Seller.ToList(); // Acessa a fonte de dados relacionada a tabela Sellers e converte  em uma lista.
        }

        public void Insert(Seller obj) // Método para inserir vendedor no BD
        {
            _context.Add(obj);
            _context.SaveChanges(); // Confirma a inclusão no BD
        }

        public Seller FindById(int id) // Metodo que retorna o vendedor que possui o id
        {
            return _context.Seller.Include(obj =>obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) // Recebe o id e remove o vendedor do BD.
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if (!_context.Seller.Any(x => x.Id == obj.Id)) // Se não existir o vedendor com id igual
            {
                throw new NotFiniteNumberException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
           
        }
    }
}
