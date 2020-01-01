using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreePathFinder.Test
{
    [TestClass]
    public class TreePathFinder_UT
    {
        private string cr = $"{Environment.NewLine}";
        private string crt = $"{Environment.NewLine}\t";

        private const string JSON = "json\\Field 2\\Field 2 Object\\F2ObjF1\\Field 1";

        // ------------------------------------------------

        [TestMethod]
        [DataRow("CSharp", false, "json.Field 2.Field 2 Object.F2ObjF1.Field 1")]
        [DataRow("Postman", false, "json.Field 2.Field 2 Object.F2ObjF1.Field 1")]
        [DataRow("TreeNode", false, "json.Field 2.Field 2 Object.F2ObjF1.Field 1")]

        [DataRow("TreeNode", true, "json.Field 2.Field 2 Object.F2ObjF1.Field 1")]
        [DataRow("CSharp", true, "json.Field 2.Field 2 Object.F2ObjF1=\"Field 1\"")]
        [DataRow("Postman", true, "pm.expect(json.Field 2.Field 2 Object.F2ObjF1).to.eql(\"Field 1\")")]
        public void GetPath_PathFinder_Returns_The_Expected_Path_String(string pathFinderName, bool terminator, string expected)
        {
            // -------
            // Arrange

            var sut = PathFinderFactory.GetPathFinder(pathFinderName);

            // ---
            // Log

            Console.WriteLine($"Full Path:{crt}{JSON}{cr}Path Finder:{crt}{pathFinderName}{cr}Terminator:{crt}{terminator}{cr}Expected:{crt}{expected}{cr}");

            // ---
            // Act

            var res = sut.GetPath(JSON, terminator);

            // ---
            // Log

            Console.WriteLine($"Actual:{crt}{res}");

            // ------
            // Assert

            Assert.AreEqual(expected, res);
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Postman", @"Field1.Array.[3].element.field",
                 "Field1.Array.forEach(array0 =>{array0.element.field});")]

        [DataRow("Postman", @"Field1.Array.[3].element.[0].SubElment.SubRegion.[0].target.field",
                 "Field1.Array.forEach(array0 =>{array0.element.forEach(element1 =>" +
                 "{element1.SubElment.SubRegion.forEach(subregion2 =>{subregion2.target.field});});});")]

        [DataRow("Postman", @"json.PossibleEnrollmentData.ProductChoices.[0].Options.[0].Options.[0].Option.className",
                 "json.PossibleEnrollmentData.ProductChoices.forEach(productchoice0 =>" +
                 "{productchoice0.Options.forEach(option1 =>{option1.Options.forEach(option2 =>{option2.Option.className});});});")]
        public void GetArrayPath_TreePathFinder_Returns_A_Client_Usable_String_Of_Code_To_An_Array_Element(string pathFinderName, string path, string expected)
        {
            // -------
            // Arrange

            var sut = PathFinderFactory.GetPathFinder(pathFinderName);

            // ---
            // Log

            Console.WriteLine($"Path to Check:{crt}{path}{cr}");

            // ---
            // Act

            var resp = sut.GetArrayPath("json", path).Replace(Environment.NewLine, "").Replace("\t", "");

            // ---
            // Log

            Console.WriteLine($"Expected:\t{expected.Replace(Environment.NewLine, "")}{cr}" +
                              $"Actual:\t\t{resp.Replace(Environment.NewLine, "")}");

            // ------
            // Assert

            Assert.AreEqual(expected.Trim(), resp.Trim());
        }

        // ------------------------------------------------

        [TestMethod]
        [DataRow("Postman", "[1]", true)]
        [DataRow("Postman", "[10]", true)]
        [DataRow("Postman", "someText.[1].someText", false)]
        public void IsArray_TreePathFinder_Correctly_Identifies_Array_Nodes(string finderChoice, string input, bool expected)
        {
            // -------
            // Arrange

            var sut = PathFinderFactory.GetPathFinder(finderChoice);
            var po = new PrivateObject(sut);

            // ---
            // Log

            Console.WriteLine($"Text to test:{crt}{input}{cr}Expected Response:{crt}{expected.ToString()}{cr}");

            // ---
            // Act

            var resp = po.Invoke("IsArray", new object[] { input });

            // ---
            // Log

            Console.WriteLine($"{crt}");

            // ------
            // Assert

            Assert.AreEqual(expected, resp);
        }
    }
}
