using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
