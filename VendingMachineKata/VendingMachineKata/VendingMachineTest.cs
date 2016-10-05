using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual("$0.65", vendingMachine.GetMessage());
        }
    }
}
