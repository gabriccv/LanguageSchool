using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    interface IUserService
    {
        List<User> GetAll();
        List<User> GetActiveUsers();
        void Add(User user);
        void Set(List<User> users);
        void Update(string email, User user);
        void Delete(string email);
    }
}
