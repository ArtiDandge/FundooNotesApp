// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LableManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// --------------------------------------------------------------------------------------------------------------------

namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using FundooManager.Interfaces;
    using FundooModels;
    using FundooRepository.Interfaces;

    /// <summary>
    ///  Lable Manager class
    /// </summary>
    public class LableManager: ILableManager
    {
        /// <summary>
        /// lable field of type ILable
        /// </summary>
        private readonly ILable lable;

        /// <summary>
        /// Initializes a new instance of the <see cref="LableManager" /> class.
        /// </summary>
        /// <param name="lable">lable instance varible of type ILable</param>
        public LableManager(ILable lable)
        {
            this.lable = lable;
        }

        /// <summary>
        /// Method to create new lable
        /// </summary>
        /// <param name="lable">lable parameter</param>
        /// <returns>boolean result</returns>
        public bool CreateLable(LableModel lable)
        {
            try
            {
                bool result = this.lable.CreateLable(lable);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to retrieve lables
        /// </summary>
        /// <returns>all lables</returns>
        public IEnumerable<LableModel> RetriveLables()
        {
            try
            {
                IEnumerable<LableModel> lables = this.lable.RetriveLables();
                return lables;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        /// <summary>
        /// Method to Update lable
        /// </summary>
        /// <param name="lable">lable parameter</param>
        /// <returns>boolean result</returns>
        public bool UpdateLable(LableModel lable)
        {
            try
            {
                bool result = this.lable.UpdateLable(lable);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to delete lable
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>boolean result</returns>
        public bool DeleteLable(int id)
        {
            try
            {
                bool result = this.lable.DeleteLable(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method to get lable by id
        /// </summary>
        /// <param name="id">lable id</param>
        /// <returns>lable details</returns>
        public IEnumerable<NotesModel> GetLableById(int id)
        {
            try
            {
                var message = this.lable.GetLableById(id);
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
