using Microsoft.EntityFrameworkCore;
using MusicSimi.Core.Entities;
using MusicSimi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSimi.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        
    
        private readonly DataConext _dataContext;
        public UserRepository(DataConext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> GetByUserNameAsync(string userName, string Password)
        {
            return await _dataContext.Users.FirstAsync(u => u.name == userName && u.password == Password);
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _dataContext.Users.AddAsync(user);
            return user;
        }

    }
}
