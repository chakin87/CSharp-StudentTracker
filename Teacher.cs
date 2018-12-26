using System;
using System.Collections.Generic;
using System.Text;

namespace School_Tracker
{
    class Teacher : Member, IPayee
    {
        public string Subject;
        public void Pay()
        {
            Console.WriteLine("paying teacher");
        }
    }
}
