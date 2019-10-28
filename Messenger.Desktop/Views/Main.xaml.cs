using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using Messenger.Contract.Domain;

namespace Messenger.Desktop.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        private MainWindow _window;
        private ObservableCollection<Message> _messages;
        private readonly SolidColorBrush[] userBackground = new SolidColorBrush[4];
        private User _user;
        public Main(MainWindow window, User user)
        {
            InitializeComponent();
            this._window = window;
            _user = user;
            _window.Width = 540;
            _window.Height = 400;

            _window.Background = new SolidColorBrush();

            //Opening 4 new window instances? Need to make it random if the user wants to open up new chat boxes
            userBackground[0] = new SolidColorBrush(Color.FromArgb( 223, 108, 41, 239));
            userBackground[1] = new SolidColorBrush(Color.FromArgb(223, 239, 41, 210));
            userBackground[2] = new SolidColorBrush(Color.FromArgb(223, 73, 44, 130));
            userBackground[3] = new SolidColorBrush(Color.FromArgb(223, 115, 36, 103));

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer(obj => {
                _window.MainView.Dispatcher.Invoke(() =>
                {

                });
            }, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
