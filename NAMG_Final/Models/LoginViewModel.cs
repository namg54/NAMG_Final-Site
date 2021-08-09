using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NAMG_Final.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا ایمیل را بدرستی وارد کنید"), MaxLength(90), EmailAddress, DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا پسورد را بدرستی وارد کنید"), MaxLength(16), DataType(DataType.Password), DisplayName("پسورد")]
        public string Password { get; set; }
        [DisplayName("مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
