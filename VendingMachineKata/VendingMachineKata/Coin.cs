using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{
    public class Coin
    {
        public decimal amount { get; set; }
        public double mass { get; set; }
        public double diameter { get; set; }
        public double thickness { get; set; }
        public CoinType coinType { get; set; }
    }
    public enum CoinType
    {
        Quater,
        Dime,
        Nickel
    }
}
