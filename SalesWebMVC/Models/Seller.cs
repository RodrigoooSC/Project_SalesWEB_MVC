using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMVC.Models // Um vendedor possui um departamento
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // Instanciar o departamento
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); // Associação do vendedor com as venda

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Metodos customizados

        public void AddSales(SalesRecord sr) // Adicionar uma venda na lista de vendas
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr) // Remover uma venda na lista de vendas
        {
            Sales.Remove(sr);
        }
        
        public double TotalSales(DateTime initial, DateTime final) // Total de vendas do vendedor por periodo
        {
            // LINQ + Expressão lambda que filtra a lista de vendas entre os intervalos de datas e faz a soma das vendas
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
