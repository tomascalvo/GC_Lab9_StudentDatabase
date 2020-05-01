using System;
using System.Collections.Generic;
using System.Text;
namespace GC_Lab9_StudentDatabase
{
    class Student
    {
        private int studentNumber;
        private string firstName;
        private string lastName;
        private string homeTown;
        private string favoriteFood;
        public int StudentNumber
        {
            get
            {
                return studentNumber;
            }
            set
            {
                studentNumber = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string HomeTown
        {
            get
            {
                return homeTown;
            }
            set
            {
                homeTown = value;
            }
        }
        public string FavoriteFood
        {
            get
            {
                return favoriteFood;
            }
            set
            {
                favoriteFood = value;
            }
        }

        public Student(int _studentNumber, string _firstName, string _lastName, string _homeTown, string _favoriteFood)
        {
            studentNumber = _studentNumber;
            firstName = _firstName;
            lastName = _lastName;
            homeTown = _homeTown;
            favoriteFood = _favoriteFood;
        }
        public Student() { }
    }
}
