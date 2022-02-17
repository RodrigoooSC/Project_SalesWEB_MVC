using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Data;

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
    }
}
