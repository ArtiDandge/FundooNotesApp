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
        /// <param name="lable">lable parameter</param>
        /// <returns>boolean result</returns>
        public bool CreateLable(LableModel lable)
        {
            try
            {
                bool result;
                if (lable != null)
                {
                    this.userContext.Lables.Add(lable);
                    this.userContext.SaveChanges();
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
        /// <returns>boolean result</returns>
        public bool UpdateLable(LableModel lable)
        {
            try
            {
                bool result;
                if (lable.LableId > 0)
                {
                    this.userContext.Entry(lable).State = EntityState.Modified;
                    this.userContext.SaveChanges();
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
        /// Method to Delete Lable
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>boolean result</returns>
        public bool DeleteLable(int id)
        {
            try
            {
                bool result;
                var lable = this.userContext.Lables.Where(x => x.LableId == id).SingleOrDefault();
                if(lable != null)
                {
                    this.userContext.Lables.Remove(lable);
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
        /// Method to get lable by its id
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>lable details</returns>
        public IEnumerable<NotesModel> GetLableById(int id)
        {
            try
            {
                IEnumerable<NotesModel> result;
                var lable = this.userContext.Lables.Where(x => x.LableId == id).SingleOrDefault();                
                if (lable != null)
                {
                    var matchingLables = from newlable in userContext.Lables
                                         join user in userContext.Users on lable.LableId equals user.UserId
                                         join notes in userContext.FundooNotes on lable.NoteId equals notes.NotesId
                                         where lable.Lable == lable.Lable
                                         select notes.NotesId;
                    var lables = userContext.FundooNotes.Where(x => x.Lable == lable.Lable);
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
    }
}
