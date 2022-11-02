using Core.Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Entities
{
    public class Product:Base
    {
        public string Description { get; set; }
        public ECategory Category { get; set; }
        public int Unit { get; set; }
        public double UnitPrice { get; set; }
        public bool Status { get; set; }
    }
}
