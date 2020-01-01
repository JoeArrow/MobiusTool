#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsonToTreeView.Test
{
    // ----------------------------------------------------
    /// <summary>
    ///     Summary description for ArrowUnitTestXML1
    /// </summary>

    [TestClass]
    public class JTree_UT
    {
        public JTree_UT() { }

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
        [DataRow(new string[] { "Postman", "TreeNode", "CSharp" })]
        public void AvailablePathFinders_JTree_Returns_List_Of_Available_PathFinders(string[] expected)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var sut = new JTree();

            // ---
            // Log

            Console.WriteLine($"{cr}");

            // ---
            // Act

            var res = new List<string>(sut.AvailablePathFinders);

            // ---
            // Log

            Console.WriteLine($"{crt}");

            // ------
            // Assert

            foreach(var val in expected)
            {
                Assert.IsTrue(res.Contains(val));
            }
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("{'FirstName':'FName','LastName':'LName','Age':99}")]
        [DataRow("{'Field 1':'Field 1 Value','Field 2': {'Field 2 Object': {'F2ObjF1': null}}}")]
        [DataRow("{'Field 1':'Field 1 Value','Field 2':{'Field 2 Object':{'F2ObjF1':'Field 1'}}}")]
        [DataRow("{'Field 1': 'Field 1 Value','Field 2':{'Field 2 Object':{'F2ObjF1':'{{Var}}'}}}")]
        [DataRow("{'Field 1':'Field 1 Value','MyArray':[{'Element':'Value'},{'Element':'Value'},{'Element':'Value'}]}")]
        public void CopyText_JTree_Copies_Expected_Text_To_The_Clipboard(string input)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var sut = new JTree(input);

            var privateObj = new PrivateObject(sut);

            // ---
            // Log

            Console.WriteLine($"Input:{crt}{input}{cr}");

            // ---
            // Act

            privateObj.Invoke("CopyText", null);
            var res = Clipboard.GetText();

            // ---
            // Log

            var expected = JToken.Parse(input).ToString(Formatting.Indented).Replace("\"{{", "{{").Replace("}}\"", "}}");

            Console.WriteLine($"Result:{cr}{res}{cr}Expected:{cr}{expected}");

            // ------
            // Assert

            Assert.AreEqual(res, expected);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("{'Field 1':'Field 1 Value','{{TestVar}}':{'Field 2 Object':{'F2ObjF1':'Field 1'}}}",
                 "{'Field 1':'Field 1 Value',{{TestVar}}:{'Field 2 Object':{'F2ObjF1':'Field 1'}}}")]
        public void CopyText_With_PM_Variables_JTree_Copies_Expected_Text_To_The_Clipboard(string input, string expected)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";
            var json = Regex.Replace(input, @"\s+", "");
            expected = Regex.Replace(expected, @"\s+", "");

            var sut = new JTree(json);

            var po = new PrivateObject(sut);

            // ---
            // Log

            Console.WriteLine($"Input:{crt}{input}{cr}");

            // ---
            // Act

            po.Invoke("CopyText", null);
            var res = Regex.Replace(Clipboard.GetText(), @"\s+", "").Replace('\"', '\'');

            // ---
            // Log

            Console.WriteLine($"Output:   {res}{cr}Expected: {expected}");

            // ------
            // Assert

            Assert.AreEqual(expected, res);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("{'Field 1':'Field 1 Value','Field 2':{'Field 2 Object':{'F2ObjF1':\"{{Var}}\"}}}",
                 false,
                 "{\r\n  \"Field 1\": \"Field 1 Value\",\r\n  \"Field 2\": {\r\n    \"Field 2 Object\": {\r\n      \"F2ObjF1\": {{Var}}\r\n    }\r\n  }\r\n}")]
        public void FormatJSON_JTree_Correctly_Formats_A_String_Of_JSON(string json, bool pretty, string expected)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var sut = new JTree(json);
            var args = new object[] { pretty };

            var privateObj = new PrivateObject(sut);

            // ---
            // Log

            Console.WriteLine($"Input:{crt}{json}{cr}Expected:{crt}{expected}{cr}");

            // ---
            // Act

            //var res = privateObj.Invoke("FormatJSON", args);
            var resp = sut.JSON;

            // ---
            // Log

            Console.WriteLine($"Response:{crt}{resp}");

            // ------
            // Assert

            Assert.IsTrue(expected.Equals(resp));
        }
    }
}