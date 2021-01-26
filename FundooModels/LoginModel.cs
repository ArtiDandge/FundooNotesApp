using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FundooModels
{
    public  class LoginModel
    {
        [Key]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
}
