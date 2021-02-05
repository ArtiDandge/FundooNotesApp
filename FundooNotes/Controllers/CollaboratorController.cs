// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorController.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------


namespace FundooNotes.Controllers
{
    using FundooManager.Interfaces;
    using FundooModels;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Controller class for api implementation for collaborators
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {

        /// <summary>
        /// Field collaboratorManager of type ICollaboratorManager
        /// </summary>
        private readonly ICollaboratorManager collaboratorManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorController" /> class.
        /// </summary>
        /// <param name="collaboratorManager">collaboratorManager of type ICollaboratorManager</param>
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        /// <summary>
        /// Controller method to add new collaborator
        /// </summary>
        /// <param name="collaboraters">collaboraters parameter</param>
        /// <returns>response data</returns>
        [HttpPost]
        [Route("AddCollaborator")]
        public IActionResult AddCollaborator(CollaboratorsModel collaboraters)
        {
            try
            {
                var message = this.collaboratorManager.AddCollaborator(collaboraters);
                if (message.Equals("New Collaborator added Successfully !"))
                {
                    return this.Ok(new ResponseModel<CollaboratorsModel>() { Status = true, Message = message, Data = collaboraters });
                }

                return this.BadRequest(new ResponseModel<CollaboratorsModel>() { Status = false, Message = message });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<CollaboratorsModel>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Controller method to Remove collaborator
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns>response data</returns>
        [HttpDelete]
        [Route("RemoveCollaborator/{id}")]
        public IActionResult RemoveCollaborator(int id)
        {
            try
            {
                var message = this.collaboratorManager.DeleteCollaborator(id);
                if (message.Equals("Collaborator Deleted Successfully !"))
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

        /// <summary>
        /// Controller method to Retrieve All Collaborator
        /// </summary>
        /// <returns>response data</returns>
        [HttpGet]
        [Route("RetrieveAllCollaborator")]
        public IActionResult RetrieveAllCollaborator()
        {
            try
            {
                var result = this.collaboratorManager.GetCollaborators();
                if (result != null)
                {
                    return this.Ok(new ResponseModel<IEnumerable<CollaboratorsModel>>() { Status = true, Message = "Collaborators Retrieved Successfully !", Data = result });
                }

                return this.BadRequest(new ResponseModel<IEnumerable<CollaboratorsModel>>() { Status = false, Message = "Unable to retrieve Collaborators" });
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<IEnumerable<CollaboratorsModel>>() { Status = false, Message = ex.Message });
            }
        }
    }
}
