using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models // Um departamento possui vários vendedores
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); // Instanciar os vendedores - Implementar o departamento com o vendedor

        public Department() // Este construtor so é necessario pois o construtor com argumento vai ser implementado
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Metodos customizados

        public void AddSelles(Seller seller) // Adicionar vendedor na lista de vendedores
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final) // Total de vendas do departamento por intervalo de datas
        {
            // LINQ + expressão lambda pegar a lista de vendedores do departamento e somar o total de vendas de cada vendedor no intervalo de data
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
