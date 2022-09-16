#region © 2022 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System.Linq;

using Microsoft.VisualBasic.ApplicationServices;

namespace JSON_Formatter
{
    // ----------------------------------------------------
    /// <summary>
    ///     MobiusApp Description
    /// </summary>

    public class MobiusApp : WindowsFormsApplicationBase
    {
        public MobiusApp(string[] args)
        {
            MainForm = args.Length > 0 ? new MobiusForm(args[0]) : new MobiusForm();
            IsSingleInstance = true;
        }

        // ------------------------------------------------

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            ((MobiusForm)MainForm).NewInstance(eventArgs.CommandLine.FirstOrDefault());
        }
    }
}
