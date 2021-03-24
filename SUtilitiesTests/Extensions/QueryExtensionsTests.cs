using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using STools.Extensions;

namespace SUtilitiesTests
{
    [TestClass]
    public class QueryExtensionsTests
    {
        [TestMethod]
        public void IndexesOfRawTest()
        {
            string NullString = null;

            List<string> StringList = new()
            {
                "The",
                "Quick",
                "Fox",
                "Is",
                "Quick"
            };

            List<string> NullList = null;

            List<int> StringIndexResult = StringList.IndexesOf("Quick").ToList();
            Assert.AreEqual(2, StringIndexResult.Count);
            Assert.IsTrue(StringIndexResult.Contains(1));
            Assert.IsTrue(StringIndexResult.Contains(4));
            Assert.ThrowsException<ArgumentNullException>(() => StringList.IndexesOf(NullString));
            StringIndexResult = StringList.IndexesOf("dog").ToList();
            Assert.AreEqual(0, StringIndexResult.Count);
            Assert.ThrowsException<ArgumentNullException>(() => NullList.IndexesOf("Quick"));
        }

        [TestMethod]
        public void IndexesOfPredicateTest()
        {
            List<string> StringList = new()
            {
                "The",
                "Quick",
                "Fox",
                "Is",
                "Quick",
                "Or",
                "Quicker"
            };

            List<string> NullList = null;
            Func<string, bool> predicate = null;

            List<int> StringIndexResult = StringList.IndexesOf(x => x.StartsWith('Q')).ToList();
            Assert.AreEqual(3, StringIndexResult.Count);
            StringIndexResult = StringList.IndexesOf(x => x.Length > 900).ToList();
            Assert.AreEqual(0, StringIndexResult.Count);
            Assert.ThrowsException<ArgumentNullException>(() => NullList.IndexesOf(x => x.StartsWith('Q')));
            Assert.ThrowsException<ArgumentNullException>(() => StringList.IndexesOf(predicate));
        }
    }
}
