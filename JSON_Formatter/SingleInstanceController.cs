#region © 2021 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace JSON_Formatter
{
    // ----------------------------------------------------
    /// <summary>
    ///     SingleInstanceController Description
    /// </summary>

    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        public SingleInstanceController()
        {
            IsSingleInstance = true;
            StartupNextInstance += this_StartupNextInstance;
        }

        // ------------------------------------------------

        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            var form = MainForm as MobiusForm;
            form.LoadFile(e.CommandLine[1]);
        }

        // ------------------------------------------------

        protected override void OnCreateMainForm()
        {
            MainForm = new MobiusForm();
        }
    }
}
