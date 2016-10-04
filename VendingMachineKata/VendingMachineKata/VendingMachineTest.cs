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
    }
}
