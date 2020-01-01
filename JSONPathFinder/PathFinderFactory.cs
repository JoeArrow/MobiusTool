#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

namespace TreePathFinder
{
    // ----------------------------------------------------
    /// <summary>
    ///     PathFinderFactory Description
    /// </summary>

    public static class PathFinderFactory
    {
        public static IPathFinder GetPathFinder(string choice)
        {
            IPathFinder retVal = null;

            switch(choice)
            {
                case "Postman":
                    retVal = new PostmanPathFinder();
                    break;

                case "CSharp":
                    retVal = new CSharpPathFinder();
                    break;

                default:
                    retVal = new NodePathFinder();
                    break;
            }

            return retVal;
        }
    }
}
