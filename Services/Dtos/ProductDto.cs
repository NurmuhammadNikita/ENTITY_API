using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public Guid TypeId { get; set; }
        public DateTime DateMonifacture { get; set; }
        public DateTime DateExpiration { get; set; }
    }
}
