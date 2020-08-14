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
    public class ProfileService : IProfileService
    {
        private IConfiguration _config;

        public ProfileService(IConfiguration config)
        {
            _config = config;
        }

      
        public List<Profile> GetAll()
        {
            List<Profile> resultList = new List<Profile>();

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var query = dbContext.Profile.Where(x => x.IsDeleted == false).AsNoTracking();
                resultList.AddRange(query.ToList());
            }
            return resultList;
        }

        public Profile GetById(int id)
        {
            Profile result = null;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                result = dbContext.Profile.Where(a => a.Id == id && a.IsDeleted == false).AsNoTracking().SingleOrDefault();
            }

            return result;
        }

        public int Add(Profile record)
        {
            int result = 0;
            record.IsDeleted = false;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                dbContext.Entry(record).State = EntityState.Added;
                result = dbContext.SaveChanges();
            }

            return result;
        }

        public int Update(Profile record)
        {
            int result = 0;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                dbContext.Entry(record).State = EntityState.Modified;
                result = dbContext.SaveChanges();
            }

            return result;
        }

        public int Delete(int id, int deletedBy)
        {
            int result = 0;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var profile = dbContext.Profile.Where(x => x.Id == id).FirstOrDefault();
                profile.IsDeleted = true;
                profile.DeletedBy = deletedBy;
                profile.DeletedDateTime = DateTime.Now;
                dbContext.Entry(profile).State = EntityState.Modified;
                result = dbContext.SaveChanges();
            }

            return result;
        }

    }
}
