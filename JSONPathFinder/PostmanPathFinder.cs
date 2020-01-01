#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TreePathFinder
{
    // ----------------------------------------------------
    /// <summary>
    ///     PostmanPathFinder Description
    /// </summary>

    public class PostmanPathFinder : IPathFinder
    {
        public string GetPath(string nodeFullPath, bool terminator)
        {
            var retVal = nodeFullPath.Replace('\\', '.').Replace(".[", "[");
            var val = nodeFullPath.Substring(nodeFullPath.LastIndexOf('\\') + 1);
            var path = nodeFullPath.Substring(0, nodeFullPath.LastIndexOf('\\')).Replace('\\', '.').Replace(".[", "[");

            if(terminator)
            {
                retVal = $"pm.expect({path}).to.eql(\"{val}\")";
            }

            return retVal;
        }

        // ------------------------------------------------

        public string GetArrayPath(string root, string nodeFullPath)
        {
            var path = nodeFullPath.Replace('\\', '.');

            // -----------------------
            // Allows for recursion...

            var retVal = ProcessArrayPath(path);

            return retVal.Substring(retVal.IndexOf('.') + 1);
        }

        // ------------------------------------------------

        private string ProcessArrayPath(string path, string parent = null, string delimiter = null, int level = 0)
        {
            var retVal = new StringBuilder();
            var cr = Environment.NewLine;
            var tab = new string('\t', level);

            if(path.Contains("."))
            {
                var node = path.Substring(0, path.IndexOf('.'));
                var remainingPath = path.Substring(path.IndexOf('.') + 1);

                retVal.Append($"{delimiter}{parent}");

                if(IsArray(node))
                {
                    var nodeName = string.Empty;

                    // ----------------------------------------------------
                    // If the array is plural, use the name without the 's'

                    if(parent.EndsWith("s"))
                    {
                        nodeName = parent.Substring(0, parent.Length - 1).ToLower() + level.ToString();
                    }
                    else
                    {
                        nodeName = parent.ToLower() + level.ToString();
                    }

                    retVal.Append($".forEach({nodeName} =>{cr}{tab}{{{cr}");
                    retVal.Append($"{tab}\t{ProcessArrayPath(remainingPath, nodeName, null, ++level)}");
                    retVal.Append($"{cr}{tab}}});");
                }
                else
                {
                    retVal.Append(ProcessArrayPath(remainingPath, node, ".", level));
                }
            }
            else
            {
                // -------------------------------
                // Finally at the Leaf of the node

                retVal.Append($".{parent}.{path}");
            }

            return retVal.ToString();
        }

        // ------------------------------------------------

        private bool IsArray(string part)
        {
            var retVal = false;

            var regEx = new Regex(@"^\[*\d+\]$");
            retVal = regEx.Match(part).Success;

            return retVal;
        }
    }
}
