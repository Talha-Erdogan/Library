using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
    public interface IAuthService
    {
        List<Auth> GetAll();
        Auth GetById(int id);
        int Add(Auth record);
        int Update(Auth record);
        int Delete(int id, int deletedBy);
    }
}
