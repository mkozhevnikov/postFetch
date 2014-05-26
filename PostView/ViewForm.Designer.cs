using System;

namespace PostView
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filter = new System.Windows.Forms.ToolStripTextBox();
            this.importDLL = new System.Windows.Forms.OpenFileDialog();
            this.newsGrid = new System.Windows.Forms.DataGridView();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.поискПоТекстуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.поискПоТекстуToolStripMenuItem,
            this.filter});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1099, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.loadNewsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.importToolStripMenuItem.Text = "Подключить библиотеку";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // loadNewsToolStripMenuItem
            // 
            this.loadNewsToolStripMenuItem.Name = "loadNewsToolStripMenuItem";
            this.loadNewsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.loadNewsToolStripMenuItem.Text = "Загрузить новости";
            this.loadNewsToolStripMenuItem.Click += new System.EventHandler(this.loadNewsToolStripMenuItem_Click);
            // 
            // filter
            // 
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(100, 23);
            this.filter.TextChanged += new System.EventHandler(this.FilterOnTextChanged);
            // 
            // importDLL
            // 
            this.importDLL.FileName = "openFileDialog1";
            // 
            // newsGrid
            // 
            this.newsGrid.AllowUserToAddRows = false;
            this.newsGrid.AllowUserToDeleteRows = false;
            this.newsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsGrid.Location = new System.Drawing.Point(0, 27);
            this.newsGrid.Name = "newsGrid";
            this.newsGrid.ReadOnly = true;
            this.newsGrid.Size = new System.Drawing.Size(1099, 742);
            this.newsGrid.TabIndex = 1;
            // 
            // Author
            // 
            this.Author.HeaderText = "Автор";
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // Link
            // 
            this.Link.HeaderText = "Ссылка на оригинал";
            this.Link.Name = "Link";
            this.Link.ReadOnly = true;
            // 
            // Section
            // 
            this.Section.HeaderText = "Рубрика";
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            // 
            // Created
            // 
            this.Created.HeaderText = "Дата создания";
            this.Created.Name = "Created";
            this.Created.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.HeaderText = "Заголовок";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // поискПоТекстуToolStripMenuItem
            // 
            this.поискПоТекстуToolStripMenuItem.Enabled = false;
            this.поискПоТекстуToolStripMenuItem.Name = "поискПоТекстуToolStripMenuItem";
            this.поискПоТекстуToolStripMenuItem.Size = new System.Drawing.Size(111, 23);
            this.поискПоТекстуToolStripMenuItem.Text = "Поиск по тексту:";
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 769);
            this.Controls.Add(this.newsGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog importDLL;
        private System.Windows.Forms.ToolStripMenuItem loadNewsToolStripMenuItem;
        private System.Windows.Forms.DataGridView newsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.ToolStripTextBox filter;
        private System.Windows.Forms.ToolStripMenuItem поискПоТекстуToolStripMenuItem;
    }
}

