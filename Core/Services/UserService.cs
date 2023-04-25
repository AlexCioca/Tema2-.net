using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public User GetUser(string name)
        {
            var user = unitOfWork.Users.GetUserByName(name);
            return user;
        }

        public User GetUserByToken(string token)
        {
            var user = unitOfWork.Users.GetUserByToken(token);
            return user;
        }
        public void UpdateUser(User user)
        {
            unitOfWork.Users.Update(user);
            unitOfWork.SaveChanges();
        }
    }
}
