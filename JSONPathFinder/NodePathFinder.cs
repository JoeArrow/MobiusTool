#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

namespace TreePathFinder
{
    // ----------------------------------------------------
    /// <summary>
    ///     NodePathFinder Description
    /// </summary>

    public class NodePathFinder : IPathFinder
    {
        public string GetPath(string nodeFullPath, bool terminator)
        {
            var retVal = nodeFullPath.Replace('\\', '.').Replace(".[", "[");
            var val = nodeFullPath.Substring(nodeFullPath.LastIndexOf('\\') + 1);
            var path = nodeFullPath.Substring(0, nodeFullPath.LastIndexOf('\\')).Replace('\\', '.').Replace(".[", "[");

            if(terminator)
            {
                retVal = $"{path}.{val}";
            }

            return retVal;
        }

        // ------------------------------------------------

        public string GetArrayPath(string root, string path)
        {
            var retVal = GetPath(path, true);
            return retVal;
        }
    }
}
