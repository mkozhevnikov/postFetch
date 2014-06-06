using System;
using System.Linq;
using System.Windows.Forms;
using PostFetcher.Model;

namespace PostView
{
    public partial class LoadDialog : Form
    {
        private ViewForm parent;
        public LoadDialog(ViewForm viewForm)
        {
            InitializeComponent();
            parent = viewForm;

            //составляем выборку из классов обработчиков
            var types = HandlerFactory.GetHandlerTypes<Article>();
//            handler.Items.AddRange(types.Select(t => (object)t.Name).ToArray());
            handler.Items.AddRange(types.Select(t => (object)t).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var handlerType = handler.SelectedItem as Type;
                if (handlerType != null)
                {
//                    var parser = (IHandler<Article>) Activator.CreateInstance(type);
//                    var parser = (IHandler<Article>) type.GetConstructor(new Type[] { }).Invoke(new object[] { });
//                    parser.Process(firstPage.Text);
                    //создаем экземпляр класса обработчика и вызываем его метод
                    HandlerFactory.Call<Article>(handlerType, firstPage.Text);
                    MessageBox.Show("Новости загружены");
                    Close();
                    parent.RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
