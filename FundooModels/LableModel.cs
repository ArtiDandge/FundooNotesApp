using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModels
{
    public class LableModel
    {
        [Key]
        public int LableId { get; set; }
        public string Lable { get; set; }
    }
}
