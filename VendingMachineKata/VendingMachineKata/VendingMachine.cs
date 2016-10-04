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
        private readonly Coin quarter = new Coin() { amount = 0.25M, mass = 5.670, diameter = 24.26, thickness = 1.75};
        private List<Coin> coinsList;

        public VendingMachine()
        {
            coinsList = new List<Coin>() { quarter };
        }

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

        public void InsertCoin(double mass, double diameter, double thickness)
        {
            Coin coin = coinsList.FirstOrDefault(m => m.mass == mass && m.diameter == diameter && m.thickness == thickness);
            if (coin != null)
                RemainingBalance += coin.amount;
        }
    }
}
