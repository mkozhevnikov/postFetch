﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PostView
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
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
    }
}
