#region © 2019 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Web.Script.Serialization;

using Tools.Dynamic;
using JWSortable;

namespace JsonToTreeView.Exporters
{
    // ----------------------------------------------------
    /// <summary>
    ///     MobiusExporter Description
    /// </summary>

    public class MobiusExporter : IExporter
    {
        public string Name => "Mobius";

        // ------------------------------------------------

        public string Export(string text)
        {
            return text;
        }

        // ------------------------------------------------

        public string Export(SortableBindingList<DecomposedItem> items)
        {
            var ser = new JavaScriptSerializer();
            var builder = DynamicTypeGenerator.GenerateTypeBuilder("ToolsDynamic", "DynamicType");

            foreach(var item in items)
            {
                // ----------------------------------------------
                // Not great, but don't export Response Variables

                if(!item.Key.StartsWith("Resp_"))
                {
                    DynamicTypeGenerator.AddProperty(builder, item.Key, typeof(string));
                }
            }

            var objType = builder.CreateType();
            var obj = Activator.CreateInstance(objType) as dynamic;

            foreach(var item in items)
            {
                DynamicTypeGenerator.SetProperty(ref obj, item.Key, item.Value);
            }

            string json = ser.Serialize(obj);
            json = json.Insert(0, "[");
            json = json.Insert(json.Length, "]");
            return json;
        }
    }
}
