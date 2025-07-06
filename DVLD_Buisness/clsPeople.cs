using System;
using System.Data;
using System.Linq;
using DVLD_DataAccess;
using DVLD_Shared;

namespace DVLD_Buisness
{
    public class clsPeople
    {
        public enum enMode { AddNew=0, Update=1 };
        public enum enGender { Male=0, Female=1}

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullNmae { get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public clsCountry CountryInfo;
        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        public enMode Mode { get; set; }

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
            NationalityCountryID = -1;
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
            NationalityCountryID = person.NationalityCountryID;
            CountryInfo = clsCountry.Find(NationalityCountryID);
            ImagePath = person.ImagePath;
            Mode = enMode.Update;
        }

        private stPersonWithoutID _FillPersonStruct()
        {
            stPersonWithoutID personWithoutID = new stPersonWithoutID();

            personWithoutID.NationalNo = NationalNo;
            personWithoutID.FirstName = FirstName;
            personWithoutID.SecondName = SecondName;
            personWithoutID.ThirdName = ThirdName;
            personWithoutID.LastName = LastName;
            personWithoutID.DateOfBirth = DateOfBirth;
            personWithoutID.Gender = (DVLD_Shared.enGender)Gender;
            personWithoutID.Address = Address;
            personWithoutID.Phone = Phone;
            personWithoutID.Email = Email;
            personWithoutID.NationalityCountryID = NationalityCountryID;
            personWithoutID.ImagePath = ImagePath;

            return personWithoutID;
        }

        private bool _AddPerson()
        {
            stPersonWithoutID personWithoutID = _FillPersonStruct();
            PersonID = clsPeopleData.AddPerson(personWithoutID);

            return (PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            stPersonWithoutID personWithoutID = _FillPersonStruct();

            return clsPeopleData.UpdatePerson(PersonID, personWithoutID);
        }

        public static clsPeople Find(int PersonID)
        {
            stPersonWithoutID personWithoutID = new stPersonWithoutID();

            if (clsPeopleData.GetPersonInfoByID(PersonID, ref personWithoutID))
                return new clsPeople(PersonID, personWithoutID);
            else
                return null;
        }

        public static clsPeople Find(string PersonNationalNo)
        {
            stPersonWithoutID personWithoutID = new stPersonWithoutID();
            personWithoutID.NationalNo = PersonNationalNo;
            int PersonID = -1;

            if (clsPeopleData.GetPersonInfoByNationalNo(ref PersonID, ref personWithoutID))
                return new clsPeople(PersonID, personWithoutID);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    } else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
                default:
                    return false;
            }
        }

        public static DataTable ListPeople()
        {
            return clsPeopleData.ListPeople();
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPeopleData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string PersonNationalNo)
        {
            return clsPeopleData.IsPersonExist(PersonNationalNo);
        }
    }
}
