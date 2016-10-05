using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private bool ExactChange { get; set; }

        private decimal CurrentAmount = 0.00M;

        private readonly Coin quarter = new Coin() { amount = 0.25M, mass = 5.670, diameter = 24.26, thickness = 1.75, coinType = CoinType.Quater};
        private readonly Coin dime = new Coin() { amount = 0.10M, mass = 2.268, diameter = 17.91, thickness = 1.35, coinType = CoinType.Dime };
        private readonly Coin nickel = new Coin() { amount = 0.05M, mass = 5.000, diameter = 21.21, thickness = 1.95, coinType = CoinType.Nickel };

        private Product cola = new Product() { Name = "cola", Cost = 1.00M, Quantity = 5 };
        private Product chips = new Product() { Name = "chips", Cost = 0.50M, Quantity = 5 };
        private Product candy = new Product() { Name = "candy", Cost = 0.65M, Quantity = 5 };
        private Product water = new Product() { Name = "water", Cost = 0.50M, Quantity = 0 };

        private List<Coin> Coins;
        private List<Product> Products;
        private Stack<string> Messages;

        public VendingMachine(bool exactChange = true)
        {
            ExactChange = exactChange;
            Coins = new List<Coin>() { quarter, dime, nickel };
            Messages = new Stack<string>();
            Products = new List<Product>() { cola,chips,candy,water};
        }

        public string GetMessage()
        {
            if (Messages.Count <= 0)
                return ExactChange ? "INSERT COIN" : "EXACT CHANGE ONLY";
            
            return Messages.Pop();
        }

        public void InsertCoin(double mass, double diameter, double thickness)
        {
            Coin coin = Coins.FirstOrDefault(m => m.mass == mass && m.diameter == diameter && m.thickness == thickness);
            if (coin != null)
            {
                CurrentAmount += coin.amount;
                Messages.Push(String.Format("{0:C}", CurrentAmount));
            }
                
        }

        public void SelectProduct(string name)
        {
            Product product = Products.FirstOrDefault(p => p.Name == name);
            if (product == null)
                return;

            if(product.Quantity == 0)
            {
                Messages.Push("SOLD OUT");
                return;
            }

            if (CurrentAmount >= product.Cost)
            {
                Messages.Clear();
                CurrentAmount -= product.Cost;
                Messages.Push("THANK YOU");
                return;
            }
            Messages.Push(String.Format("PRICE {0:C}", product.Cost));
        }

        public decimal GetChangeAmount()
        {
            return CurrentAmount;
        }

        public Coin[] ReturnCoins()
        {
            Messages.Clear();
            List<Coin> Change = new List<Coin>();
            foreach(var coin in Coins)
            {
                while(CurrentAmount >= coin.amount)
                {
                    Change.Add(coin);
                    CurrentAmount -= coin.amount;
                }
            }
            return Change.ToArray();
        }


    }
}
