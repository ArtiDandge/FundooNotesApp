using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class LableModel
    {
        [Key]
        public int LableId { get; set; }
        public string Lable { get; set; }

        [ForeignKey("RegistrationModel")]
        public int UserId { get; set; }
        public virtual RegistrationModel RegistrationModel { get; set; }
        public int NoteId { get; set; }
    }
}
