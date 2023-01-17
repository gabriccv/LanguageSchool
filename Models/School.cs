using SR39_2021_POP2022_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Models
{

    [Serializable]
    public class School : ICloneable
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        //public bool IsValid { get; set; }
        public bool IsDeleted { get; set; }

        private Address address;

        public Address Address
        {
            get => address;
            set
            {
                address = value;
                AddressId = address?.Id;
            }
        }

        public int? AddressId { get; set; }

        private Language language;

        public Language Language
        {
            get => language;
            set
            {
                language = value;
                LanguageId = address?.Id;
            }
        }

        public int? LanguageId { get; set; }

        public School()
        {
            
            IsDeleted = false;
        }

       


        public override string ToString()
        {
            return $"{Name}";
        }

        public object Clone()
        {
            return new School
            {
                Id = Id,

                Name = Name,
                Address = (Address)Address.Clone(),
                Language = (Language)Language.Clone(),
                IsDeleted=IsDeleted
            };
        }

        public string Error
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return "Name cannot be empty!";
                }



                return "";
            }
        }

        //public string this[string columnName]
        //{

        //    get
        //    {
        //        IsValid = true;
        //        if (columnName == "Name" && string.IsNullOrEmpty(Name))
        //        {
        //            IsValid = false;
        //            return "Name cannot be empty!";
        //        }



        //        return "";
        //    }
        //}
    }
}
