using FundooManager.Interfaces;
using FundooModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class NotesController : ControllerBase
    {
        private readonly INotesManager notes;

        public NotesController(INotesManager notes)
        {
            this.notes = notes;
        }

        /// <summary>
        /// Notes Controller
        /// </summary>
        /// <param name="notes">new notes</param>
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

        [HttpGet]
        [Route("api/GetNote")]
        public IActionResult GetAllNotes()
        {
            try
            {
                IEnumerable<NotesModel> result = this.notes.RetrievNote();
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("api/DeleteNote")]
        public IActionResult RemoveEmployeeById(int id)
        {
            var result = this.notes.RemoveNote(id);
            if (result.Equals("Note Deleted Successfully"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

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
                return this.BadRequest(new { success = true, Message = "Error While updating note" });
            }
        }
    }
}
