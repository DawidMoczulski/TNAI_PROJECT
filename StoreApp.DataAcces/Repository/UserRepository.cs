using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository
{
    public class UserRepository : Repository<ApplicationUserModel>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUserModel userModel)
        {
            _db.Users.Update(userModel);
        }

        public string GetRole(ApplicationUserModel userModel)
        {
            var userRole = _db.UserRoles.FirstOrDefault(x => x.UserId == userModel.Id);
            return userRole != null ? userRole.ToString() : "No role found";
        }
    }
}
