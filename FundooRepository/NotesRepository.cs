// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// NotesRepository class implements INotes Interface
    /// </summary>
    public class NotesRepository : INotes
    {
        /// <summary>
        /// userContext field of type UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository" /> class.
        /// </summary>
        /// <param name="userContext">userContext parameter of type UserContext</param>
        public NotesRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Method to add/create new Note to the database
        /// </summary>
        /// <param name="note">note parameter of type NotesModel</param>
        /// <returns>string message</returns>
        public string AddNewNote(NotesModel note)
        {
            try
            {
                string message;
                if (note != null)
                {
                    this.userContext.FundooNotes.Add(note);
                    this.userContext.SaveChanges();
                    message = "New Note added Successfully !";
                    return message;
                }

                message = "Failed to Add New Note to Database"; 
                return message;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Retrieve all notes from database
        /// </summary>
        /// <returns>all notes from database</returns>
        public IEnumerable<NotesModel> RetrievNote()
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> note = this.userContext.FundooNotes;
                if (note != null)
                {
                    result = note;
                }
                else
                {
                    result = null;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        /// <summary>
        /// Method to Remove Note from Database using id
        /// </summary>
        /// <param name="id">notes integer id</param>
        /// <returns>string message</returns>
        public string RemoveNote(int id)
        {
            try
            {
                if(id > 0)
                {
                    var note = this.userContext.FundooNotes.Find(id);
                    this.userContext.FundooNotes.Remove(note);
                    this.userContext.SaveChangesAsync();
                    return "Note Deleted Successfully";
                }

                return "Unable to delete this note. Please ensure Note id Correct.";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Update Note 
        /// </summary>
        /// <param name="note">note parameter of type NotesModel</param>
        /// <returns>string message</returns>
        public string UpdateNote(NotesModel note)
        {
            try
            {
                string message;
                if (note.NotesId > 0)
                {
                    this.userContext.Entry(note).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    message = "Note updated Successfully !";
                    return message;
                }

                return message = "Error While updating note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Retrieve Note by Id 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>user note</returns>
        public IEnumerable<NotesModel> GetNoteById(int id)
        {
            try
            {
                IEnumerable<NotesModel> result;
                if (id > 0)
                {
                    var note = this.userContext.FundooNotes.Where(x => x.NotesId == id);
                    result = note;
                    return result;
                }
                result = null;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
