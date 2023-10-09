using POS.Solution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Persistence.IRepository
{
    public interface IPosRepository
    {
        Task<List<Invoice>> GetAll();
        Task<List<Product>> GetProducts();
        Task<Invoice> GetInvoice(Guid Id);
        Task Add(Invoice entityToAdd);
        Task Update(Invoice entityToEdit);
        Task Delete(Guid Id);
    }
}
