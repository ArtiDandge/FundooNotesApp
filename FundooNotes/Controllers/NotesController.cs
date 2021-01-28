﻿using FundooManager.Interfaces;
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
        public IActionResult GetAllEmployee()
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
    }
}
