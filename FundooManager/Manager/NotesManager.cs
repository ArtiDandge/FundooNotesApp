using FundooManager.Interfaces;
using FundooModels;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotes notes;

        public NotesManager(INotes notes)
        {
            this.notes = notes;
        }

        public string AddNewNote(NotesModel note)
        {
            string message = this.notes.AddNewNote(note);
            return message;
        }

        public IEnumerable<NotesModel> RetrievNote()
        {
            IEnumerable<NotesModel> note = this.notes.RetrievNote();
            return note;
        }

        public string RemoveNote(int id)
        {
            string note = this.notes.RemoveNote(id);
            return note;
        }
    }
}
