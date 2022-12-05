using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Repositories
{
    class AddressRepository : IAddressReository, IFilePersistence
    {
        private static List<Address> listaddresses = new List<Address>();

        public void Add(Address address)
        {
            listaddresses.Add(address);
            Save();
        }
        public void Add(List<Address> addresses)
        {
            listaddresses.AddRange(addresses);
            Save();
        }
        public void Set(List<Address> addresses)
        {
            listaddresses = addresses;
        }

        public void Delete(string street)
        {
            Address address = GetById(street);

            if (address != null)
            {
                address.IsDeleted = true;
                //listaddresses.Remove(address);
            }
            Save();
        }

        public List<Address> GetAll()
        {
            return listaddresses;
        }

        public Address GetById(string street)
        {
            return listaddresses.Find(a => a.Street == street);
        }

        public void Update(string street, Address address)
        {
            Save();
        }
        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(Config.addressesFilePath, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, listaddresses);
            }
        }
        public List<User> Search(string sting)
        {
            throw new NotImplementedException();
        }

    }
}
