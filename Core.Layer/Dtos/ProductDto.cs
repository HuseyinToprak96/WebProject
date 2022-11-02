using Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ECategory Category { get; set; }
        public int Unit { get; set; }
        public double UnitPrice { get; set; }
    }
}
