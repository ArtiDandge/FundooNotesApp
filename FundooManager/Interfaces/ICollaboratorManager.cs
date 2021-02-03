using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interfaces
{
    public interface ICollaboratorManager
    {
        public string AddCollaborator(CollaboratorsModel collaborators);
        public string DeleteCollaborator(int id);
        public IEnumerable<CollaboratorsModel> GetCollaborators();
    }
}
