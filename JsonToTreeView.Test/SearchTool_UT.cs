#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

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
        private const string _JSON = "{'Field 1':'Field 1 Value','Field 2':{'Field 2 Object':{'F2ObjF1':'Field 1'}}}";

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
        [DataRow("Field", 5, false)]
        [DataRow("_Field", 0, false)]
        [DataRow("Field 1", 3, false)]
        [DataRow(@"(?<=Field\s+)2", 2, true)]
        public void Search_SearchTool(string searchTerm, int expectedCount, bool useRegex)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var jTree = new JTree(_JSON);
            var sut = new SearchTool(jTree);

            // ---
            // Log

            Console.WriteLine($"JSON:{crt}{_JSON}{cr}Search Term:{crt}{searchTerm}{cr}Expected Count{crt}{expectedCount}{cr}");

            // ---
            // Act

            var res = sut.Search(jTree.RootNode, searchTerm, useRegex);

            // ---
            // Log

            Console.WriteLine($"Actual:{crt}{res}");

            // ------
            // Assert

            Assert.AreEqual(expectedCount, res);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Field", false)]
        [DataRow("_Field", false)]
        public void Next_SearchTool(string searchTerm, bool useRegex)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var jTree = new JTree(_JSON);
            var sut = new SearchTool(jTree);

            // ---
            // Log

            Console.WriteLine($"{cr}");

            // ---
            // Act

            var currentIndex = 0;

            var maxIndex = sut.Search(jTree.RootNode, searchTerm, useRegex);

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
        [DataRow("Field", false)]
        [DataRow("_Field", false)]
        public void Previous_SearchTool(string searchTerm, bool useRegex)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var jTree = new JTree(_JSON);
            var sut = new SearchTool(jTree);

            // ---
            // Log

            Console.WriteLine($"{cr}");

            // ---
            // Act

            var currentIndex = 0;

            var maxIndex = sut.Search(jTree.RootNode, searchTerm, useRegex);

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
    }
}