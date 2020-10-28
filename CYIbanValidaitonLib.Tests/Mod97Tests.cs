using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CYIbanValidaitonLib.Tests
{
    [TestClass]
    public class Mod97Tests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("97")]
        [DataRow("194")]
        public void BigNum_Mod97_WithInputThatShouldReturn0_Succeeds(string input)
        {
            var modder = new BigNum_Mod97();
            int result = modder.Mod97(input);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("97000000000000000000000000000000")]
        [DataRow("388000000000")]
        public void BigNum_Mod97_WithBigInputThatShouldReturn0_Succeeds(string input)
        {
            var modder = new BigNum_Mod97();
            int result = modder.Mod97(input);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("97")]
        [DataRow("194")]
        public void Int32_Mod97_WithInputThatShouldReturn0_Succeeds(string input)
        {
            var modder = new Int32_Mod97();
            int result = modder.Mod97(input);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("97000000000000000000000000000000")]
        [DataRow("388000000000")]
        public void Int32_Mod97_WithBigInputThatShouldReturn0_Succeeds(string input)
        {
            var modder = new Int32_Mod97();
            int result = modder.Mod97(input);
            Assert.AreEqual(0, result);
        }
    }
}
