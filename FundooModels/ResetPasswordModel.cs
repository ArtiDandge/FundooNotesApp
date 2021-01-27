using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModels
{
    public class ResetPasswordModel
    {
        [Key]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
