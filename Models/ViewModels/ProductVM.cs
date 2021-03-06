using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Models.ViewModels
{
    public class ProductVM
    {
        public Products Products { get; set; }
        public IEnumerable<SpecialTags> SpecialTags { get; set; }
        public IEnumerable<ProductTypes> ProductTypes { get; set; }
    }
}
