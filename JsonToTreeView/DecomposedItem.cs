#region © 2019 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace JsonToTreeView
{
    // ----------------------------------------------------
    /// <summary>
    ///     DecomposedItem Description
    /// </summary>

    [ExcludeFromCodeCoverage]
    public class DecomposedItem
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string DataType { get; set; }
    }
}
