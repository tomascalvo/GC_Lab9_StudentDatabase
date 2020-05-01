using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GC_Lab9_StudentDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            //DATA SET AS A TWO-DIMENSIONAL ARRAY
            //string[,] studentDossiers = { { "Kim", "Driscoll", "Detroit, MI", "Falafel" },
            //    { "Kim", "Wexler", "Albuqueruqe, NM", "Takeout" },
            //    { "Saul", "Goodman", "Albuquerque, NM", "Lobster" },
            //    { "Tomás", "Calvo", "Bay City, MI", "Cheddar Bay Biscuits" }, { "Cary", "Grant", "Hollywood, CA", "Chicken Almondine" }, { "Tyler", "Van Eck", "Wyoming, MI", "Shrimp Scampi" }, { "Andy", "Balash", "Auburn, MI", "Turkey Drumsticks" }, { "Michael", "Jarema", "Bay City, MI", "Tater Tots" }, { "Evan", "Doorshorst", "Kansas City, MO", "Fish Tacos" }, { "Alvaro", "Romero-Gibu", "Lima, Peru", "Avocado Toast" }, { "Colby", "Roanhorse", "Rochester, MI", "Coffee" }, { "Sofía", "Ramirez-Hernandez", "Rochester, MI", "Hamburgers" }, { "Kimmy", "Snyder", "Zeeland, MI", "Risotto" }, { "Mychal", "Hilken", "Jackson, MI", "Ham" }, { "Paul", "Clarke", "St. Augustine, FL", "Lap Song Su Chi" }, { "Kelly", "Meyer", "Luddington, MI", "Fish and Chips" }, { "Laurie", "Reeves", "Grand Rapids, MI", "Saffron Steak" }, { "Diego", "Calvo", "Bay City, MI", "Bone Broth" }, { "Salma", "Hayek", "Mexico City, MX", "Bone Broth" }, { "Laura", "Dern", "Santa Clara, CA", "Anything Jell-O" } };

            //DATA SET AS LISTS
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student(1, "Kim", "Driscoll", "Detroit, MI", "Falafel"));
            studentList.Add(new Student(2, "Kim", "Wexler", "Albuqueruqe, NM", "Takeout"));
            studentList.Add(new Student(3, "Saul", "Goodman", "Albuquerque, NM", "Lobster"));
            studentList.Add(new Student(4, "Tomás", "Calvo", "Bay City, MI", "Cheddar Bay Biscuits"));
            studentList.Add(new Student(5, "Cary", "Grant", "Hollywood, CA", "Chicken Almondine"));
            studentList.Add(new Student(6, "Tyler", "Van Eck", "Wyoming, MI", "Shrimp Scampi"));
            studentList.Add(new Student(7, "Andy", "Balash", "Auburn, MI", "Turkey Drumsticks"));
            studentList.Add(new Student(8, "Michael", "Jarema", "Bay City, MI", "Tater Tots"));
            studentList.Add(new Student(9, "Evan", "Doorshorst", "Kansas City, MO", "Fish Tacos"));
            studentList.Add(new Student(10, "Alvaro", "Romero-Gibu", "Lima, Peru", "Avocado Toast"));
            studentList.Add(new Student(11, "Colby", "Roanhorse", "Rochester, MI", "Coffee"));
            studentList.Add(new Student(12, "Sofía", "Ramirez-Hernandez", "Rochester, MI", "Hamburgers"));
            studentList.Add(new Student(13, "Kimmy", "Snyder", "Zeeland, MI", "Risotto"));
            studentList.Add(new Student(14, "Mychal", "Hilken", "Jackson, MI", "Ham"));
            studentList.Add(new Student(15, "Paul", "Clarke", "St. Augustine, FL", "Lap Song Su Chi"));
            studentList.Add(new Student(16, "Kelly", "Meyer", "Luddington, MI", "Fish and Chips"));
            studentList.Add(new Student(17, "Laurie", "Reeves", "Grand Rapids, MI", "Saffron Steak"));
            studentList.Add(new Student(18, "Diego", "Calvo", "Bay City, MI", "Bone Broth"));
            studentList.Add(new Student(19, "Salma", "Hayek", "Mexico City, MX", "Bone Broth"));
            studentList.Add(new Student(20, "Laura", "Dern", "Santa Clara, CA", "Anything Jell-O"));

            Console.Write("Welcome to our C# class.");

            bool loop = true;
            while (loop)
            {
                GetStudentInfo(FindStudentByStudentNumber(studentList));
                loop = ValidateLoop("another student");
            }

            Console.WriteLine("Thanks!");
        }

        public static Student FindStudentByStudentNumber(List<Student> studentList)
        {
            Console.WriteLine("Which student would you like to learn more about? Enter a number 1-20.");
            int studentNumber = ValidateStudentNumber();
            foreach (Student student in studentList)
            {
                if (student.StudentNumber == studentNumber)
                {
                    return student;
                }
            }
            return student;
        }

        public static int ValidateStudentNumber()
        {
        int number;
            bool isNumber = int.TryParse(Console.ReadLine().Trim(), out number);
            if (isNumber)
            {
                if (number >= 1 && number <= 20)
                {
                    return number;
                }
                else
                {
                    throw new Exception("Input is outside the required range of 1-20.");
                }
            } else
            {
                throw new Exception("Input is not a number.");
            }
        }

        public static void GetStudentInfo(Student student)
        {
            string infoType;
            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine($"What would you like to know about {student.FirstName}? Enter \"hometown\" or \"favorite food\".");
                    infoType = Console.ReadLine().ToLower().Trim();
                    if (infoType == "hometown")
                    {
                        Console.WriteLine($"{student.FirstName} is from {student.HomeTown}.");
                        loop = false;
                    }
                    else if (infoType == "favorite food")
                    {
                        Console.WriteLine($"{student.FirstName}'s favorite food is {student.FavoriteFood}.");
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter \"hometown\" or \"favorite food\".");
                    }
                }
                catch (FormatException e1)
                {
                    Console.WriteLine(e1.Message);
                }
                catch (IndexOutOfRangeException e2)
                {
                    Console.WriteLine(e2.Message);
                }
                finally
                {
                    loop = ValidateLoop(student.FirstName);
                }
            }
        }

        public static bool ValidateLoop(string topic)
        {
            Console.WriteLine($"Would you like to know more about {topic}? Enter \"yes\" or \"no\".");
            try
            {
                string response = Console.ReadLine().ToLower().Trim();
                if (response == "yes")
                {
                    return true;
                }
                else if (response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                    return false;
                }
            }
            catch (FormatException e1)
            {
                Console.WriteLine(e1.Message);
                return false;
            }
        }
    }
}
