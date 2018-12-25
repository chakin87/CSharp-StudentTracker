

//              Challenge: Student Manager
//  1. Get student name and grade from console input
//  2. Able to handle any number of students
//  3. Display all students names and grades once the user finishes adding students
//  4. Use a list instead of an array so that additional students can be added at any time
//  5. Gather more information about student and display info in console, neatly formatted


using System;
using System.Collections.Generic;

namespace School_Tracker
{
    //  I create a Pupil class to carry info of students

    // more info variables could be added to Pupil struct 
    // to add more details about each Pupil
    class Member
    {
        public string Name;
        
        public string Birthday;
        public string Address;
        protected string phoneNumber;
    }
    class Pupil : Member
    {
        public Pupil()
        {
            Console.WriteLine("Pupil #{0} created", Count++);
        }
        public Pupil(string name, int grade, string birthday, string address, string phoneNumber)
        {
            Console.WriteLine("Pupil #{0} created", Count++);
            Name = name;
            Grade = grade;
            Birthday = birthday;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        static public int Count = 0;


        public int Grade;
        //  below is a "Property" a way to set private variable
        // without using a setter function. (Replaces setter function)
        public string PhoneNumber
        {
            set { phoneNumber = value; }
        }
        // setter function (not needed)
        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public string GetPhoneNumber()
        {
            return phoneNumber;
        }


    }
    class Teacher : Member
    {
        public string PhoneNumber
        {
            set { phoneNumber = value; }
        }
        public string GetPhoneNumber()
        {
            return phoneNumber;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Pupil>();
            var isMoreStudents = true;

            while (isMoreStudents)
            {
                var p = new Pupil();

                //   Using Util.Console.Ask, we cut the lines of code
                // in half.
                p.Name = Util.Console.Ask("Student Name: ");

                p.Grade = int.Parse(Util.Console.Ask("Student Grade: "));

                p.Birthday = Util.Console.Ask("Student Birthday (dd/mm/yy): ");

                p.Address = Util.Console.Ask("Student Address: ");
                
                p.SetPhoneNumber(Util.Console.Ask("Student Phone Number: "));

                students.Add(p);

                if (Util.Console.Ask("Add another student (y/n): ") != "y")
                {
                    isMoreStudents = false;
                }

            }

            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("    Student Name    | Grade | Birthday |         Address         |   Phone Number   | ");
            Console.WriteLine("--------------------------------------------------------------------------------------");

            //   'For each' <span style='bold'>student</span> in List, students, Console.WriteLine...
            foreach (var student in students)
            {
                // formatting below lines up well in the console
                Console.WriteLine(String.Format("{0,-19} | {1,-5} | {2,-8} | {3,-23} | {4,-16} |",
                    student.Name, student.Grade, student.Birthday, student.Address, student.GetPhoneNumber()));
            }

            Console.WriteLine("--------------------------------------------------------------------------------------");

            //stops the console from closing automatically
            Console.ReadLine();
        }
        static void Import()
        {
            var importedStudent = new Pupil("Jenny", 86, "birthday", "address", "123456");
            Console.WriteLine(importedStudent.Name);
        }
    }
}
