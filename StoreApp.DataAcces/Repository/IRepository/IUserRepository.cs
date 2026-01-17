using StoreApp.Models;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository.IRepository
{
    public interface IUserRepository : IRepository<ApplicationUserModel>
    {
        void Update(ApplicationUserModel userModel);
        string GetRole(ApplicationUserModel userModel);
    }
}
