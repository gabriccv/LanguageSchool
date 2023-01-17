using SR39_2021_pop2022_2.Models;
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
        List<Address> GetValidAddress();
        void Add(Address address);

        void Update(int id, Address address);
        void Delete(int id);
        Address GetById(int id);

        //List<Address> GetAll();
        
        //List<Address> GetActiveAddresses();
        //List<Address> GetActiveAddressesByCountry(string country);
        //List<Address> GetActiveAddressesOrderedByCountry();
        //void Add(Address address);
        //void Set(List<Address> addresses);
        //void Update(int id, Address address);
        //void Delete(int id);
    }
}
