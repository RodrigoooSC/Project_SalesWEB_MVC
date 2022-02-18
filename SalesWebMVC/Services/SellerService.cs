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

        public async Task<List<Seller>> FindAllAsync() // Retorna uma lista com todos os vendedores do BD.
        {
            return await _context.Seller.ToListAsync(); // Acessa a fonte de dados relacionada a tabela Sellers e converte  em uma lista.
        }

        public async Task InsertAsync(Seller obj) // Método para inserir vendedor no BD
        {
            _context.Add(obj);
            await _context.SaveChangesAsync(); // Confirma a inclusão no BD
        }

        public async Task<Seller> FindByIdAsync(int id) // Metodo que retorna o vendedor que possui o id
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) // Recebe o id e remove o vendedor do BD.
        {
            var obj =await  _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny) // Se não existir o vedendor com id igual
            {
                throw new NotFiniteNumberException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
