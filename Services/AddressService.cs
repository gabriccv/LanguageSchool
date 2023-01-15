using SR39_2021_pop2022_2.Models;
using SR39_2021_pop2022_2.Repositories;
using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Services
{
    class AddressService : IAddressService
    {
        private IAddressRepository addressRepository;

        public AddressService()
        {
            addressRepository = new AddressRepository();
        }
        public List<Address> GetValidAddress()
        {
            return addressRepository.GetAll().Where(p => p.IsDeleted).ToList();
        }

        public List<Address> GetAll()
        {
            return addressRepository.GetAll();
        }

        public void Add(Address address)
        {
            addressRepository.Add(address);
        }

        public void Update(int id, Address address)
        {
            addressRepository.Update(id, address);
        }
        public void Delete(int id)
        {

            addressRepository.Delete(id);
        }




        //        public AddressService() => addressRepository = new AddressRepository();

        //        public Address GetById(int id)
        //        {
        //            return addressRepository.GetById(id);
        //        }

        //        public List<Address> GetAll()
        //        {
        //            return addressRepository.GetAll();
        //        }

        //        public void Add(Address address)
        //        {
        //            addressRepository.Add(address);

        //        }

        //        public void Set(List<Address> addresses)
        //        {
        //            addressRepository.Set(addresses);
        //        }

        //        public void Update(int id, Address address)
        //        {
        //            addressRepository.Update(id, address);
        //        }

        //        public void Delete(int id)
        //        {

        //            addressRepository.Delete(id);
        //        }

        //        public List<Address> GetActiveAddresses()
        //        {
        //            return addressRepository.GetAll().Where(p => !p.IsDeleted).ToList();
        //        }

        //        public List<Address> GetActiveAddressesByCountry(string country)
        //        {
        //            return addressRepository.GetAll().Where(p => !p.IsDeleted && p.Country.Contains(country)).ToList();
        //        }

        //        public List<Address> GetActiveAddressesOrderedByCountry()
        //        {
        //            return addressRepository.GetAll().Where(p => !p.IsDeleted).OrderBy(p => p.Country).ToList();
        //        }
    }
}
