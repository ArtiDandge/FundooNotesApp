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
        [Route("api/newNotes")]
        public IActionResult Notes([FromBody] NotesModel notes)
        {
            var result = this.notes.AddNewNote(notes);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "New Note added Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Failed to Add New Note to Database" });
            }
        }

        /// <summary>
        /// API to Retrieve all notes from database
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("api/GetNote")]
        public IActionResult GetAllNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notes.RetrievNote();
                return this.Ok(new { success = true, Message = "Note Deleted Successfully", Data = result });
            }
            catch 
            {
                return this.BadRequest(new { success = false, Message = "Unable to delete this note. Please ensure valid note id has entered" });
            }
        }

        /// <summary>
        /// API to Delete Note from Database
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("api/DeleteNote")]
        public IActionResult RemoveEmployeeById(int id)
        {
            var result = this.notes.RemoveNote(id);
            if (result.Equals("Note Deleted Successfully"))
            {
                return this.Ok(new { success = true, Message = "Note Deleted Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Unable to delete this note. Please ensure valid note id has entered" });
            }
        }

        /// <summary>
        /// API to Update note
        /// </summary>
        /// <param name="note">NotesModel note parameter</param>
        /// <returns>response data</returns>
        [HttpPut]
        [Route("api/UpdateNote")]
        public IActionResult UpdateEmployeeDetails([FromBody] NotesModel note)
        {
            var result = this.notes.UpdateNote(note);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Note updated Successfully" });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Error While updating note" });
            }
        }
    }
}
