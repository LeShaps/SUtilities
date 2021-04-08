using Microsoft.VisualStudio.TestTools.UnitTesting;

using STools;
using System;
using System.IO;

namespace SUtilitiesTests
{
    [TestClass]
    public class ToolsTests
    {
        [TestMethod]
        public void CheckDirAndDeleteContentTests()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Tools.CheckDir(""));
            Assert.ThrowsException<ArgumentNullException>(() => Tools.CheckDir(null));

            Tools.CheckDir("Testing/NewFolder/Dante");
            Assert.IsTrue(Directory.Exists("Testing/NewFolder/Dante"));

            File.WriteAllText("Testing/NewFolder/Testing101.txt", "Just testing for now");
            File.WriteAllText("Testing/NewFolder/Dante/Inferno.txt", "Inferno is real");

            Tools.DeleteDirectoryContent("Testing/");
            Assert.IsFalse(File.Exists("Testing/NewFolder/Test101.txt"));
            Assert.IsFalse(Directory.Exists("Testing/NewFolder"));
            Assert.IsTrue(Directory.Exists("Testing"));

            Assert.ThrowsException<ArgumentNullException>(() => Tools.DeleteDirectoryContent(""));
            Assert.ThrowsException<ArgumentNullException>(() => Tools.DeleteDirectoryContent(null));
        }

        [TestMethod]
        public void ClarifyTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Tools.Clarify(""));
            Assert.ThrowsException<ArgumentNullException>(() => Tools.Clarify(null));
        }
    }
}
