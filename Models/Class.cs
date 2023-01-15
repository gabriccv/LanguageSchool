using SR39_2021_pop2022_2.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SR39_2021_pop2022_2.Models
{
    [Serializable]

    public class Class : ICloneable, IDataErrorInfo
    {


        public int Id { get; set; }
        public string Name { get; set;}
        public String DateOfClass { get; set; }
        public String StartOfClass { get; set; }
        public String ClassTime { get; set; }
        public EStatus Status { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsValid { get; set; }
        private Professor professor;
        public Professor Professor
        {
            get => professor;
            set
            {
                professor = value;
                ProfessorId = professor?.Id;
            }
        }
        public int? ProfessorId { get; set; }

        private Student student;
        public Student Student
        {
            get => student;
            set
            {
                student = value;
                StudentId = student?.Id;
            }
        }
        public int? StudentId { get; set; }


        public Class()
            {
                IsDeleted = false;
                Status = EStatus.SOLOBODAN;
            }

         public override string ToString()
            {
                return $"[Class] {Name} {Professor}, {Student}, {DateOfClass}, {StartOfClass}, {ClassTime}";
            }

        public object Clone()
        {
            return new Class
            {
                Id = Id,
                Name = Name,
                Professor = Professor?.Clone() as Professor,
                Student = Student?.Clone() as Student,
                DateOfClass = DateOfClass,
                StartOfClass = StartOfClass,
                ClassTime = ClassTime,
                IsValid = IsValid,
                IsDeleted = IsDeleted,
            };
        }
        public string Error
        {
            get
            {
                
                 if (string.IsNullOrEmpty(Name))
                {
                    return "Password cannot be empty!";
                }
                else if (string.IsNullOrEmpty(DateOfClass))
                {
                    return "First name cannot be empty!";
                }
                else if (string.IsNullOrEmpty(StartOfClass))
                {
                    return "Last name cannot be empty!";
                }
                else if (string.IsNullOrEmpty(ClassTime))
                {
                    return "JMBG cannot be empty!";
                }

                return "";
            }
        }

        public string this[string columnName]
        {

            get
            {
                IsValid = true;
                if (columnName == "Name" && string.IsNullOrEmpty(Name))
                {
                    IsValid = false;
                    return "Name cannot be empty!";
                }
                else if (columnName == "DateOfClass" && string.IsNullOrEmpty(DateOfClass))
                {
                    IsValid = false;
                    return "Date of class cannot be empty!";
                }
                else if (columnName == "StartOfClass" && string.IsNullOrEmpty(StartOfClass))
                {
                    IsValid = false;
                    return "Start of class cannot be empty!";
                }
                else if (columnName == "ClassTime" && string.IsNullOrEmpty(ClassTime))
                {
                    IsValid = false;
                    return "Class time name cannot be empty!";
                }
                

                return ""; 
            }
        }



    }
}
