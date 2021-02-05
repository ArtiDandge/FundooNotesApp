using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository
{
    public class CollaboratorRepository : ICollaborator
    {
        private readonly UserContext userContext;

        public CollaboratorRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Method to Add collaborators to note
        /// </summary>
        /// <param name="collaborators"></param>
        /// <returns>boolean result</returns>
        public bool AddCollaborator(CollaboratorsModel collaborators)
        {
            try
            {
                bool result;
                if (collaborators != null)
                {
                    this.userContext.Collaborators.Add(collaborators);
                    this.userContext.SaveChanges();
                    result = true;
                    return result; ;
                }

                result = false;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Remove collaborator
        /// </summary>
        /// <param name="id">collaborator id</param>
        /// <returns>boolean result</returns>
        public bool DeleteCollaborator(int id)
        {
            try
            {
                bool result;
                var collaborator = this.userContext.Collaborators.Find(id);
                if(collaborator != null)
                {
                    this.userContext.Collaborators.Remove(collaborator);
                    this.userContext.SaveChangesAsync();
                    result = true;
                    return result;
                }

                result = false;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Retrieve All collaborators
        /// </summary>
        /// <returns>existing collaborators</returns>
        public IEnumerable<CollaboratorsModel> GetCollaborators()
        {
            try
            {
                IEnumerable<CollaboratorsModel> result;
                var collaborators = this.userContext.Collaborators;
                if (collaborators != null)
                {
                    result = collaborators;
                    return result;
                }

                result = null;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
