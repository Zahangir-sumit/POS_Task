using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Solution.Core.Entities
{
    public class Invoice
    {
        public Guid Id { get; set; }
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }

        public virtual List<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
