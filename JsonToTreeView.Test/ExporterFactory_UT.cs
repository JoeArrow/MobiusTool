#region © 2019 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JsonToTreeView.Exporters;

namespace JsonToTreeView.Test
{
    // ----------------------------------------------------
    /// <summary>
    ///     Summary description for ArrowUnitTestXML1
    /// </summary>

    [TestClass]
    public class ExporterFactory_UT
    {
        private string cr = $"{Environment.NewLine}";
        private string crt = $"{Environment.NewLine}\t";

        public ExporterFactory_UT() { }

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

        // You can use the following additional attributes as you write your tests:
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
        [DataRow("Notepad")]
        [DataRow("NOTEPAD")]
        [DataRow("notepad")]
        public void GetExporter_ExporterFactory_Returns_Supported_Exporters(string name)
        {
            // ---
            // Log

            Console.WriteLine($"Exporter Name:{crt}{name}{cr}");

            // ---
            // Act

            var sut = ExporterFactory.GetExporter(name);

            // ---
            // Log

            Console.WriteLine($"Exporter Returned:{crt}{sut.Name}");

            // ------
            // Assert

            Assert.IsTrue(name.Equals(sut.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("File")]
        [DataRow("Notepad++")]
        [DataRow("NOTEPAD++")]
        [DataRow("notepad++")]
        public void SupportedExporters_ExporterFactory_Throws_Not_Implemented_Exception(string name)
        {
            // ---
            // Log

            Console.WriteLine($"Exporter Name:{crt}{name}{cr}");

            // ------
            // Assert

            Assert.ThrowsException<NotImplementedException>(() => ExporterFactory.GetExporter(name));
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("['Notepad', 'Mobius']")]
        public void SupportedExporters_ExporterFactory_Returns_A_List_Of_All_Supported_Exporters(string expectedList)
        {
            // -------
            // Arrange

            var ser = new JavaScriptSerializer();
            var expected = ser.Deserialize<List<string>>(expectedList);

            // ---
            // Log

            Console.WriteLine("Expected Response(s):");
            foreach(var item in expected) { Console.WriteLine($"\t{item}{cr}"); }

            // ---
            // Act

            var resp = ExporterFactory.SupportedExporters();

            // ---
            // Log

            Console.WriteLine("Actual Response(s):");
            foreach(var item in resp) { Console.WriteLine($"\t{item}{cr}"); }

            // ------
            // Assert

            Assert.AreEqual(expected.Count, resp.Count);

            foreach(var item in expected)
            {
                Assert.IsTrue(resp.Contains(item));
            }
        }
    }
}