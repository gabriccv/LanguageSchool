using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    interface IAddressReository
    {
        List<Address> GetAll();
        Address GetById(string street);
        void Add(Address address);
        void Add(List<Address> addresses);
        void Set(List<Address> addresses);
        void Update(string street, Address address);
        void Delete(string street);
        List<User> Search(string sting);
    }
}
