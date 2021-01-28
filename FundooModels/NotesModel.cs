using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class NotesModel
    {
        [Key]
        public int NotesId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reminder { get; set; }
        public string Collaborator { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public string Lable { get; set; }
        public bool Pin { get; set; } = false;
        public bool Archieve { get; set; } = false;

        [ForeignKey("RegistrationModel")]
        public int UserId { get; set; }
        public RegistrationModel RegistrationModel { get; set; }
    }
}
