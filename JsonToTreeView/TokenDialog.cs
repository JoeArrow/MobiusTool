#region © 2019 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Windows.Forms;

using JWSortable;

namespace JsonToTreeView
{
    public partial class TokenDialog : Form
    {
        public TokenDialog(SortableBindingList<TokenDTO> tokens)
        {
            InitializeComponent();

            dgvTokens.DataSource = tokens;
            dgvTokens.Columns[0].Width = (dgvTokens.Width - 25);
        }

        private void OnOk(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
