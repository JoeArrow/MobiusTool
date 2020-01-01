
using System.Windows.Forms;

namespace JSON_Formatter
{
    public partial class TabRenameDialog : Form
    {
        public TabRenameDialog(string currentName)
        {
            InitializeComponent();

            if(tbNewName.Text.Equals(Properties.Settings.Default.DefaultTabText))
            {
                var mem = Clipboard.GetText();

                if(!string.IsNullOrWhiteSpace(mem) && mem.Length < 60)
                {
                    tbNewName.Text = mem;
                }
                else
                {
                    tbNewName.Text = currentName;
                }
            }
            else
            {
                tbNewName.Text = currentName;
            }
        }

        // ------------------------------------------------

        private void OnOk(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        // ------------------------------------------------

        private void OnCancel(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // ------------------------------------------------

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                OnOk(null, null);
            }
        }
    }
}
