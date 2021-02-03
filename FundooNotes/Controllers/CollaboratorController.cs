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
    }
}
