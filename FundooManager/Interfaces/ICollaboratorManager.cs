using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interfaces
{
    public interface ICollaboratorManager
    {
        public bool AddCollaborator(CollaboratorsModel collaborators);
        public bool DeleteCollaborator(int id);
        public IEnumerable<CollaboratorsModel> GetCollaborators();
    }
}
