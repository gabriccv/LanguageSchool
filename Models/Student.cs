using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Models
{

     [Serializable]
    public class Student : ICloneable
    {

        private User user;

        public User User
        {
            get => user;
            set
            {
                user = value;
                UserId = user.Email; // kada se setuje User tada se setuje i UserId, tako ne moramo kasnije da ih setujemo zasebno
            }
        }
        public string UserId { get; set; }

        public object Clone()
        {
            return new Student
            {
                User = User.Clone() as User
            };
        }

        public override string ToString()
        {
            return $"[Student] {User.FirstName} {User.LastName}, {User.Email}";
        }
    }
}
