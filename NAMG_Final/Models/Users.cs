using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NAMG_Final.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل را بدرستی وارد کنید"), MaxLength(90), DisplayName("ایمیل")] 
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا پسورد را بدرستی وارد کنید"), MaxLength(16), DisplayName("پسورد")] 
        public string Password { get; set; }
        [Required, DisplayName("تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }
        [Required, DisplayName("مدیریت")]
        public bool IsAdmin { get; set; }



        public List<Order> Orders { get; set; }
    }
}
