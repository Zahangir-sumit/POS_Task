using POS.Solution.Application.IService;
using POS.Solution.Core.Entities;
using POS.Solution.Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Application.Services
{
    public class PosService : IPosService
    {
        private readonly IPosRepository _posRepository; 
        public PosService(IPosRepository posRepository)
        {
            _posRepository = posRepository;
        }
        public async Task Add(Invoice invoice)
        {
           await _posRepository.Add(invoice);
        }

        public async Task Delete(Guid Id)
        {
            await _posRepository.Delete(Id);
        }

        public async Task<List<Invoice>> GetAll()
        {
            var Invoices = await _posRepository.GetAll();

            return Invoices;

        }

        public async Task<Invoice> GetInvoice(Guid Id)
        {
            var Invoice = await _posRepository.GetInvoice(Id);

            return Invoice;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _posRepository.GetProducts();

            return products;
        }

        public async Task Update(Invoice invoice)
        {
            await _posRepository.Update(invoice);
        }
    }
}
