using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
    public interface INotes
    {
        public string AddNewNote(NotesModel note);
        public IEnumerable<NotesModel> RetrievNote();
    }
}
