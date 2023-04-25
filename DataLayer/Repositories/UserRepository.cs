using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Repositories
{
    public class UserRepository:RepositoryBase<User>
    {
        AppDbContext context;
        public UserRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public User GetUserByName(string name)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Name == name);
            return user;
        }
        public User GetUserByToken(string token)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Token == token);
            return user;
        }
    }
}
