#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using Aflac.Sortable;

namespace JsonToTreeView.Exporters
{
    public interface IExporter
    {
        string Name { get; }
        string Export(string text);
        string Export(SortableBindingList<DecomposedItem> items);
    }
}
