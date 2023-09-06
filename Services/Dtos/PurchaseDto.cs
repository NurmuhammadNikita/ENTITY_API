using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class PurchaseDto
    {
            public Guid ClientId { get; set; }
            public Guid ProductId { get; set; }
        
    }
}
