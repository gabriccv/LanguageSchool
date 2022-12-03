using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    interface IUserRepository
    {
        List<User> GetAll();
        User GetById(string email);
        void Add(User user);
        void Add(List<User> users);
        void Set(List<User> users);
        void Update(string email, User user);
        void Delete(string email);
    }
}
