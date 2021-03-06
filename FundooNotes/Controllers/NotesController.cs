﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooManager.Interfaces;
    using FundooModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// NotesController class for Notes CRUD implementation
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// INotesManager notes parameter
        /// </summary>
        private readonly INotesManager notes;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController" /> class.
        /// </summary>
        /// <param name="notes">INotesManager notes parameter</param>
        public NotesController(INotesManager notes)
        {
            this.notes = notes;
        }

        /// <summary>
        /// API Method to add new Note to the database
        /// </summary>
        /// <param name="notes">notes parameter</param>
        /// <returns>response data</returns>
        [HttpPost]
        [Route("CreateNewNote")]
        public IActionResult Notes([FromBody] NotesModel notes)
        {
            try
            {
                var is_successed = this.notes.AddNewNote(notes);
                if (is_successed == true)
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "New Note added Successfully!", Data = notes });
                }

                return this.BadRequest(new ResponseModel<NotesModel>() { Status = false, Message = "Failed to Add New Note to Database" });
            }
            catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<NotesModel>() { Status = false, Message = ex.Message });
            }            
        }

        /// <summary>
        /// API to Retrieve all notes from database
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("RetrieveAllNotes")]
        public IActionResult GetAllNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notes.RetrievNote();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Note retrieved Successfully", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = "Unable to retrieve notes." });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// API to Delete Note from Database
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("RemoveNoteById/{id}")]
        public IActionResult RemoveNoteById(int id)
        {
            try
            {
                var result = this.notes.RemoveNote(id);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Note Deleted Successfully", Data = id });
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = "First trash a note then try to delete it. " });
            }
            catch(Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// API to Update note
        /// </summary>
        /// <param name="note">NotesModel note parameter</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("UpdateNote")]
        public IActionResult UpdateNote([FromBody] NotesModel note)
        {
            try
            {
                var result = this.notes.UpdateNote(note);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = "Note updated Successfully !", Data = note });
                }

                return this.BadRequest(new ResponseModel<NotesModel>() { Status = false, Message = "Error While updating note" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<NotesModel>() { Status = false, Message = ex.Message });
            }            
        }

        /// <summary>
        /// Controller Method to get note by its id
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>note data</returns>
        [HttpGet]
        [Route("GetNoteById")]
        public IActionResult GetNoteeById(int id)
        {
            try
            {
                var result = this.notes.GetNoteById(id);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Note Retrived Successfully", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = "Unable to Retrieve Note" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method call method PinOrUnpinNote() method to Pin Or unpin the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        [HttpPut]
        [Route("PinOrUnpinNote")]
        public IActionResult PinOrUnpinNote(int id)
        {
            try
            {
                var result = this.notes.PinOrUnpinNote(id);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method call method ArchiveOrUnArchiveNote() method to Archive Or Unarchive the note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("ArchiveOrUnArchiveNote")]
        public IActionResult ArchiveOrUnarchive(int id)
        {
            try
            {
                var result = this.notes.ArchiveOrUnArchiveNote(id);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// API to Retrieve all notes from database
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("GetAllArchivedNotes")]
        public IActionResult GetAllArchivedNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notes.GetAllArchivedNotes();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Archived Notes retrieved Successfully", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = "Unable to retrieve notes." });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method to Trash Or Restore a Note
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>string message</returns>
        [HttpPut]
        [Route("TrashOrRestoreNote")]
        public IActionResult TrashOrRestoreNote(int id)
        {
            try
            {
                var result = this.notes.TrashOrRestoreNote(id);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = result });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// API to Retrieve all notes from database
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("GetAllNotesaFromTrash")]
        public IActionResult GetAllNotesaFromTrash()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notes.GetAllNotesaFromTrash();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Archived Notes retrieved Successfully", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = "Unable to retrieve notes." });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method to set reminder for controller
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="reminder">reminder parameter for note</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("SetReminder")]
        public IActionResult SetReminder(int id, string reminder)
        {
            try
            {
                var result = this.notes.SetReminder(id, reminder);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder is set for this Note Successfully !", Data = reminder });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error While setting reminder for this note" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method to get all nots for which reminder is set
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("GetAllNotesWhosReminderIsSet")]
        public IActionResult GetNotesWithReminders()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notes.GetAllNotesWhosReminderIsSet();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Note who's reminder is set are retrieved successfully !", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = "Unable to retrieve Note who's reminder is set." });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method to get all nots for which reminder is set
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("UnsetReminder")]
        public IActionResult UnSetReminder(int id)
        {
            try
            {
                var result = this.notes.UnSetReminder(id);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "You have unset Reminder this Note !", Data = id});
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = "Error While unsetting reminder for this note" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method to add color for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="color">color name</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("AddColor")]
        public IActionResult ChangeColor(int id, string color)
        {
            try
            {
                var message = this.notes.ChangeColor(id, color);
                if (message.Equals("New Color has set to this note !"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "New Color has set to this note !", Data = color });
                }

                return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Error While changing color for this note" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method to add image for note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="image">selected image</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("AddImage")]
        public IActionResult AddImage(int id, IFormFile image)
        {
            try
            {
                var result = this.notes.AddImage(id, image);
                if (result == true)
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = "Image has Added for this Note Successfully!", Data = id});
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = "Error While Adding image for this note" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }
    }
}

