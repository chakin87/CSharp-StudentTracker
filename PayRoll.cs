using System;
using System.Collections.Generic;
using System.Text;

namespace School_Tracker
{
    interface IPayee
    {
        void Pay();
    }
    class PayRoll
    {
        public PayRoll()
        {
            payees.Add(new Teacher());
            payees.Add(new Teacher());
            payees.Add(new Principal());
        }

        List<IPayee> payees = new List<IPayee>();

        public void PayAll()
        {
            foreach (var payee in payees)
            {
                payee.Pay();
            }
        }
    }
}
