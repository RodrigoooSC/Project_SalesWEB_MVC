using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models // Um vendedor possui um departamento
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")] // Campo requirido onde {0} pega o nome do atributo
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")] // Limitar caracteres, colocar mensagem de erro
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]// Definir formatação de email
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]        
        [Display (Name = "Birth Date")] // Definir formatação da label
        [DataType(DataType.Date)] // Definir formatação da data
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // Definir formatação da data        
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Base Salary")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")] // Definir faixa de valores min-max
        [DisplayFormat(DataFormatString = "{0:F2}")] // Definir formatação de valores
        public double BaseSalary { get; set; }

        public Department Department { get; set; } // Instanciar o departamento
        public int DepartmentId { get; set; } // Avisa o entity framework que o id deve existir e não pode ser nulo
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
