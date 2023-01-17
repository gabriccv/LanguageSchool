using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Models
{
    [Serializable]
    public class Language : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        //public bool IsValid { get; set; }



        public Language()
        {
            IsDeleted = false;

        }
        public override string ToString()
        {
            return $"{Name} ";
        }
        public object Clone()
        {
            return new Language
            {
                Id = Id,
                Name = Name,

            };
        }


        public string Error
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                {
                    return "Street cannot be empty!";
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
