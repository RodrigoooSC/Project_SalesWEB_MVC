using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService // Serviço para popular a base de dados
    {
        private SalesWebMVCContext _context; // Registra uma dependência com o DBContext

        public SeedingService(SalesWebMVCContext context) 
        {
            _context = context;
        }

        public void Seed() // Operação que vai popular o DB
        {
            if(_context.Department.Any() || // Testa se a base de dados possui algum registro
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // Para a execução se houver registro
            }

            // Se a base de dados não possuir registros a aplicação instancia os departamento, vendedores e vendas.
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");


            Seller s1 = new Seller(1, "Adriano Brown", "adriano@gmail.com", new DateTime(1992, 10, 15), 1200.0, d1);
            Seller s2 = new Seller(2, "Maria blue", "Maria@gmail.com", new DateTime(1989, 08, 25), 1000.0, d3);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1991, 01, 06), 1000.0, d2);
            Seller s4 = new Seller(4, "Carla Gomes", "Carla@gmail.com", new DateTime(1995, 04, 15), 1350.0, d4);
            Seller s5 = new Seller(5, "Julian Yellow", "Julian@gmail.com", new DateTime(1995, 08, 03), 2250.0, d4);
            Seller s6 = new Seller(6, "Antonio red", "antonio@gmail.com", new DateTime(1990, 12, 09), 3000.0, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2021, 12, 05), 12000.00, SalesStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2021, 12, 05), 10000.00, SalesStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2021, 12, 06), 12350.00, SalesStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2021, 12, 08), 9100.50, SalesStatus.Billed, s5);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2021, 12, 15), 8956.41, SalesStatus.Billed, s4);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2022, 01, 01), 10000.25, SalesStatus.Billed, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2022, 01, 01), 16000.56, SalesStatus.Billed, s1);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2022, 01, 03), 5000.09, SalesStatus.Billed, s1);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2022, 01, 07), 4569.50, SalesStatus.Billed, s3);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2022, 01, 08), 18560.00, SalesStatus.Billed, s1);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2022, 01, 08), 6560.00, SalesStatus.Billed, s2);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2022, 01, 09), 4560.00, SalesStatus.Billed, s1);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2022, 01, 10), 500.00, SalesStatus.Billed, s3);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2022, 01, 12), 920.00, SalesStatus.Billed, s4);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2022, 01, 13), 9587.00, SalesStatus.Billed, s1);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2022, 01, 13), 1785.90, SalesStatus.Billed, s6);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2022, 01, 15), 963.30, SalesStatus.Billed, s6);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2022, 01, 17), 15560.60, SalesStatus.Billed, s5);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2022, 01, 19), 50.90, SalesStatus.Billed, s4);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2022, 01, 21), 10560.00, SalesStatus.Billed, s4);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2022, 01, 26), 789.00, SalesStatus.Billed, s2);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2022, 02, 02), 1562.23, SalesStatus.Billed, s2);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2022, 02, 03), 26369.56, SalesStatus.Billed, s3);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2022, 02, 08), 1000.00, SalesStatus.Billed, s3);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2022, 02, 09), 56230.00, SalesStatus.Billed, s5);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2022, 02, 12), 48952.00, SalesStatus.Billed, s6);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2022, 02, 13), 18960.10, SalesStatus.Billed, s6);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2022, 02, 15), 5623.00, SalesStatus.Billed, s1);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2022, 02, 15), 530.90, SalesStatus.Billed, s2);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2022, 02, 16), 1560.00, SalesStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3, d4); // Metodo AddRange adiciona varios objetos de uma só vez
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16,
                r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            _context.SaveChanges(); // Salvar e confirma as alterações do DB.
        }

    }
}
