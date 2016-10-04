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
            vendingMachine.InsertCoin();
            Assert.AreEqual("$0.25", vendingMachine.GetMessage());
        }
    }
}
