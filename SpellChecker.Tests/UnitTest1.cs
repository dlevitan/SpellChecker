using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpellChecker.Contracts;
using SpellChecker.Core;

namespace SpellChecker.Tests
{
    [TestClass]
    public class DictionaryDotComSpellCheckerTests
    {
        ISpellChecker spellChecker;

        [TestInitialize]
        public void TestFixureSetUp()
        {
            spellChecker = new DictionaryDotComSpellChecker();
        }

        [TestMethod]
        public void Check_That_FileAndServe_Is_Misspelled()
        {
            // Arrange
            string testString = "FileAndServe";

            // Act
            bool spelledRight = spellChecker.Check(testString);

            // Assert
            Assert.IsFalse(spelledRight);
        }

        [TestMethod]
        public void Check_That_South_Is_Not_Misspelled()
        {
            // Arrange
            string testString = "South";

            // Act
            bool spelledRight = spellChecker.Check(testString);

            // Assert
            Assert.IsTrue(spelledRight);
        }

    }
}
