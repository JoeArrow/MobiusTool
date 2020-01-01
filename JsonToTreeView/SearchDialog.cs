using System;
using System.Windows.Forms;

namespace JsonToTreeView
{
    public partial class SearchDialog : Form
    {
        public string SearchTerm 
        {
            set { tbTerm.Text = value; }
            get { return tbTerm.Text; }
        }

        // ------------------------------------------------

        public SearchDialog()
        {
            InitializeComponent();

            var val = Clipboard.GetText();

            if(val != null && val.Length < 60)
            {
                SearchTerm = val;
            }
        }

        // ------------------------------------------------

        private void OnSearch(object sender, EventArgs e)
        {
            Clipboard.SetText(SearchTerm);
            DialogResult = DialogResult.OK;
        }

        // ------------------------------------------------

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // ------------------------------------------------
        /// <summary>
        ///     Allow the user to search using the Enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                OnSearch(null, null);
            }
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
