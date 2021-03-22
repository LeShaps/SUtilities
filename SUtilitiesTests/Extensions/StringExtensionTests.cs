using Microsoft.VisualStudio.TestTools.UnitTesting;
using STools.Extensions;
using System.Collections.Generic;

namespace SUtilitiesTests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void ToWordOnlyTests()
        {
            string CompletePhrase = "123HereI%Am";
            Assert.AreEqual("HereIAm", CompletePhrase.ToWordOnly());
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void CutInPartsTests()
        {
            string SplitableSentence = "For all that I know, I could just let this test run, I don't think there will be any problems";
            List<string> SplitedSentence = SplitableSentence.CutInParts(" ", 50);
            Assert.IsTrue(SplitedSentence.Count == 2);
            Assert.AreEqual("For all that I know, I could just let this test", SplitedSentence[0]);
            Assert.AreEqual("run, I don't think there will be any problems", SplitedSentence[1]);
        }

        [TestMethod]
        public void ContainsTests()
        {
            string TestSentence = "This sentence could contains anything but not everyone";
            Assert.IsTrue(TestSentence.Contains("This", "but", " "));
            Assert.IsFalse(TestSentence.Contains("nothing"));
        }

        [TestMethod]
        public void ToReplaceTests()
        {
            string ToReplace = "This sentence contains 77some things to 3remove";
            Assert.AreEqual("This sentence contains some things to remove", ToReplace.ReplaceAll("", "77", "3"));
            Assert.AreEqual("This sentence contains some things to 3remove", ToReplace.ReplaceAll("", "77", "33"));
        }
    }
}