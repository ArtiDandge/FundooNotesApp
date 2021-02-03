// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableController.cs" company="Bridgelabz">
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
    using FundooModels;
    using FundooRepository.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// LableController class for Lable CRUD
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LableController: ControllerBase
    {
        /// <summary>
        /// lable field of type ILable
        /// </summary>
        private readonly ILable lable;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableController" /> class.
        /// </summary>
        /// <param name="lable"></param>
        public LableController(ILable lable)
        {
            this.lable = lable;
        }

        /// <summary>
        /// Controller method to Create lable
        /// </summary>
        /// <param name="lable">lable name</param>
        /// <returns>API response</returns>
        [HttpPost]
        public IActionResult CreateLable(LableModel lable)
        {
            try
            {
                var message = this.lable.CreateLable(lable);
                if (message.Equals("New Lable added Successfully !"))
                {
                    return this.Ok(new ResponseModel<LableModel>() { Status = true, Message = message, Data = lable });
                }

                return this.BadRequest(new ResponseModel<LableModel>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<LableModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Method to Retrieve all lables
        /// </summary>
        /// <returns>API Response</returns>
        [HttpGet]
        public IActionResult RetrieveAllLables()
        {
            try
            {
                var result = this.lable.RetriveLables();
                if (result !=null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<LableModel>>() { Status = true, Message = "Lables Retrieved Successfully !", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<LableModel>>() { Status = false, Message = "Unable to retrieve lables" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<LableModel>>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller Method to Update Lable 
        /// </summary>
        /// <param name="lable">lable parameter</param>
        /// <returns>API response</returns>
        [HttpPut]
        public IActionResult UpdateLable(LableModel lable)
        {
            try
            {
                var message = this.lable.UpdateLable(lable);
                if (message.Equals("Lable updated Successfully !"))
                {
                    return this.Ok(new ResponseModel<LableModel>() { Status = true, Message = message, Data = lable });
                }

                return this.BadRequest(new ResponseModel<LableModel>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<LableModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Method to delete lable
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>API response</returns>
        [HttpDelete]
        public IActionResult RemoveLable(int id)
        {
            try
            {
                var message = this.lable.DeleteLable(id);
                if (message.Equals("Lable Deleted Successfully !"))
                {
                    return this.Ok(new ResponseModel<int>() { Status = true, Message = message, Data = id });
                }

                return this.BadRequest(new ResponseModel<int>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<int>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetLableById")]
        public IActionResult GetLableById(int id)
        
        {
            try
            {
                var result = this.lable.GetLableById(id);
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Lable Retrieved", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = "Unable to Retrieve Lable" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<NotesModel>>() { Status = false, Message = ex.Message });
            }
        }
    }
}
