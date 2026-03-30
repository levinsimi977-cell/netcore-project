using MusicSimi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSimi.Entities;

namespace MusicSimi.Core.Repositories
{

    public interface IUserRepository
    {
        public Task<User> GetByUserNameAsync(string UserName, string Password);
        public Task<User> AddUserAsync(User user);
    }
}



