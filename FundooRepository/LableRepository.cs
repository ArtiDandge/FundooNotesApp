// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FundooModels;
    using FundooRepository.Context;
    using FundooRepository.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Class LableRepository implements ILable interface
    /// </summary>
    public class LableRepository : ILable
    {
        /// <summary>
        /// userContext field of type UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        ///  Initializes a new instance of the <see cref="LableRepository" /> class.
        /// </summary>
        /// <param name="userContext"></param>
        public LableRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        /// <summary>
        /// Method to Create/Add New Lable
        /// </summary>
        /// <param name="lable"></param>
        /// <returns></returns>
        public string CreateLable(LableModel lable)
        {
            try
            {
                string message;
                if (lable != null)
                {
                    this.userContext.Lables.Add(lable);
                    this.userContext.SaveChanges();
                    message = "New Lable added Successfully !";
                    return message;
                }

                message = "Failed to Add New Lable to Database";
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Retrieve All Lables
        /// </summary>
        /// <returns>all lables</returns>
        public IEnumerable<LableModel> RetriveLables()
        {
            try
            {
                IEnumerable<LableModel> result;
                var lables = this.userContext.Lables;
                if (lables != null)
                {
                    result = lables;
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

        /// <summary>
        /// Method to update lable
        /// </summary>
        /// <param name="lable">lable parameter</param>
        /// <returns>string message</returns>
        public string UpdateLable(LableModel lable)
        {
            try
            {
                string message;
                if (lable.LableId > 0)
                {
                    this.userContext.Entry(lable).State = EntityState.Modified;
                    this.userContext.SaveChanges();
                    message = "Lable updated Successfully !";
                    return message;
                }

                return message = "Error While updating lable";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to Delete Lable
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>string message</returns>
        public string DeleteLable(int id)
        {
            try
            {
                if (id > 0)
                {
                    var lable = this.userContext.Lables.Find(id);
                    this.userContext.Lables.Remove(lable);
                    this.userContext.SaveChangesAsync();
                    return "Lable Deleted Successfully !";
                }

                return "Unable to delete this Lable.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to get lable by its id
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>lable details</returns>
        public IEnumerable<NotesModel> GetLableById(int id)
        {
            try
            {
                IEnumerable<NotesModel> result;
                var lables = this.userContext.Lables.Find(id);                
                if (lables != null)
                {
                    var matchingLables = from lable in userContext.Lables
                                         join user in userContext.Users on lable.LableId equals user.UserId
                                         join notes in userContext.FundooNotes on lable.NoteId equals notes.NotesId
                                         where lable.Lable == lables.Lable
                                         select notes.NotesId;
                    var sdfsdf = userContext.FundooNotes.Where(x => x.Lable == lables.Lable);
                    result = sdfsdf;
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
