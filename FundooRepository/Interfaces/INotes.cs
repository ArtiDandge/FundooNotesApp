// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INotes.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooModels;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// INotes interface
    /// </summary>
    public interface INotes
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
        /// Method declaration to pin and unpin to note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string PinOrUnpinNote(int id);

        /// <summary>
        /// Method declaration to Archive Or UnArchive Note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string ArchiveOrUnArchiveNote(int id);

        /// <summary>
        /// Method declaration to get all notes which are archived
        /// </summary>
        /// <returns>archived notes</returns>
        public IEnumerable<NotesModel> GetAllArchivedNotes();


        /// <summary>
        /// Method Declaration to Trash or Restore a note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string TrashOrRestoreNote(int id);

        /// <summary>
        /// Method declaration to set reminder for perticular note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="reminder">reminder parameter for note</param>
        /// <returns>string message</returns>
        public string SetReminder(int id, string reminder);

        /// <summary>
        /// Method declaration to get all notes for which reminder has set
        /// </summary>
        /// <returns>notes for which reminder has set</returns>
        public IEnumerable<NotesModel> GetAllNotesWhosReminderIsSet();

        /// <summary>
        /// Method declaration to unset reminder for perticular note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string UnSetReminder(int id);

        /// <summary>
        /// Method declaration to add color for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">color name</param>
        /// <returns></returns>
        public string ChangeColor(int id, string color);

        /// <summary>
        /// Method to add image for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="image">selected image</param>
        /// <returns>string message</returns>
        public string AddImage(int id, IFormFile image);
    }
}
