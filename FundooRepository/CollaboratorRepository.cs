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
        /// <returns>string message</returns>
        public string AddCollaborator(CollaboratorsModel collaborators)
        {
            try
            {
                string message;
                if (collaborators != null)
                {
                    this.userContext.Collaborators.Add(collaborators);
                    this.userContext.SaveChanges();
                    message = "New Collaborator added Successfully !";
                    return message;
                }

                message = "Failed to Add New Collaborator to Database";
                return message;
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
        /// <returns>string message</returns>
        public string DeleteCollaborator(int id)
        {
            try
            {
                var collaborator = this.userContext.Collaborators.Find(id);
                if(collaborator != null)
                {
                    this.userContext.Collaborators.Remove(collaborator);
                    this.userContext.SaveChangesAsync();
                    return "Collaborator Deleted Successfully !";
                }               

                return "Unable to delete this Collaborator.";
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
