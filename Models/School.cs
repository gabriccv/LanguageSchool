using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Models
{
    [Serializable]
    class School
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public bool IsDeleted { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
