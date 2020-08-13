using Library.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Business.Interfaces
{
    public interface IProfileMemberService
    {
        List<Member> GetAllMemberByProfileId(int profileId);
        List<Member> GetAllMemberWhichIsNotIncludedByProfileId(int profileId);
        List<Profile> GetAllProfileByCurrentUser(int memberId);
        List<Profile> GetAllProfileByEmployeeIdAndAuthCode(int memberId, string authCode);
        int Add(ProfileMember record);
        int DeleteByProfileIdAndEmployeeId(int profileId, int memberId);
    }
}
