using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Purchase
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
