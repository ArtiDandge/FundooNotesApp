﻿using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interfaces
{
    public interface INotesManager
    {
        public string AddNewNote(NotesModel note);
    }
}