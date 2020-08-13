using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
   public interface IProfileDetailService
    {
        List<Auth> GetAllAuthByCurrentUser(int employeeId);
        List<Auth> GetAllAuthByProfileId(int profileId);
        List<Auth> GetAllAuthByProfileIdWhichIsNotIncluded(int profileId);
        int Add(ProfileDetail record);
        int DeleteByProfileIdAndAuthId(int profileId, int authId);

    }
}
