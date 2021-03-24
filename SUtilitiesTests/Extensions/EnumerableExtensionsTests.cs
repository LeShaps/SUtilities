using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using STools.Extensions;
using System;

namespace SUtilitiesTests
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        [TestMethod]
        public void AddUniqueTest()
        {
            List<string> SomeList = new()
            {
                "Here",
                "is",
                "test"
            };

            List<int> IntList = new()
            {
                12,
                24,
                48,
                64
            };

            List<string> NullList = null;

            SomeList.AddUnique("One");
            Assert.AreEqual(4, SomeList.Count);
            SomeList.AddUnique("Here");
            Assert.AreEqual(4, SomeList.Count);

            IntList.AddUnique(12);
            Assert.AreEqual(4, IntList.Count);
            IntList.AddUnique(5);
            Assert.AreEqual(5, IntList.Count);
            Assert.ThrowsException<ArgumentNullException>(() => NullList.AddUnique("String"));
        }
    }
}
