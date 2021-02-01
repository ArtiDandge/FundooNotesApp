﻿using FundooModels;
using FundooRepository.Context;
using FundooRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository
{
    public class LableRepository : ILable
    {
        private readonly UserContext userContext;

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
        public IEnumerable<LableModel> GetLableById(int id)
        {
            try
            {
                IEnumerable<LableModel> result;
                var lables = this.userContext.Lables.Where(x => x.LableId == id);
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
    }
}
