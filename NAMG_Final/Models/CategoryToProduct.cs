using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NAMG_Final.Models
{
    public class CategoryToProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        //Navigation
        public Category Category { get; set; }
        public Product Product { get; set; }
            

    }
}
