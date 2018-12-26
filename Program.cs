

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
        public string Name { get; set; }
        public School School { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    class Pupil : Member
    {
        public Pupil()
        {
            //Console.WriteLine("Pupil #{0} created", Count++);
        }
        public Pupil(string name, int grade, string birthday, string address, string phoneNumber)
        {
            //Console.WriteLine("Pupil #{0} created", Count++);
            Name = name;
            Grade = grade;
            Birthday = birthday;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        static public int Count { get; set; } = 0;


        public int Grade { get; set; }

    }

    enum School
    {
        Hogwarts = 0, Harvard = 1, MIT = 2
    }
    class Program
    {
        static List<Pupil> students = new List<Pupil>();

        static void Main(string[] args)
        {
            Logger.Log("Tracker started", 1, "SchoolTracker");

            PayRoll payroll = new PayRoll();
            payroll.PayAll();

            var isMoreStudents = true;

            while (isMoreStudents)
            {
                try
                { 
                    var p = new Pupil();

                    p.Name = Util.Console.Ask("Student Name: ");

                    p.School = (School) Util.Console.AskInt("School Name (Use the corresponding number):\n"
                        +"  0: Hogwarts (School of Wizardry and spells!)\n"
                        +"  1: Harvard University\n  2: MIT\n");

                    p.Grade = Util.Console.AskInt("Student Grade: ");

                    p.Birthday = Util.Console.Ask("Student Birthday (dd/mm/yy): ");

                    p.Address = Util.Console.Ask("Student Address: ");
                    
                    p.PhoneNumber = Util.Console.Ask("Student Phone Number: ");

                    students.Add(p);


                    if (Util.Console.Ask("Add another student (y/n): ") != "y")
                    {
                        isMoreStudents = false;
                    }
                }
                catch (FormatException msg)
                {
                    Console.WriteLine(msg);//this gives detailed error message
                  //   or we could use -->  Console.WriteLine(msg.Message); 
                  // for the exact message in Util --> "Input was not a number! Error Util #843-2"
                }
                catch (Exception)
                {
                    Console.WriteLine("Error Processing Student #8348-23-a-1");
                }

            }

            ShowGrade("Tom");

            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("    Student Name    | Grade | Birthday |         Address         |   Phone Number   | ");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            //   'For each' <span style='bold'>student</span> in List, students, Console.WriteLine...
            foreach (var student in students)
            {
                // formatting below lines up well in the console
                Console.WriteLine(String.Format("{0,-19} | {1,-5} | {2,-8} | {3,-23} | {4,-16} |",
                    student.Name, student.Grade, student.Birthday, student.Address, student.PhoneNumber));
            }

            Console.WriteLine("---------------------------------------------------------------------------------------");

            Exports();

            //stops the console from closing automatically
            Console.ReadLine();
        }
        static void Import()
        {
            var importedStudent = new Pupil("Jenny", 86, "birthday", "address", "123456");
            Console.WriteLine(importedStudent.Name);
        }
        
        static void Exports()
        {
            foreach (var student in students)
            {
                switch (student.School)
                {
                    case School.Hogwarts:
                        Console.WriteLine("Exporting to Hogwarts");
                        break;
                    case School.Harvard:
                        Console.WriteLine("Exporting to Harvard");
                        break;
                    case School.MIT:
                        Console.WriteLine("Exporting to MIT");
                        break;
                    
                }
            }
        }

        static void ShowGrade(string name)
        {
            var found = students.Find(student => student.Name == name);
            Console.WriteLine("{0}'s Grade: {1}", found.Name, found.Grade);
        }
        //   The above lambda in the .Find parameter does exactly the same
        // as the predicate below.
        static bool predicate(Pupil student)
        {
            return (student.Name == "Jim");     
        }
    }
}
