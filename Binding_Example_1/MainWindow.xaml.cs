using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Binding_Example_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int SrvStarted = 0;
        public int ClientsConnected = 0;

        public MainWindow()
        {
            InitializeComponent();
            Thread t = new(Thread_Cyclic_Update);
            t.Start();
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            var bindExpr_StatusMsg = BindingOperations.GetBindingExpression(StatusMsg, Label.ContentProperty);
            var sourceData_StatusMsg = (Message)bindExpr_StatusMsg.DataItem;

            sourceData_StatusMsg.MessageText = "Server started";

            SrvStarted = 1;
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            var bindingExpression = BindingOperations.GetBindingExpression(StatusMsg, Label.ContentProperty);
            var sourceData = (Message)bindingExpression.DataItem;

            sourceData.MessageText = "SERVER STOPPED!";

            SrvStarted = 0;
        }

        public void Thread_Cyclic_Update()
        {
            var bindExpr_ClientCnt = BindingOperations.GetBindingExpression(ClientsCntMsg, Label.ContentProperty);
            var sourceDataClientCnt = (Message)bindExpr_ClientCnt.DataItem;

            while (true)
            {
                if (SrvStarted == 1)
                {
                    // Количество подключенных клиентов
                    ClientsConnected++;
                }
                else
                {
                    ClientsConnected = 0;
                }
                sourceDataClientCnt.ClientsCnt = ClientsConnected.ToString();
                Thread.Sleep(250);
            }
        }

    }
}
