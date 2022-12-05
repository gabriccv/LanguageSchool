using SR39_2021_POP2022_2.Models;
using SR39_2021_pop2022_2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    class AddressService : IAddressService
    {
        private AddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }
        public void Add(Address address)
        {
            addressRepository.Add(address);
        }

        public void Delete(string street)
        {
            addressRepository.Delete(street);
        }

        public List<Address> GetAll()
        {
            return addressRepository.GetAll();
        }

        public Address GetById(string street)
        {
            return addressRepository.GetById(street);
        }

        public void Set(List<Address> addresses)
        {
            addressRepository.Set(addresses);
        }

        public void Update(string street, Address address)
        {
            addressRepository.Update(street, address);
        }
    }
}
