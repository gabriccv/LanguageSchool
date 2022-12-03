using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Models
{

    [Serializable]
    class Student
    {
        [NonSerialized]
        private User user;

        public User User { get => user; set => user = value; }
        public string UserId { get; set; }

        public override string ToString()
        {
            return $"[Student] {User.FirstName} {User.LastName}, {User.Email}";
        }
    }
}
