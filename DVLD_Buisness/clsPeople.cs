using System;
using System.Data;
using System.Linq;
using DVLD_DataAccess;
using DVLD_Shared;

namespace DVLD_Buisness
{
    public class clsPeople
    {
        private enum enMode { AddNew=0, Update=1 };
        private enum enGender { Male=0, Female=1}

        private int PersonID { get; set; }
        private string NationalNo { get; set; }
        private string FirstName { get; set; }
        private string SecondName { get; set; }
        private string ThirdName { get; set; }
        private string LastName { get; set; }
        private DateTime DateOfBirth { get; set; }
        private enGender Gender { get; set; }
        private string Address { get; set; }
        private string Phone { get; set; }
        private string Email { get; set; }
        private string Nationality { get; set; }
        private string ImagePath { get; set; }
        private enMode Mode { get; set; }

        public clsPeople()
        {
            PersonID = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = enGender.Male;
            Address = "";
            Phone = "";
            Email = "";
            Nationality = "";
            ImagePath = "";
            Mode = enMode.AddNew;
        }

        private clsPeople(int PersonID, stPersonWithoutID person)
        {
            this.PersonID = PersonID;
            NationalNo = person.NationalNo;
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            ThirdName = person.ThirdName;
            LastName = person.LastName;
            DateOfBirth = person.DateOfBirth;
            Gender = (enGender)person.Gender;
            Address = person.Address;
            Phone = person.Phone;
            Email = person.Email;
            Nationality = person.Nationality;
            ImagePath = person.ImagePath;
            Mode = enMode.Update;
        }

        public static DataTable listPeople()
        {
            return DVLD_DataAccess.clsPeopleData.listPeople();
        }

    }
}
