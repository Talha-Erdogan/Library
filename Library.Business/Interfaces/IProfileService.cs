using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
    public interface IProfileService
    {
        List<Profile> GetAll();
        Profile GetById(int id);
        int Add(Profile record);
        int Update(Profile record);
        int Delete(int id, int deletedBy);
    }
}
