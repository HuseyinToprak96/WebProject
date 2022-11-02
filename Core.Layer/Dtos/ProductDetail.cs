using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Dtos
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }
    }
}
