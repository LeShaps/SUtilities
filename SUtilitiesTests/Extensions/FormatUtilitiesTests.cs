using Microsoft.VisualStudio.TestTools.UnitTesting;

using STools.Extensions;
using System;

namespace SUtilitiesTests
{
    [TestClass]
    public class FormatUtilitiesTests
    {
        [TestMethod]
        public void TrailingCharactersTests()
        {
            int TestNb = 100;
            Assert.AreEqual("00100", TestNb.TrailingCharacters('0', 5));
            Assert.AreEqual("100", TestNb.TrailingCharacters('0', 2));
            TestNb = -100;
            Assert.ThrowsException<ArgumentException>(() => TestNb.TrailingCharacters('0', 5));
        }

        [TestMethod]
        public void StandardUppercaseTests()
        {
            string Basestring = "quick fox";
            string NullString = null;

            Assert.AreEqual("Quick fox", Basestring.StandardUppercase());
            Assert.ThrowsException<ArgumentNullException>(() => NullString.StandardUppercase());
            Basestring = "Quick fox";
            Assert.AreEqual("Quick fox", Basestring.StandardUppercase());
            Basestring = "QUick fOx";
            Assert.AreEqual("Quick fox", Basestring.StandardUppercase());
        }
    }
}