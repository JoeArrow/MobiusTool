#region © 2019 JoeWare.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Windows.Forms;

using JWSortable;
using JsonToTreeView.Exporters;

namespace JsonToTreeView
{
    public partial class DecompositionDialog : Form
    {
        private const int ID_COLUMN_WIDTH = 300;
        private const int KEY_COLUMN_WIDTH = 200;
        private const int TYPE_COLUMN_WIDTH = 100;
        private const int VALUE_COLUMN_WIDTH = 200;

        private SortableBindingList<DecomposedItem> Items { set; get; }

        public IExporter Exporter { get; set; }
        public string DecomposedData { private set; get; }

        // ------------------------------------------------

        public DecompositionDialog(string nodeName, IExporter exporter, SortableBindingList<DecomposedItem> items)
        {
            InitializeComponent();
            Exporter = exporter;

            PopulateExporters(exporter.Name);

            lblNodeName.Text = nodeName;

            // -------------------------------------
            // No need to explicitly call ApplySort.
            // The user can click on a header to get the sort

            Items = items;
            dgvItems.DataSource = Items;

            dgvItems.Columns[0].Width = ID_COLUMN_WIDTH;
            dgvItems.Columns[1].Width = KEY_COLUMN_WIDTH;
            dgvItems.Columns[3].Width = TYPE_COLUMN_WIDTH;
            dgvItems.Columns[2].Width = VALUE_COLUMN_WIDTH;
        }

        // ------------------------------------------------

        private void PopulateExporters(string name)
        {
            cbExporter.Items.AddRange(ExporterFactory.SupportedExporters().ToArray());

            if(Exporter != null && 
               cbExporter.Items.Count > 0 &&                 
               cbExporter.Items.Contains(Exporter.Name))
            {
                cbExporter.Text = Exporter.Name;
            }
        }

        // ------------------------------------------------

        private void OnExport(object sender, EventArgs e)
        {
            if(Items.Count > 0)
            {
                try
                {
                    DecomposedData = Exporter.Export(Items);
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message, "Exception");
                    return;
                }
            }

            DialogResult = DialogResult.Yes;
        }

        // ------------------------------------------------

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // ------------------------------------------------

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                OnCancel(null, null);
            }
        }

        // ------------------------------------------------

        private void OnExporterChange(object sender, EventArgs e)
        {
            Exporter = ExporterFactory.GetExporter(cbExporter.Text);
        }
    }
}
