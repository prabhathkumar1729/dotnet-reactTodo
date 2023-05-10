using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppDAL.Models;
namespace TodoAppDAL.Repositories
{
    public interface IUserRepo
    {
        int RegisterUser(string name, string email, string password, string phoneNo);
        Credential LoginUser(Credential credential);
        Profile? UpdateUser(int userId,  string username);
        Profile? GetProfile(int userId);

    }
}
