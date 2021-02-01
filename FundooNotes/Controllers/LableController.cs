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
    }
}
