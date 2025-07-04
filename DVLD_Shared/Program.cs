﻿using System;

namespace DVLD_Shared
{
    public enum enGender { Male = 0, Female = 1 }

    public struct stPersonWithoutID
    {
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
        public string Nationality { get; set; }
        public string ImagePath { get; set; }
    }
}
