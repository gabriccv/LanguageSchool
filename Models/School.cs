//using SR39_2021_POP2022_2.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SR39_2021_pop2022_2.Models
//{

//    [Serializable]
//    public class School : ICloneable
//    {
//        public int ID { get; set; }
        
//        public string Name { get; set; }
//        public Address Address { get; set; }
//        public List<string> Languages { get; set; }
//        public bool IsValid { get; set; }
//        public bool IsDeleted { get; set; }

//        public School()
//        {
//            Languages = new List<string>();
//            IsDeleted = false;
//        }

//        public object Clone()
//        {
//            return new School
//            {
//                ID = ID,
                
//                Name = Name,
//                Address = (Address)Address.Clone(),
//                Languages = new List<string>(Languages)
//            };
//        }
        

//        public override string ToString()
//            {
//                return $"{Name}";
//            }

//        public string Error
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(Name))
//                {
//                    return "Name cannot be empty!";
//                }
                


//                return "";
//            }
//        }

//        public string this[string columnName]
//        {

//            get
//            {
//                IsValid = true;
//                if (columnName == "Name" && string.IsNullOrEmpty(Name))
//                {
//                    IsValid = false;
//                    return "Name cannot be empty!";
//                }
                


//                return "";
//            }
//        }
//    }
//}
