using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using PostFetcher.Model;

namespace PostView
{
    public partial class ViewForm : Form
    {
        protected readonly DataBase db = new DataBase();

        public ViewForm()
        {
            InitializeComponent();
            newsGrid.DataSource = new BindingSource {DataSource = db.Article};
            newsGrid.DataBindingComplete += NewsGridOnDataBindingComplete;
        }

        private void NewsGridOnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs dataGridViewBindingCompleteEventArgs) {
            try {
                newsGrid.AutoResizeColumn(6);
            }
            catch (Exception) {}
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog importDlg = new OpenFileDialog {
                InitialDirectory = "c:\\",
                Filter = "library (*.dll)|*.dll",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (importDlg.ShowDialog() == DialogResult.OK)
            {
                try {
                    Assembly.LoadFile(importDlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void loadNewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LoadDialog().Show();
        }

        private void FilterOnTextChanged(object sender, EventArgs eventArgs) {
            if (string.Empty.Equals(filter.Text)) {
                Update();
                return;
            }
            var query = from a in db.FullTextSearch(filter.Text) orderby a.Rank select a;
            newsGrid.DataSource = query.ToList();
        }

        public void Update() {
            var query = from a in db.Article select a;
            newsGrid.DataSource = query.ToList();
        }
    }
}
