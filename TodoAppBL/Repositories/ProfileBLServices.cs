using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppBL.Models;
using TodoAppDAL.Models;
using TodoAppDAL.Repositories;

namespace TodoAppBL.Repositories
{
    public class ProfileBLServices : IProfileBLServices
    {
        private readonly IUserRepo _userRepo;
        public ProfileBLServices(IUserRepo _userRepo)
        {
            this._userRepo = _userRepo;
        }
        public CredentialsBL LoginUser(CredentialsBL credentials)
        {
            var mapper = AutoMapperconfig.InitializeAutomapper();
            return mapper.Map<CredentialsBL>(_userRepo.LoginUser(mapper.Map<Credential>(credentials)));
        }

        public bool RegisterUser(string name, string email, string password, string phoneNo)
        {
            if (_userRepo.RegisterUser(name, email, password, phoneNo) == 1)
                return false;
            return true;
        }

        public ProfileBL? UpdateUser(int userId, string username)
        {
            var mapper = AutoMapperconfig.InitializeAutomapper();
            return mapper.Map<ProfileBL>(_userRepo.UpdateUser(userId, username));
            //_userRepo.UpdateUser(userId, username);
        }

        public ProfileBL? GetUser(int id)
        {
            var mapper = AutoMapperconfig.InitializeAutomapper();
            return mapper.Map<ProfileBL>(_userRepo.GetProfile(id));
        }
    }
}
