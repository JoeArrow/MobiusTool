#region © 2019 Aflac.
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
    ///     DecompositionEventArgs Description
    /// </summary>

    public class DecompositionEventArgs : EventArgs
    {
        public string DecomposedData { get; set; }

        public DecompositionEventArgs(string decomposedData)
            : base()
        {
            DecomposedData = decomposedData;
        }
    }
}
