﻿using System;
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
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Nationality { get; set; }
        public string ImagePath { get; set; }
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
            Nationality = -1;
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
            personWithoutID.Nationality = Nationality;
            personWithoutID.ImagePath = ImagePath;

            return personWithoutID;
        }

        private bool _AddPerson()
        {
            stPersonWithoutID personWithoutID = _FillPersonStruct();
            PersonID = DVLD_DataAccess.clsPeopleData.AddPerson(personWithoutID);

            return (PersonID != -1);
        }

        //private bool _Update()
        //{
        //    return true;
        //}

        public static DataTable ListPeople()
        {
            return DVLD_DataAccess.clsPeopleData.ListPeople();
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
                //case enMode.Update:
                //    return _Update();
                default:
                    return false;
            }
        }

    }
}
