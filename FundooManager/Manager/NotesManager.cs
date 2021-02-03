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
            try
            {
                IEnumerable<NotesModel> note = this.notes.RetrievNote();
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Call RemoveNote() method to remove a note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string note message</returns>
        public string RemoveNote(int id)
        {
            try
            {
                string note = this.notes.RemoveNote(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Call UpdateNote() method to update a note 
        /// </summary>
        /// <param name="note">note id</param>
        /// <returns>string message</returns>
        public string UpdateNote(NotesModel note)
        {
            try
            {
                string message = this.notes.UpdateNote(note);
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Call GetNoteById() method to remove a note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string note message</returns>
        public IEnumerable<NotesModel> GetNoteById(int id)
        {
            try
            {
                IEnumerable<NotesModel> note = this.notes.GetNoteById(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Call PinOrUnpinNote() method to Pin Or Unpin a Note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string note message</returns>
        public string PinOrUnpinNote(int id)
        {
            try
            {
                var note = this.notes.PinOrUnpinNote(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Call PinOrUnpinNote() method to Pin Or Unpin a Note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string note message</returns>
        public string ArchiveOrUnArchiveNote(int id)
        {
            try
            {
                var note = this.notes.ArchiveOrUnArchiveNote(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Trash or Restore a note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string TrashOrRestoreNote(int id)
        {
            try
            {
                var note = this.notes.TrashOrRestoreNote(id);
                return note;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method calls SetReminder() method to set reminder for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="reminder">reminder parameter for note</param>
        /// <returns>string message</returns>
        public string SetReminder(int id, string reminder)
        {
            try
            {
                string message = this.notes.SetReminder(id, reminder);
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to get all notes for which reminder has set
        /// </summary>
        /// <returns>notes for which reminder has set</returns>
        public IEnumerable<NotesModel> GetAllNotesWhosReminderIsSet()
        {
            try
            {
                IEnumerable<NotesModel> notes = this.notes.GetAllNotesWhosReminderIsSet();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to unset reminder for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string UnSetReminder(int id)
        {
            try
            {
                string message = this.notes.UnSetReminder(id);
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
