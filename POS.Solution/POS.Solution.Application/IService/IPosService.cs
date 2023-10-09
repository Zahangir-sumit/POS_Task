using POS.Solution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Application.IService
{
    public interface IPosService
    {
        Task<List<Invoice>> GetAll();
        Task<List<Product>> GetProducts();
        Task<Invoice> GetInvoice(Guid Id);
        Task Add(Invoice invoice);
        Task Update(Invoice invoice);
        Task Delete(Guid Id);
    }
}
