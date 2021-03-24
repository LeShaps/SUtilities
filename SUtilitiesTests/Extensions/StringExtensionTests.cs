using Microsoft.VisualStudio.TestTools.UnitTesting;
using STools.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SUtilitiesTests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void ToWordOnlyTests()
        {
            string CompletePhrase = "123HereI%Am";
            string EmptyPhrase = "";

            Assert.AreEqual("HereIAm", CompletePhrase.ToWordOnly());
            Assert.ThrowsException<ArgumentException>(() => EmptyPhrase.ToWordOnly());
        }

        [TestMethod]
        public void CutInPartsTests()
        {
            string SplitableSentence = "For all that I know, I could just let this test run, I don't think there will be any problems";
            string BuggySentence = null;

            Assert.ThrowsException<ArgumentNullException>(() => SplitableSentence.CutInParts(null, 50));
            Assert.ThrowsException<ArgumentNullException>(() => BuggySentence.CutInParts(" ", 50));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => SplitableSentence.CutInParts(" ", -1));

            List<string> SplitedSentence = SplitableSentence.CutInParts(" ", 50).ToList();
            Assert.IsTrue(SplitedSentence.Count == 2);
            Assert.AreEqual("For all that I know, I could just let this test", SplitedSentence[0]);
            Assert.AreEqual("run, I don't think there will be any problems", SplitedSentence[1]);
        }

        [TestMethod]
        public void ContainsTests()
        {
            string TestSentence = "This sentence could contains anything but not everyone";
            string BuggySentence = null;
            Assert.IsTrue(TestSentence.Contains("This", "but", " "));
            Assert.IsFalse(TestSentence.Contains("nothing", "no one"));
            Assert.ThrowsException<ArgumentNullException>(() => BuggySentence.Contains("nothing", "no one"));
        }

        [TestMethod]
        public void ToReplaceTests()
        {
            string ToReplace = "This sentence contains 77some things to 3remove";
            string EmptyString = null;

            Assert.AreEqual("This sentence contains some things to remove", ToReplace.ReplaceAll("", "77", "3"));
            Assert.AreEqual("This sentence contains some things to 3remove", ToReplace.ReplaceAll("", "77", "33"));
            Assert.ThrowsException<ArgumentNullException>(() => EmptyString.ReplaceAll("", "77", "3"));
            Assert.ThrowsException<ArgumentNullException>(() => ToReplace.ReplaceAll(null, "77", "3"));
        }

        [TestMethod]
        public void IsTests()
        {
            string ToTest = "Test";
            Assert.IsTrue(ToTest.Is("Test"));
            Assert.IsFalse(ToTest.Is("Not Test"));
        }
    }
}