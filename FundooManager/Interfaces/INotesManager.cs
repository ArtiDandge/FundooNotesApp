// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotesManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModels;

    /// <summary>
    /// INotesManager interface
    /// </summary>
    public interface INotesManager
    {
        /// <summary>
        /// Method declaration to add new note
        /// </summary>
        /// <param name="note">note parameter</param>
        /// <returns>string message</returns>
        public string AddNewNote(NotesModel note);

        /// <summary>
        /// Method declaration to retrieve all note
        /// </summary>
        /// <returns>all notes</returns>
        public IEnumerable<NotesModel> RetrievNote();

        /// <summary>
        /// Method declaration to remove a note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string RemoveNote(int id);

        /// <summary>
        /// Method declaration to update a note
        /// </summary>
        /// <param name="note">note parameter</param>
        /// <returns>string message</returns>
        public string UpdateNote(NotesModel note);


        /// <summary>
        /// Method declaration to get a note by its Id
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public IEnumerable<NotesModel> GetNoteById(int id);

        /// <summary>
        /// Method declaration to get pinned note
        /// </summary>
        /// <returns>pinned note data</returns>
        public IEnumerable<NotesModel> GetPinnedNote();

        /// <summary>
        /// Method declaration to pin and unpin to note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string PinOrUnpinNote(int id);
    }
}
