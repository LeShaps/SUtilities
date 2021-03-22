using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using STools.Extensions;

namespace SUtilitiesTests.Extensions
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

            SomeList.AddUnique("One");
            Assert.AreEqual(4, SomeList.Count);
            SomeList.AddUnique("Here");
            Assert.AreEqual(4, SomeList.Count);

            IntList.AddUnique(12);
            Assert.AreEqual(4, IntList.Count);
            IntList.AddUnique(5);
            Assert.AreEqual(5, IntList.Count);
        }
    }
}
