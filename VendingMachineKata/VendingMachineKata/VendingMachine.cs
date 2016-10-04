using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private decimal RemainingBalance = 0.00M;
        private decimal[] coins = { 0.25M, 0.10M, 0.05M }; 

        public string GetMessage()
        {
            if (RemainingBalance > 0)
                return String.Format("{0:C}", RemainingBalance);
            return "INSERT COIN";
        }

        public void InsertCoin(decimal coin)
        {
            if (coins.Contains(coin))
                RemainingBalance += coin;
        }
    }
}
