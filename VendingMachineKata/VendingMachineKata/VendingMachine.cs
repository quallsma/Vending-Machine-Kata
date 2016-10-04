using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private double amount = 0.00;

        public string GetMessage()
        {
            if (amount > 0)
                return "$" + amount.ToString();
            return "INSERT COIN";
        }

        internal void InsertCoin()
        {
            amount += 0.25;
        }
    }
}
