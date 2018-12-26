using System;
using System.Collections.Generic;
using System.Text;

namespace School_Tracker
{

    class Principal : Member, IPayee
    {
        public void Pay()
        {
            Console.WriteLine("paying principal");
        }
    }
}
