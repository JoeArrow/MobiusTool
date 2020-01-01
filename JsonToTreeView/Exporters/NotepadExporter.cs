#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;

using Aflac.Sortable;
using Tools.Dynamic;

namespace JsonToTreeView.Exporters
{
    // ----------------------------------------------------
    /// <summary>
    ///     Notepad Exporter Creates a new instance of Notepad
    ///     and places the text into the notepad text box.
    /// </summary>

    public class NotepadExporter : IExporter
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent,
                                                 IntPtr hwndChildAfter,
                                                 string lpszClass,
                                                 string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        // ------------------------------------------------

        public string Name { get { return "Notepad"; } }

        // ------------------------------------------------

        public string Export(string text)
        {
            var retVal = text;
            var proc = new Process() { StartInfo = new ProcessStartInfo("notepad.exe") };
            var started = proc.Start();

            Thread.Sleep(240);

            if(started && proc != null)
            {
                IntPtr child = FindWindowEx(proc.MainWindowHandle, new IntPtr(0), "Edit", null);

                SendMessage(child, 0x00B1, 0, text);
                SendMessage(child, 0x00C2, 0, text);
            }

            return retVal;
        }

        // ------------------------------------------------

        public string Export(SortableBindingList<DecomposedItem> items)
        {
            var retVal = string.Empty;
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
            retVal = Export(json);

            return retVal;
        }
    }
}
