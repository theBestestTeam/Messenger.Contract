using Messenger.Contract.Contract;
using Messenger.Contract.Domain;
using Messenger.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Messenger.Desktop.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private MainWindow _window;
        public Login()
        {
            InitializeComponent();
            _window = (MainWindow)Application.Current.MainWindow;
            if(_window != null)
            {
                _window.Width = 540;
                _window.Height = 420;
                _window.MinWidth = 540;
                _window.MinHeight = 420;
                _window.MaxWidth = 540;
                _window.MaxHeight = 420;
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(Username.Text))
            {
                User user = new User
                {
                    TimeCreated = DateTime.UtcNow,
                    Name = Username.Text
                };

                _window.MainView = new Main(_window,user);
                var uri = "net.tcp://localhost:6565/MessageService";
                var callBack = new InstanceContext(new MessageServiceCallBack());
                var binding = new NetTcpBinding(SecurityMode.None);
                var channel = new DuplexChannelFactory<IMessageService>(callBack, binding);
                var endPoint = new EndpointAddress(uri);
                var proxy = channel.CreateChannel(endPoint);
                proxy?.Connect(user);
                _window.Main.Children.Clear();
                _window.Main.Children.Add(_window.MainView);
                
            }
        }
    }
}
