using CYIbanValidaitonLib.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CYIbanValidaitonLib.Tests
{
    [TestClass]
    public class CYIbanValidatorTests
    {
        const string IBAN_VALID_STRUCTURE_CORRECT_CHECKSUM = "CY7211122222ZZZZZZZZZZZZZZZZ";
        const string IBAN_VALID_STRUCTURE_INCORRECT_CHECKSUM = "CY9911122222ZZZZZZZZZZZZZZZZ";
        const string IBAN_INVALID_STRUCTURE_CORRECT_CHECKSUM = "CY57ZZZZZZZZZZZZZZZZZZZZZZZ";

        [TestMethod]
        public void CYIbanValidator_CheckIban_WithNullIban_ReturnsFalse()
        {
            CYIbanValidator validator = CreateCYIbanValidatorHelper();
            bool result = validator.CheckIban(iban: null);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CYIbanValidator_CheckIban_WithEmptyIban_ReturnsFalse()
        {
            CYIbanValidator validator = CreateCYIbanValidatorHelper();
            bool result = validator.CheckIban(iban: string.Empty);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CYIbanValidator_CheckIban_WithStructurallyValidIbanAndCorrectChecksum_ReturnsFalse()
        {
            CYIbanValidator validator = CreateCYIbanValidatorHelper();
            bool result = validator.CheckIban(IBAN_VALID_STRUCTURE_CORRECT_CHECKSUM);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void CYIbanValidator_CheckIban_WithStructurallyValidIbanAndIncorrectChecksum_ReturnsFalse()
        {
            CYIbanValidator validator = CreateCYIbanValidatorHelper();
            bool result = validator.CheckIban(IBAN_VALID_STRUCTURE_INCORRECT_CHECKSUM);
            Assert.AreEqual(false, result);
        }

        #region Helpers

        private CYIbanValidator CreateCYIbanValidatorHelper(IMod97 modder)
        {
            return new CYIbanValidator(modder);
        }

        private CYIbanValidator CreateCYIbanValidatorHelper()
        {
            return CreateCYIbanValidatorHelper(new BigNum_Mod97());
        }

        #endregion
    }
}
