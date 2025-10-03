using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User?> GetUsers()
        {
            return _userRepository.Get();
        }

        public User? GetByUser(string username) {
            return _userRepository.GetOne(username);
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }
    }
}
