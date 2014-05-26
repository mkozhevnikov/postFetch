using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PostFetcher;
using PostFetcher.Handler;
using PostFetcher.Model;

namespace PostView
{
    public partial class LoadDialog : Form {
        private ViewForm parent;
        public LoadDialog(ViewForm viewForm)
        {
            InitializeComponent();
            parent = viewForm;
            
            //составляю выборка из классов обработчиков
            var type = typeof(IHandler<Article>);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(s => s.GetTypes())
                                 .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);
//            handler.Items.AddRange(types.Select(t => (object)t.Name).ToArray());
            handler.Items.AddRange(types.Select(t => (object)t).ToArray());
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                var type = handler.SelectedItem as Type;
                if (type != null) {
                    //создаю экземпляр класса обработчика
                    var parser = (IHandler<Article>) Activator.CreateInstance(type);
//                    var parser = (IHandler<Article>) type.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    parser.Process(firstPage.Text);
                    MessageBox.Show("Новости загружены");
                    Close();
                    parent.RefreshGrid();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
