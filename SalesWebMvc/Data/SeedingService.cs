using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // DB HAS BEEN SEEDED
            }

            Department d1 = new Department("Computers", 1);
            Department d2 = new Department("Eletronics", 2);
            Department d3 = new Department("Fashion", 3);
            Department d4 = new Department("Book", 4);

            Seller s1 = new Seller(1, "Lucas Gomes", "lucas@email.com", new DateTime(1995, 4, 18), 2500, d1);
            Seller s2 = new Seller(2, "Joao Gomes", "joao@email.com", new DateTime(1990, 7, 20), 4000, d2);
            Seller s3 = new Seller(3, "Nayra Mendes", "nayra@email.com", new DateTime(1980, 4, 10), 3000, d3);
            Seller s4 = new Seller(4, "Julia Mendes", "julia@email.com", new DateTime(1990, 3, 25), 1500, d4);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2020, 2, 10), 5000, SalesStatus.Billed, s1);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2020, 2, 9), 2000, SalesStatus.Billed, s2);
            SalesRecord sr3 = new SalesRecord(3, new DateTime(2020, 2, 11), 100, SalesStatus.Billed, s3);
            SalesRecord sr4 = new SalesRecord(4, new DateTime(2020, 1, 15), 3000, SalesStatus.Billed, s4);
            SalesRecord sr5 = new SalesRecord(5, new DateTime(2020, 3, 10), 1000, SalesStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4);

            _context.SalesRecord.AddRange(sr1, sr2, sr3, sr4, sr5);
            
            _context.SaveChanges();
        }
    }
}
