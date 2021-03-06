﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineKata
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void DisplayInitialMessage()
        {
            VendingMachine vendingMachine = new VendingMachine();
            Assert.AreEqual("INSERT COIN", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void InsertCoinByWeightAndSizeMessage()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            Assert.AreEqual("$0.25", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void InsertInvalidCoinByWeightAndSizeMessage()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(4.670, 24.26, 1.75);
            Assert.AreEqual("INSERT COIN", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void InsertMultipleCoinsByWeightAndSizeMessage()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.InsertCoin(2.268, 17.91, 1.35);
            vendingMachine.InsertCoin(5.000, 21.21, 1.95);
            Assert.AreEqual("$0.40", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void SelectProductWithNoMoneyInserted()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct("candy");
            Assert.AreEqual("PRICE $0.65", vendingMachine.GetMessage());
            Assert.AreEqual("INSERT COIN", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void SelectProductWithNotEnoughMoneyInserted()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.SelectProduct("cola");
            Assert.AreEqual("PRICE $1.00", vendingMachine.GetMessage());
            Assert.AreEqual("$0.25", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void PurchaseProduct()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.SelectProduct("chips");
            Assert.AreEqual("THANK YOU", vendingMachine.GetMessage());
            Assert.AreEqual("INSERT COIN", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void MakeChange()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.SelectProduct("candy");
            
            Assert.AreEqual("THANK YOU", vendingMachine.GetMessage());
            Assert.AreEqual(0.10M, vendingMachine.GetChangeAmount());
            var ChangeArray = vendingMachine.ReturnCoins();
            Assert.AreEqual(CoinType.Dime, ChangeArray[0].coinType);
            Assert.AreEqual("INSERT COIN", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void ReturnCoinsNoPurchase()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.InsertCoin(5.670, 24.26, 1.75);
            vendingMachine.InsertCoin(2.268, 17.91, 1.35);
            vendingMachine.InsertCoin(5.000, 21.21, 1.95);

            Assert.AreEqual("$0.65", vendingMachine.GetMessage());

            var ChangeArray = vendingMachine.ReturnCoins();

            Assert.AreEqual(CoinType.Quater, ChangeArray[0].coinType);
            Assert.AreEqual(CoinType.Quater, ChangeArray[1].coinType);
            Assert.AreEqual(CoinType.Dime, ChangeArray[2].coinType);
            Assert.AreEqual(CoinType.Nickel, ChangeArray[3].coinType);

            Assert.AreEqual("INSERT COIN", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void SoldOutProducts()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.SelectProduct("water");
            Assert.AreEqual("SOLD OUT", vendingMachine.GetMessage());
            Assert.AreEqual("INSERT COIN", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void ExactChangeOnly()
        {
            VendingMachine vendingMachine = new VendingMachine(false);
            Assert.AreEqual("EXACT CHANGE ONLY", vendingMachine.GetMessage());
        }
    }
}
