#region © 2020 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;

namespace JsonToTreeView
{
    // ----------------------------------------------------
    /// <summary>
    ///     NodeClickedEventArgs Description
    /// </summary>

    public class NodeClickedEventArgs : EventArgs
    {
        public string NodePath { get; set; }

        public NodeClickedEventArgs(string nodePath)
            : base()
        {
            NodePath = nodePath;
        }
    }
}
