using FundooManager.Interfaces;
using FundooModels;
using FundooRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class LableManager: ILableManager
    {
        private readonly ILable lable;

        public LableManager(ILable lable)
        {
            this.lable = lable;
        }

        public string CreateLable(LableModel lable)
        {     
            string message = this.lable.CreateLable(lable);
            return message;
        }

        public IEnumerable<LableModel> RetriveLables()
        {
            IEnumerable<LableModel> lables = this.lable.RetriveLables();
            return lables;
        }

        public string UpdateLable(LableModel lable)
        {
            string message = this.lable.UpdateLable(lable);
            return message;
        }
    }
}
