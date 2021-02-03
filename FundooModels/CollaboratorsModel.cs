using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class CollaboratorsModel
    {
        [Key]
        public int CollaboratorID { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }

        [ForeignKey("NotesModel")]
        public int NoteId { get; set; }
        public virtual NotesModel NotesModel { get; set; }
    }
}
