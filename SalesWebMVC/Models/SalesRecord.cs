﻿using System;
using SalesWebMVC.Models.Enums; // Cada venda possui um vendedor
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DataType(DataType.Date)] 
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
                
        [DisplayFormat(DataFormatString = "{0:F2}")] 
        public double Amount { get; set; }

        public SalesStatus Status { get; set; }
        public Seller Seller { get; set; } // Vendedor

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
