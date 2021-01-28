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
    }
}
