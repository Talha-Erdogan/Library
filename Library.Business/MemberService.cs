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
    public class MemberService : IMemberService
    {
        private IConfiguration _config;

        public MemberService(IConfiguration config)
        {
            _config = config;
        }


        public List<Member> GetAll()
        {
            List<Member> resultList = new List<Member>();
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                resultList.AddRange(dbContext.Member.AsNoTracking().ToList());
            }
            return resultList;
        }

        public Member GetById(int id)
        {
            Member result = null;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                result = dbContext.Member.Where(a => a.Id == id ).AsNoTracking().SingleOrDefault();
            }
            return result;
        }
        public Member GetByUserNameAndPassword(string userName , string password)
        {
            Member result = null;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                result = dbContext.Member.Where(a => a.UserName == userName && a.Password== password).AsNoTracking().FirstOrDefault();
            }
            return result;
        }

        public int Add(Member record)
        {
            int result = 0;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                dbContext.Entry(record).State = EntityState.Added;
                result = dbContext.SaveChanges();
            }

            return result;
        }

        public int Update(Member record)
        {
            int result = 0;
            using (AppDBContext dbContext = new AppDBContext(_config))
            {
                dbContext.Entry(record).State = EntityState.Modified;
                result = dbContext.SaveChanges();
            }
            return result;
        }

    }
}
