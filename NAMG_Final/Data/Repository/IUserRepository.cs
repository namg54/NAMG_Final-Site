using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NAMG_Final.Models;

namespace NAMG_Final.Data.Repository
{
    public interface IUserRepository
    {
        void AddUser(Users user);
        bool IsExistUserByEmail(string email);
        Users GetUserForLogin(string email, string password);
    }
}
