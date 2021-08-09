using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMG_Final.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public int QuantityInStock { get; set; }


        //Nav
        public Product product { get; set; }

    }
}
