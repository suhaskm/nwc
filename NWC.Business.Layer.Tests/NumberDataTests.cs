using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net;
using Moq;
using Number.Business.Layer;
using NWC.Business.Layer;

namespace Number.Business.Test
{
    [TestClass]
    public class NumberDataTests 
    {
        private static ILog _Logger;

        [TestInitialize]
        public void Initalize()
        {
            _Logger = (new Mock<ILog>()).Object;
        }

        [TestMethod]
        public void ProcessNumbers_ZeroTest_Pass()
        {
            NumberData sut = new NumberData(_Logger);
             var zero = sut.ProcessNumbers(0);
            Assert.AreEqual("ZERO DOLLAR ONLY.",zero.ToUpper());
        }

        [TestMethod]
        public void ProcessNumbers_NegativeTest_Pass()
        {
            NumberData sut = new NumberData(_Logger);
            var negative = sut.ProcessNumbers(-1);
            Assert.AreEqual("NEGATIVE ONE DOLLAR ONLY.",negative.ToUpper());
        }

        [TestMethod]
        public void ProcessNumbers_DecimalNumberTest_Pass()
        {
            NumberData sut = new NumberData(_Logger);
            var decimalNumber = sut.ProcessNumbers(123.45);
            Assert.AreEqual("ONE HUNDRED   TWENTY -THREE DOLLARS AND   FORTY -FIVE CENTS ONLY.", decimalNumber.ToUpper());
        }

        

        
    }
}
