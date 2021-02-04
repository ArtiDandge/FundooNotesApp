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
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Http;
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
                var note = this.userContext.FundooNotes.Find(id);
                if(note != null)
                {
                    if(note.Is_Trash == true)
                    {
                        this.userContext.FundooNotes.Remove(note);
                        this.userContext.SaveChanges();
                        return "Note Deleted Successfully";
                    }                   
                }

                return "First trash a note then try to delete it. ";
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

        /// <summary>
        /// Method to Pin Or Unpin the Note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string PinOrUnpinNote(int id)
        {
            try
            {
                string message;
                var note = this.userContext.FundooNotes.Find(id);
                if(note != null)
                {
                    if (note.Pin == false)
                    {
                        note.Pin = true;
                        this.userContext.Entry(note).State = EntityState.Modified;
                        this.userContext.SaveChanges();
                        message = "Note Pinned";
                        return message;
                    }
                    if (note.Pin == true)
                    {
                        note.Pin = false;
                        this.userContext.Entry(note).State = EntityState.Modified;
                        this.userContext.SaveChanges();
                        message = "Note Unpinned";
                        return message;
                    }
                }
               
                return message = "Unable to pin or unpin note.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Archive or unarchive the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string ArchiveOrUnArchiveNote(int id)
        {
            try
            {
                string message;
                var note = this.userContext.FundooNotes.Find(id);
                if (note != null)
                {
                    if (note.Archieve == false)
                    {
                        note.Archieve = true;
                        this.userContext.Entry(note).State = EntityState.Modified;
                        this.userContext.SaveChanges();
                        message = "Note Archived";
                        return message;
                    }
                    if (note.Archieve == true)
                    {
                        note.Archieve = false;
                        this.userContext.Entry(note).State = EntityState.Modified;
                        this.userContext.SaveChanges();
                        message = "Note Unarchived";
                        return message;
                    }
                }

                return message = "Unable to archive or unarchive note.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to get all Archived notes
        /// </summary>
        /// <returns>all archived notes</returns>
        public IEnumerable<NotesModel> GetAllArchivedNotes()
        {
            try
            {
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> note = this.userContext.FundooNotes.Where(x=> x.Archieve == true);
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
        /// Method to Trash Or Restore Note
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>string message</returns>
        public string TrashOrRestoreNote(int id)
        {
            try
            {
                string message;
                var note = this.userContext.FundooNotes.Where(x => x.NotesId == id).SingleOrDefault();
                if (note != null)
                {
                    if (note.Is_Trash == false)
                    {
                        note.Is_Trash = true;
                        this.userContext.Entry(note).State = EntityState.Modified;
                        this.userContext.SaveChanges();
                        message = "Note Trashed";
                        return message;
                    }
                    if (note.Is_Trash == true)
                    {
                        note.Is_Trash = false;
                        this.userContext.Entry(note).State = EntityState.Modified;
                        this.userContext.SaveChanges();
                        message = "Note Restored";
                        return message;
                    }
                }

                return message = "Unable to Restore or Trash note.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to set reminder for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="reminder">reminder parameter for note</param>
        /// <returns>string message</returns>
        public string SetReminder(int id, string reminder)
        {
            try
            {
                string message;
                var note = this.userContext.FundooNotes.Find(id);
                if(note != null)
                {
                    note.Reminder = reminder;
                    this.userContext.Entry(note).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    message = "Reminder is set for this Note Successfully !";
                    return message;
                }                

                return message = "Error While setting reminder for this note";
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
                IEnumerable<NotesModel> result;
                result = this.userContext.FundooNotes.Where(x=> x.Reminder.Length > 0);
                if(result != null)
                {
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

        /// <summary>
        /// Method to set reminder for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        public string UnSetReminder(int id)
        {
            try
            {
                string message;
                var note = this.userContext.FundooNotes.Find(id);
                if (note != null)
                {
                    note.Reminder = null;
                    this.userContext.Entry(note).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    message = "You have unset Reminder this Note !";
                    return message;
                }

                return message = "Error While unsetting reminder for this note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to add color for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">color name</param>
        /// <returns>string message</returns>
        public string ChangeColor(int id, string color)
        {
            try
            {
                string message;
                var note = this.userContext.FundooNotes.Find(id);
                if (note != null)
                {
                    note.Color = color;
                    this.userContext.Entry(note).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    message = "New Color has set to this note !";
                    return message;
                }

                return message = "Error While changing color for this note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to set image as background for a note 
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="image">selected image</param>
        /// <returns>string message</returns>
        [Obsolete]
        public string AddImage(int id, IFormFile image)
        {
            try
            {
                string message;
                var note = this.userContext.FundooNotes.Find(id);
                if (note != null)
                {
                    Account account = new Account("dlxz1uigg", "781671399249553", "FCkWWrUiNxSyJH3VWXqrXf6r-uk");
                    var path = image.OpenReadStream();
                    Cloudinary cloudinary = new Cloudinary(account);
                    ImageUploadParams uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(image.FileName, path)
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    note.Image = uploadResult.Uri.AbsolutePath;
                    this.userContext.Entry(note).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    message = "Image has Added for this Note !";
                    return message;
                }

                return message = "Error While Adding image for this note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
