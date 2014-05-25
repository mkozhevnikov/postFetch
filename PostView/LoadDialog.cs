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

namespace PostView
{
    public partial class LoadDialog : Form
    {
        public LoadDialog()
        {
            InitializeComponent();
            var type = typeof(IHandler<Article>);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(s => s.GetTypes())
                                 .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);
//            handler.Items.AddRange(types.Select(t => (object)t.Name).ToArray());
            handler.Items.AddRange(types.Select(t => (object)t).ToArray());
        }

        //todo получить доступ к файлу конфигураций из другой сборки
        private void button1_Click(object sender, EventArgs e) {
            try {
                var type = handler.SelectedItem as Type;
                if (type != null) {
//                    ConfigurationManager.ConnectionStrings["post"]
//                    var parser = (IHandler<Article>) Activator.CreateInstance(type);
                    var parser = (IHandler<Article>) type.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    parser.Process(firstPage.Text.Equals(string.Empty) ? null : firstPage.Text);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
