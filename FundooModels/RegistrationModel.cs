using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModels
{
    public class RegistrationModel
    {
        [Required]
        public string UserFirstName { get; set; }

        [Required]
        public string UserLastName { get; set; }

        [Key]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }

    }
}
