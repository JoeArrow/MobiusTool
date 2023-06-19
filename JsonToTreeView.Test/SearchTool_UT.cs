#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Text.RegularExpressions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonToTreeView.Test
{
    // ----------------------------------------------------
    /// <summary>
    ///     Summary description for ArrowUnitTestXML1
    /// </summary>

    [TestClass]
    public class SearchTool_UT
    {
        private readonly string cr = Environment.NewLine;
        private const string JSON = "{'Field 1':'Field 1 Value','Field 2':{'Field 2 Object':{'F2ObjF1':'Field 1'}}}";

        public SearchTool_UT() { }

        // ------------------------------------------------
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the 
        ///     current test run.
        ///</summary>

        public TestContext TestContext { set; get; }

        // ------------------------------------------------

        #region Additional test attributes
#pragma warning disable S125
        // ------------------------------------------------
        // You can use the following additional attributes 
        // as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
#pragma warning restore S125
        #endregion

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Field", 5)]
        [DataRow("_Field", 0)]
        [DataRow("Field 1", 3)]
        public void Search_SearchTool_Locates_The_Expected_Number_Of_Entries(string searchTerm, int expectedCount)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var jTree = new JTree(JSON);
            var sut = new SearchTool(jTree);

            // ---
            // Log

            Console.WriteLine($"JSON:{crt}{JSON}{cr}Search Term:{crt}{searchTerm}{cr}Expected Count{crt}{expectedCount}{cr}");

            // ---
            // Act

            var res = sut.Search(jTree.RootNode, searchTerm);

            // ---
            // Log

            Console.WriteLine($"Actual:{crt}{res}");

            // ------
            // Assert

            Assert.AreEqual(expectedCount, res);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Field")]
        [DataRow("_Field")]
        public void Next_SearchTool_Successfully_Navigates_Through_The_Found_TreeNodes(string searchTerm)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var jTree = new JTree(JSON);
            var sut = new SearchTool(jTree);

            // ---
            // Log

            Console.WriteLine($"{cr}");

            // ---
            // Act

            var currentIndex = 0;

            var maxIndex = sut.Search(jTree.RootNode, searchTerm);

            for(var i = 0; i < maxIndex * 2; i++)
            {
                currentIndex = sut.Next();

                // ---
                // Log

                Console.WriteLine($"CurrentIndex: {currentIndex}");

                // ------
                // Assert

                Assert.IsTrue(currentIndex <= maxIndex);
            }
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Field")]
        [DataRow("_Field")]
        public void Previous_SearchTool_Successfully_Navigates_Through_The_Found_TreeNodes(string searchTerm)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var jTree = new JTree(JSON);
            var sut = new SearchTool(jTree);

            // ---
            // Log

            Console.WriteLine($"{cr}");

            // ---
            // Act

            var currentIndex = 0;

            var maxIndex = sut.Search(jTree.RootNode, searchTerm);

            for(var i = 0; i < maxIndex * 2; i++)
            {
                currentIndex = sut.Previous();

                // ---
                // Log

                Console.WriteLine($"CurrentIndex: {currentIndex}");

                // ------
                // Assert

                Assert.IsTrue(currentIndex <= maxIndex);
            }
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("This is a test o\xA0\xA0f finding hex values in a string", @"\xA0", 16)]
        public void Search_SearchTool_String(string fullString, string searchVal, int expected)
        {
            // -------
            // Arrange

            var sut = new SearchTool();

            // ---
            // Act

            var resp = sut.Search(fullString, searchVal);

            // ------
            // Assert

            Assert.AreEqual(expected, resp);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow(@"This is a test o\xA0\xA8f finding and removing hex val\x8Aues in a string", 
                  "This is a test of finding and removing hex values in a string")]
        public void RemoveHex_SearchTool(string fullString, string expected)
        {
            // -------
            // Arrange

            var result = fullString;
            var sut = new SearchTool();

            // ---
            // Act

            var resp = sut.RemoveHex(fullString);

            Console.WriteLine($"Before: '{fullString}'{cr}After:  '{resp}'");

            // ------
            // Assert

            Assert.AreEqual(expected, resp);
        }
    }
}