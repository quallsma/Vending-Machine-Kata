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

        private readonly Coin quarter = new Coin() { amount = 0.25M, mass = 5.670, diameter = 24.26, thickness = 1.75};
        private readonly Coin dime = new Coin() { amount = 0.10M, mass = 2.268, diameter = 17.91, thickness = 1.35 };
        private readonly Coin nickel = new Coin() { amount = 0.05M, mass = 5.000, diameter = 21.21, thickness = 1.95 };

        private List<Coin> Coins;
        private Dictionary<string, decimal> Products = new Dictionary<string, decimal>();
        private Stack<string> Messages;

        public VendingMachine()
        {
            Coins = new List<Coin>() { quarter, dime, nickel };
            Messages = new Stack<string>();
            Products.Add("cola", 1.00M);
            Products.Add("chips", 0.50M);
            Products.Add("candy", 0.65M);
        }

        public string GetMessage()
        {
            if (Messages.Count <= 0)
                return "INSERT COIN";
            
            return Messages.Pop();
        }

        public void InsertCoin(double mass, double diameter, double thickness)
        {
            Coin coin = Coins.FirstOrDefault(m => m.mass == mass && m.diameter == diameter && m.thickness == thickness);
            if (coin != null)
            {
                RemainingBalance += coin.amount;
                Messages.Push(String.Format("{0:C}", RemainingBalance));
            }
                
        }

        public void SelectProduct(string product)
        {
            Messages.Push(String.Format("PRICE {0:C}", Products[product]));
        }
    }
}
