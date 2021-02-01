// --------------------------------------------------------------------------------------------------------------------
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
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// NotesController class for Notes CRUD implementation
    /// </summary>
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
        public IActionResult Notes([FromBody] NotesModel notes)
        {
            try
            {
                var message = this.notes.AddNewNote(notes);
                if (message.Equals("New Note added Successfully !"))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = message, Data = notes });
                }

                return this.BadRequest(new ResponseModel<NotesModel>() { Status = false, Message = message });
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
        public IActionResult RemoveNoteById(int id)
        {
            try
            {
                var message = this.notes.RemoveNote(id);
                if (message.Equals("Note Deleted Successfully !"))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = message, Data = id });
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = message });
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
        public IActionResult UpdateNote([FromBody] NotesModel note)
        {
            try
            {
                var message = this.notes.UpdateNote(note);
                if (message.Equals("Note updated Successfully !"))
                {
                    return this.Ok(new ResponseModel<NotesModel>() { Status = true, Message = message, Data = note });
                }

                return this.BadRequest(new ResponseModel<NotesModel>() { Status = false, Message = message });
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
        /// <param name="id"></param>
        /// <returns></returns>
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
    }
}
