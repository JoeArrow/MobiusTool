#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Collections.Generic;

namespace JsonToTreeView.Exporters
{
    // ----------------------------------------------------
    /// <summary>
    ///     ExporterFactory Description
    /// </summary>

    public static class ExporterFactory
    {
        public static IExporter GetExporter(string name)
        {
            IExporter retVal = null;

            switch(name.ToLower())
            {
                case "notepad++":
                    throw new NotImplementedException($"{name} has not been implemented yet.");
                    //break;

                case "file":
                    throw new NotImplementedException($"{name} has not been implemented yet.");
                    //break;

                case "notepad":
                    retVal = new NotepadExporter();
                    break;

                default:
                case "mobius":
                    retVal = new MobiusExporter();
                    break;
            }

            return retVal;
        }

        // ------------------------------------------------

        public static List<string> SupportedExporters()
        {
            var retVal = new List<string>() { "Mobius", "Notepad" };

            return retVal;
        }
    }
}
