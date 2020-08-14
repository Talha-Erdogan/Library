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
    public class AuthService : IAuthService
    {
        private IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }


        public List<Auth> GetAll()
        {
            List<Auth> resultList = new List<Auth>();
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                resultList.AddRange(dbContext.Auth.Where(x => x.IsDeleted == false).AsNoTracking().ToList());
            }
            return resultList;
        }

        public Auth GetById(int id)
        {
            Auth result = null;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                result = dbContext.Auth.Where(a => a.Id == id && a.IsDeleted == false).AsNoTracking().SingleOrDefault();
            }

            return result;
        }

        public int Add(Auth record)
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

        public int Update(Auth record)
        {
            int result = 0;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                dbContext.Entry(record).State = EntityState.Modified;
                result = dbContext.SaveChanges();
            }

            return result;
        }

        public int Delete(int id,int deletedBy)
        {
            int result = 0;

            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                var auth = dbContext.Auth.Where(x => x.Id == id).FirstOrDefault();
                auth.IsDeleted = true;
                auth.DeletedBy = deletedBy;
                auth.DeletedDateTime = DateTime.Now;
                dbContext.Entry(auth).State = EntityState.Modified;
                result = dbContext.SaveChanges();
            }

            return result;
        }

    }
}
