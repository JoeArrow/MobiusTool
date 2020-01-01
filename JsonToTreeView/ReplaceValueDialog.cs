using System;
using System.Windows.Forms;

namespace JsonToTreeView
{
    public partial class ReplaceValueDialog : Form
    {
        public string NewValue { set; get; }
        public string SearchValue { set; get; }

        // ------------------------------------------------

        public ReplaceValueDialog()
        {
            InitializeComponent();
        }

        // ------------------------------------------------

        public ReplaceValueDialog(string searchValue) 
            : this()
        {
            SearchValue = searchValue;
            tbSearchValue.Text = searchValue;
        }

        // ------------------------------------------------

        private void OnReplace(object sender, EventArgs e)
        {
            NewValue = tbNewValue.Text;
            SearchValue = tbSearchValue.Text;

            DialogResult = DialogResult.OK;
        }

        // ------------------------------------------------

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // ------------------------------------------------
        /// <summary>
        ///     Allow the user to cancel using the Escape key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
            {
                OnCancel(null, null);
            }
        }
    }
}
