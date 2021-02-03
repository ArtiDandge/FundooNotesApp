using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
    public interface ILable
    {
        public string CreateLable(LableModel lable);
        public IEnumerable<LableModel> RetriveLables();
        public string UpdateLable(LableModel lable);
        public string DeleteLable(int id);
        public IEnumerable<NotesModel> GetLableById(int id);
    }
}
