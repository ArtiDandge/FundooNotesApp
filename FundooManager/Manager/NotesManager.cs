// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooManager.Interfaces;
    using FundooModels;
    using FundooRepository.Interfaces;

    /// <summary>
    /// NotesManager class implements INotesManager interface
    /// </summary>
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// note field of type INotes
        /// </summary>
        private readonly INotes notes;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager" /> class.
        /// </summary>
        /// <param name="notes">notes parameter of type INotes</param>
        public NotesManager(INotes notes)
        {
            this.notes = notes;
        }

        /// <summary>
        /// Method to Call AddNewNote() method to create new note
        /// </summary>
        /// <param name="note">note parameter</param>
        /// <returns>string message</returns>
        public string AddNewNote(NotesModel note)
        {
            string message = this.notes.AddNewNote(note);
            return message;
        }

        /// <summary>
        ///  Method to Call RetrievNote() method to retriev
        /// </summary>
        /// <returns>All notes</returns>
        public IEnumerable<NotesModel> RetrievNote()
        {
            IEnumerable<NotesModel> note = this.notes.RetrievNote();
            return note;
        }

        /// <summary>
        /// Method to Call RemoveNote() method to remove a note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string note message</returns>
        public string RemoveNote(int id)
        {
            string note = this.notes.RemoveNote(id);
            return note;
        }

        /// <summary>
        /// Method to Call UpdateNote() method to update a note 
        /// </summary>
        /// <param name="note">note id</param>
        /// <returns>string message</returns>
        public string UpdateNote(NotesModel note)
        {
            string message = this.notes.UpdateNote(note);
            return message;
        }
    }
}
