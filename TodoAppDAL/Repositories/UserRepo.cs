using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using TodoAppDAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TodoAppDAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly TodoDbContext context;
        public UserRepo(TodoDbContext context)
        {
            this.context = context;
        }
        public Profile? GetProfile(int userId)
        {
            return context.Profiles.Find(userId);
        }

        public  Credential LoginUser(Credential credential)
        {
            return context.Credentials.Where(u => u.UserEmail == credential.UserEmail && u.UserPass == credential.UserPass).FirstOrDefault();
            //Credential cred = context.Credentials.Where(x=>x.UserEmail== credential.UserEmail && x.UserPass== credential.UserPass).FirstOrDefault();
            ////if (cred is null)
            ////    return false;
            ////return true;
            //return cred;
        }

        public int RegisterUser(string name, string email, string password, string phoneNo)
        {
            int result;
            result = context.Database.ExecuteSqlRaw("EXEC RegisterUser @Email, @Password, @Name, @PhoneNo;",
                 new[]
                 {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@Name", name),
                    new SqlParameter("@PhoneNo", phoneNo)
                 });


            return result;
        }

        public Profile? UpdateUser(int userId, string username)
        {
            Profile existingUser = GetProfile(userId);

            if (existingUser != null)
            {
                existingUser.Name = username;
                context.SaveChanges();
            }
            return existingUser;
        }
    }
}
