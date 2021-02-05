using FundooModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
    public interface ILable
    {
        public bool CreateLable(LableModel lable);
        public IEnumerable<LableModel> RetriveLables();
        public bool UpdateLable(LableModel lable);
        public bool DeleteLable(int id);
        public IEnumerable<NotesModel> GetLableById(int id);
    }
}
