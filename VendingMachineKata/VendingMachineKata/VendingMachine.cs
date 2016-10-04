using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private double RemainingBalance = 0.00;

        public string GetMessage()
        {
            if (RemainingBalance > 0)
                return String.Format("{0:C}", RemainingBalance);
            return "INSERT COIN";
        }

        public void InsertCoin(double coin)
        {
            RemainingBalance += coin;
        }
    }
}
