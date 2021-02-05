using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
    public interface ICollaborator
    {
        public bool AddCollaborator(CollaboratorsModel collaborators);
        public bool DeleteCollaborator(int id);
        public IEnumerable<CollaboratorsModel> GetCollaborators();
    }
}
