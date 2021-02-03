using FundooManager.Interfaces;
using FundooModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollaboratorController : ControllerBase
    {

        private readonly ICollaboratorManager collaboratorManager;
        public CollaboratorController(ICollaboratorManager collaboratorManager)
        {
            this.collaboratorManager = collaboratorManager;
        }

        [HttpPost]
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

        [HttpDelete]
        [Route("{id}")]
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

        [HttpGet]
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
