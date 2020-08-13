using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
    public interface IMemberService
    {
        List<Member> GetAll();
        Member GetById(int id);
        int Add(Member record);
        int Update(Member record);

    }
}
