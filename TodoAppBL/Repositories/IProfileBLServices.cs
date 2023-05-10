using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppBL.Models;
using TodoAppDAL.Models;

namespace TodoAppBL.Repositories
{
    public interface IProfileBLServices
    {
        bool RegisterUser(string name, string email, string password, string phoneNo);
        CredentialsBL LoginUser(CredentialsBL cred);
        ProfileBL? UpdateUser(int userId, string username);
        ProfileBL? GetUser(int userId);
    }
}
