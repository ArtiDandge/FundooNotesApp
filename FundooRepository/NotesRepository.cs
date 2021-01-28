using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository
{
    public class NotesRepository : INotes
    {
        private readonly UserContext userContext;

        public NotesRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public string AddNewNote(NotesModel note)
        {
            this.userContext.FundooNotes.Add(note);
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public IEnumerable<NotesModel> RetrievNote()
        {
            IEnumerable<NotesModel> result;
            IEnumerable<NotesModel> note = this.userContext.FundooNotes;
            if (note !=null)
            {
                result = note;
            }
            else
            {
               result = null;
            }
            return result;   
        }
    }
}
