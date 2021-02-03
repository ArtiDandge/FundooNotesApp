using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
    public interface ICollaborator
    {
        public string AddCollaborator(CollaboratorsModel collaborators);
        public string DeleteCollaborator(int id);
        public IEnumerable<CollaboratorsModel> GetCollaborators();
    }
}
