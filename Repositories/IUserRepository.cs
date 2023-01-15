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
        User GetById(int id);
        int Add(User user);
        void Update(int id, User user);
        void Delete(int id);
    }
}
