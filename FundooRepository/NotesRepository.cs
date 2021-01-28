using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public string RemoveNote(int id)
        {
            try
            {
                var note = this.userContext.FundooNotes.Find(id);
                this.userContext.FundooNotes.Remove(note);
                this.userContext.SaveChangesAsync();
                return "Note Deleted Successfully"; ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UpdateNote(NotesModel note)
        {
            if (note.NotesId != 0)
            {
                userContext.Entry(note).State = EntityState.Modified;
            }
            this.userContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }
    }
}
