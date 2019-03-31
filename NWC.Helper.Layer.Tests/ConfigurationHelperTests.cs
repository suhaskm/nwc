using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NWC.Helper.Layer.Tests
{
    [TestClass]
    public class ConfigurationHelperTests
    {
        [TestMethod]
        public void GetConfigurations_Pass()
        {
            var sut = ConfigurationHelper.GetConfigurations("AllowNegative");
            Assert.AreEqual(sut, "true");
        }

        [TestMethod]
        public void GetConfigurations_Fail()
        {
            var sut = ConfigurationHelper.GetConfigurations("NoSuchKey");
            Assert.AreEqual(sut, string.Empty);
        }
    }
}
