using Library.Business.Interfaces;
using Library.Data;
using Library.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Business
{
    public class ProfileMemberService : IProfileMemberService
    {
        private IConfiguration _config;

        public ProfileMemberService(IConfiguration config)
        {
            _config = config;
        }

        public List<Member> GetAllMemberByProfileId(int profileId)
        {
            List<Member> resultList = null;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var query = from pe in dbContext.ProfileMember
                            join m in dbContext.Member on pe.MemberId equals m.Id
                            where pe.ProfileId == profileId
                            select m;
                // asnotracking
                query = query.AsNoTracking();
                query = query.OrderBy(r => r.Name);
                resultList = query.ToList();
            }
            return resultList;
        }
        public List<Member> GetAllMemberWhichIsNotIncludedByProfileId(int profileId)
        {
            List<Member> resultList = null;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var queryIdList = dbContext.ProfileMember.Where(x => x.ProfileId == profileId).AsNoTracking().Select(x => x.MemberId);

                var query = from m in dbContext.Member
                            where !queryIdList.Contains(m.Id)
                            select m;
                // asnotracking
                query = query.AsNoTracking();
                query = query.OrderBy(r => r.Name);
                resultList = query.ToList();
            }
            return resultList;
        }
        public List<Profile> GetAllProfileByCurrentUser(int memberId)
        {
            List<Profile> resultList = new List<Profile>();

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var query = from pe in dbContext.ProfileMember
                            join p in dbContext.Profile on pe.ProfileId equals p.Id
                            where
                                pe.MemberId == memberId && p.IsDeleted == false
                            select p;

                // as no tracking
                query = query.AsNoTracking();

                resultList.AddRange(query.ToList());

            }
            return resultList;
        }
        public List<Profile> GetAllProfileByEmployeeIdAndAuthCode(int memberId, string authCode)
        {
            List<Profile> resultList = new List<Profile>();
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var query = from pe in dbContext.ProfileMember
                            join p in dbContext.Profile on pe.ProfileId equals p.Id
                            join pd in dbContext.ProfileDetail on pe.ProfileId equals pd.ProfileId
                            join a in dbContext.Auth on pd.AuthId equals a.Id
                            where pe.MemberId == memberId && a.Code == authCode && p.IsDeleted == false && a.IsDeleted == false
                            select new Profile()
                            {
                                Code = p.Code,
                                DeletedBy = p.DeletedBy,
                                DeletedDateTime = p.DeletedDateTime,
                                Id = p.Id,
                                IsDeleted = p.IsDeleted,
                                Name = p.Name
                            };

                // as no tracking
                query = query.AsNoTracking();

                resultList.AddRange(query.ToList());

            }


            return resultList;
        }
        public int Add(ProfileMember record)
        {
            int result = 0;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                ProfileMember existrecord = dbContext.ProfileMember.Where(pd => pd.ProfileId == record.ProfileId && pd.MemberId == record.MemberId).FirstOrDefault();
                if (existrecord == null)
                {
                    dbContext.Entry(record).State = EntityState.Added;
                    result = dbContext.SaveChanges();
                }
            }

            return result;
        }
        public int DeleteByProfileIdAndEmployeeId(int profileId, int memberId)
        {
            int result = 0;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                ProfileMember record = dbContext.ProfileMember.Where(pd => pd.ProfileId == profileId && pd.MemberId == memberId).AsNoTracking().SingleOrDefault();
                dbContext.Entry(record).State = EntityState.Deleted;
                result = dbContext.SaveChanges();
            }

            return result;
        }

    }
}
