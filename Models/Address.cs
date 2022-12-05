using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_POP2022_2.Models
{
    [Serializable]
    public class Address : ICloneable
    {
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; }

        public object Clone()
        {
            return new Address
            {
                Street = Street,
                StreetNumber = StreetNumber,
                City = City,
                Country = Country
            };
        }

        public override string ToString()
        {
            return $"{Street} {StreetNumber}, {City}, {Country}";
        }
    }
}

