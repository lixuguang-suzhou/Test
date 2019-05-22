using System.Windows;

namespace RetroSnaker
{
    /// <summary>
    /// MessageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow : Window
    {
        private int _count;

        public MessageWindow(int count)
        {
            InitializeComponent();

            _count = count;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            runCount.Text = _count.ToString();
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            var vv = this;

            (Owner as MainWindow).Start();

            Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
