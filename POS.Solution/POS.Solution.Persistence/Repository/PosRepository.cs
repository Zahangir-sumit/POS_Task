using Microsoft.EntityFrameworkCore;
using POS.Solution.Core.Entities;
using POS.Solution.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Persistence.Repository
{
    public class PosRepository : IPosRepository
    {
        private readonly ApplicationDbContext _context;

        public PosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Invoice entityToAdd)
        {
            await _context.Invoices.AddAsync(entityToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid Id)
        {
            var entityToDelete = await _context.Invoices.Where(x=> x.Id == Id).Include(x => x.InvoiceDetails).FirstOrDefaultAsync();

            if (entityToDelete != null)
            {
                _context.Invoices.Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

        public async Task<List<Invoice>> GetAll()
        {
            var Invoices = await _context.Invoices.Include(x => x.InvoiceDetails).ToListAsync();

            return Invoices;
        }

        public async Task<Invoice> GetInvoice(Guid Id)
        {

            var entity = await _context.Invoices.Where(x => x.Id == Id).Include(x => x.InvoiceDetails).FirstOrDefaultAsync();

            return entity;

        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task Update(Invoice entityToEdit)
        {
            await Task.Run(() =>
            {
                _context.Entry(entityToEdit).State = EntityState.Modified;
                _context.SaveChangesAsync();
            });

        }
    }
}
