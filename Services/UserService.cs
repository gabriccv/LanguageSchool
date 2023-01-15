using SR39_2021_POP2022_2.Models;
//using SR39_2021_pop2022_2.Repositories
using SR39_2021_pop2022_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    class UserService : IUserService
    {
        private IUserRepository repostory;

        public UserService()
        {
            repostory = new UserRepository();
        }

        public List<User> GetActiveUsers()
        {
            return repostory.GetAll().Where(p => p.IsActive).ToList();
        }

        public List<User> GetAll()
        {
            return repostory.GetAll();
        }

        public void Add(User user)
        {
            repostory.Add(user);
        }

        public void Update(int id, User user)
        {
            repostory.Update(id, user);
        }

        public void Delete(int id)
        {
            repostory.Delete(id);
        }
    }
    //class UserService : IUserService
    //{
    //    private IUserRepository repostory;

    //    public UserService()
    //    {
    //        repostory = new UserRepository();
    //    }

    //    public List<User> GetActiveUsers()
    //    {
    //        return repostory.GetAll().Where(p => p.IsActive).ToList();
    //    }

    //    public List<User> GetAll()
    //    {
    //        return repostory.GetAll();
    //    }

    //    public void Add(User user)
    //    {
    //        repostory.Add(user);
    //    }

    //    public void Update(int id, User user)
    //    {
    //        repostory.Update(id, user);
    //    }

    //    public void Delete(int id)
    //    {
    //        repostory.Delete(id);
    //    }
    //}
}
