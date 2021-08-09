using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NAMG_Final.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا ایمیل را بدرستی وارد کنید"), MaxLength(90), DisplayName("نام محصول")]
        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا توضیحات را بدرستی وارد کنید"), DisplayName("توضیحات محصول")]
        public string Description { get; set; }
        [Required(ErrorMessage = "لطفا قیمت را بدرستی وارد کنید"), DisplayName("قیمت محصول")]
        public int Price { get; set; }
        [Required(ErrorMessage = "لطفا تعداد را بدرستی وارد کنید"),  DisplayName("تعداد موجودی محصول")]
        public int QuantityInStock { get; set; }
        [Required(ErrorMessage = "لطفا تصویر را بدرستی وارد کنید"),  DisplayName("تصویر محصول")]
        public IFormFile Picture { get; set; }
        public List<Category> Categories { get; set; }
       

    }
}
