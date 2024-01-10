using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.AccountDtos
{
    public class CreateAccountDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Şifre Aynı Değil")]
        public string ConfirmPassword { get; set; }
    }
}
