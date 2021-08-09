using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NAMG_Final.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا ایمیل را بدرستی وارد کنید"), MaxLength(90), EmailAddress, DisplayName("ایمیل"), Remote("VerifyEmail", "Account")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا پسورد را بدرستی وارد کنید"), MaxLength(16), DataType(DataType.Password), DisplayName("پسورد")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,20}$", ErrorMessage = "کلمه عبور باید شامل حرف و عدد باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا تکرار پسورد را بدرستی وارد کنید"), MaxLength(16), DataType(DataType.Password), Compare("Password"), DisplayName("تکرار پسورد")]
        public string RePassword { get; set; }
    }

  
}
