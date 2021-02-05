using FundooManager.Interfaces;
using FundooModels;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaborator collaborator;

        public CollaboratorManager(ICollaborator collaborator)
        {
            this.collaborator = collaborator;
        }

        public bool AddCollaborator(CollaboratorsModel collaborator)
        {
            bool result = this.collaborator.AddCollaborator(collaborator);
            return result;
        }

        public bool DeleteCollaborator(int id)
        {
            bool result = this.collaborator.DeleteCollaborator(id);
            return result; 
        }

        public IEnumerable<CollaboratorsModel> GetCollaborators()
        {
            IEnumerable<CollaboratorsModel> result = this.collaborator.GetCollaborators();
            return result;
        }
    }
}
