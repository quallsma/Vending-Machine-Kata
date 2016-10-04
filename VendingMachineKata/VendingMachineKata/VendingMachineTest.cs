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
        public void InsertQuarterMessage()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(0.25M);
            Assert.AreEqual("$0.25", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void InsertMultipleCoinsMessage()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(0.25M);
            vendingMachine.InsertCoin(0.10M);
            vendingMachine.InsertCoin(0.05M);
            Assert.AreEqual("$0.40", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void InsertInvalidCoinsMessage()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(0.01M);
            vendingMachine.InsertCoin(0.50M);
            Assert.AreEqual("INSERT COIN", vendingMachine.GetMessage());
        }
    }
}
