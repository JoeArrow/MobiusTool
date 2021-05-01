#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Windows.Forms;

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
    public class Json2Tree_UT
    {
        public Json2Tree_UT() { }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("{'FirstName':'FName', 'LastName':'LName', 'Age':99}", "LName", 3)]
        public void BuildTree_Json2Tree_Populates_A_TreeView_From_A_JSON_String(string json, string expected, int nodeCount)
        {
            // -------
            // Arrange

            var tv = new TreeView();
            var sut = new Json2Tree(ref tv);

            // ---
            // Log

            Console.WriteLine("{0}", json);

            // ---
            // Act

            sut.BuildTree(json, "MyTree");

            // ------
            // Assert

            Assert.AreEqual(nodeCount, tv.Nodes[0].Nodes.Count);
            Assert.AreEqual(expected, tv.Nodes[0].Nodes[1].LastNode.Text);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("{'FirstName':'FName', 'LastName':'LName', 'Age':99}", 3)]

        [DataRow("{'Field 1':'Field 1 Value','Field 2':{'Field 2 Object':{'F2ObjF1':null}}}", 2)]
        [DataRow("{'Field 1':'Field 1 Value','Field 2':{'Field 2 Object':{'F2ObjF1':'{{Var}}'}}}", 2)]
        [DataRow("{'Field 1':'Field 1 Value','MyArray':[{'Element':'Value'},{'Element':'Value'},{'Element':'Value'}]}", 2)]
        public void BuildTree_Json2Tree_Populates_A_TreeView_From_A_JToken(string json, int nodeCount)
        {
            // -------
            // Arrange

            var tv = new TreeView();
            var sut = new Json2Tree(ref tv);
            var token = JToken.Parse(json);

            // ---
            // Log

            Console.WriteLine("{0}", json);

            // ---
            // Act

            sut.BuildTree(token, "MyTree");

            // ------
            // Assert

            Assert.AreEqual(nodeCount, tv.Nodes[0].Nodes.Count);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("{'FirstName':'FName','LastName':'LName','Age':99}", "Age", "99")]
        public void Comparison_Newtonsoft_Input_And_Output_are_Comparable(string json, string propName, string val)
        {
            // -------
            // Arrange

            var cr = $"{Environment.NewLine}";
            var crt = $"{Environment.NewLine}\t";

            var primary = JObject.Parse(json);
            var secondary = JsonConvert.SerializeObject(primary).Replace('\"', '\'');
            var tertiary = JObject.Parse(secondary);

            var propVal = Convert.ToString(tertiary[propName]);

            // ---
            // Log

            Console.WriteLine($"Comparison:{cr}{cr}{secondary}{cr}{json}{cr}{cr}" +
                              $"PropName:{crt}{propName}{cr}{cr}" +
                              $"Expected Value:{crt}{val}{cr}" +
                              $"Actual Value:{crt}{propVal}");
            // ------
            // Assert

            Assert.IsTrue(val.Equals(propVal)); ;
            Assert.IsTrue(secondary.Equals(json));
            Assert.IsTrue(primary.ToString().Equals(tertiary.ToString()));
        }
    }
}