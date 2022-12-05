using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    interface IAddressService
    {
        List<Address> GetAll();
        Address GetById(string street);
        void Add(Address address);
        void Set(List<Address> addresses);
        void Update(string street, Address address);
        void Delete(string street);
    }
}
