using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Models
{
    [Serializable]
    class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfClass { get; set; }
        public string StartOfClass { get; set; }
        public string ClassTime { get; set; }
        public EStatus Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
