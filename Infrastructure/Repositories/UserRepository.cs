using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(TUP3Context context)
        {
            _context = context;
        }
        public User? GetOne(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Name == username);
        }
        


    }
}
