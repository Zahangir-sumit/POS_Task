using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Core.Entities
{
    public class InvoiceDetails
    {
        public Guid Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Amount { get; set; }

        public Guid InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
