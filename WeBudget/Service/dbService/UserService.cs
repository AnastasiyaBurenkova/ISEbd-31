using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeCrossroad.Models;

namespace WeCrossroad.Service
{
    public class UserService
    {
        CrossroadContext db = new CrossroadContext();

        public void Create(User User) {
            db.Users.Add(User);
            db.SaveChanges();
        }

        public List<User> getList()
        {
            return db.Users.ToList();

        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}