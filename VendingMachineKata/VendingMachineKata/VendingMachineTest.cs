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
            vendingMachine.InsertCoin(0.25);
            Assert.AreEqual("$0.25", vendingMachine.GetMessage());
        }

        [TestMethod]
        public void InsertMultipleCoinsMessage()
        {
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(0.25);
            vendingMachine.InsertCoin(0.10);
            vendingMachine.InsertCoin(0.05);
            Assert.AreEqual("$0.40", vendingMachine.GetMessage());
        }
    }
}
