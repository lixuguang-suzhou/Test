using System.Windows;
using System.Windows.Controls;

namespace RetroSnaker.Controls
{
    /// <summary>
    /// Spot.xaml 的交互逻辑
    /// </summary>
    public partial class SnakeBody : Spot
    {
        public static readonly DependencyProperty SpotParentProperty;
        
        public UserControl SpotParent
        {
            get { return (UserControl)GetValue(SpotParentProperty); }
            set { SetValue(SpotParentProperty, value); }
        }

        static SnakeBody()
        {
            SpotParentProperty = DependencyProperty.Register("SpotParent", typeof(UserControl), typeof(SnakeBody), new PropertyMetadata(null));
        }

        public SnakeBody()
        {
            InitializeComponent();
        }
    }
}
