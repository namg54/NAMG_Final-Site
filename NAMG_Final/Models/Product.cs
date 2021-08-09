using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NAMG_Final.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public int Price { get; set; }

        //Nav

        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
