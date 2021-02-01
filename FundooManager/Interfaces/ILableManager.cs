using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interfaces
{
    public interface ILableManager
    {
        public string CreateLable(LableModel lable);
        public IEnumerable<LableModel> RetriveLables();
        public string UpdateLable(LableModel lable);
        public string DeleteLable(int id);
        public IEnumerable<LableModel> GetLableById(int id);
    }
}
