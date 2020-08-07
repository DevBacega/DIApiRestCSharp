using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Models
{
    public class Products
    {
        public int? Id_Product { get; set; } = null;
        public string Ds_Product { get; set; } = null;
        public Categories Categories { get; set; } = new Categories();
        public int? Active { get; set; } = null;
    }
}
