﻿using FundooManager.Interfaces;
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

        public string AddCollaborator(CollaboratorsModel collaborator)
        {
            string message = this.collaborator.AddCollaborator(collaborator);
            return message;
        }

        public string DeleteCollaborator(int id)
        {
            string message = this.collaborator.DeleteCollaborator(id);
            return message; 
        }

        public IEnumerable<CollaboratorsModel> GetCollaborators()
        {
            IEnumerable<CollaboratorsModel> result = this.collaborator.GetCollaborators();
            return result;
        }
    }
}