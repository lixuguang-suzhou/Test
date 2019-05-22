using System.Windows;
using System.Windows.Controls;

namespace RetroSnaker.Controls
{
    public class Spot : UserControl
    {
        public static readonly DependencyProperty SpotChildProperty;
        public static readonly DependencyProperty MoveDirectionProperty;
        public static readonly DependencyProperty IsDiedProperty;


        public UserControl SpotChild
        {
            get { return (UserControl)GetValue(SpotChildProperty); }
            set { SetValue(SpotChildProperty, value); }
        }

        public Direction MoveDirection
        {
            get { return (Direction)GetValue(MoveDirectionProperty); }
            set { SetValue(MoveDirectionProperty, value); }
        }

        public bool IsDied
        {
            get { return (bool)GetValue(IsDiedProperty); }
            set { SetValue(IsDiedProperty, value); }
        }

        static Spot()
        {
            SpotChildProperty = DependencyProperty.Register("SpotChild", typeof(UserControl), typeof(Spot), new PropertyMetadata(null));
            MoveDirectionProperty = DependencyProperty.Register("MoveDirection", typeof(Direction), typeof(Spot), new PropertyMetadata(Direction.Right));
            IsDiedProperty = DependencyProperty.Register("IsDied", typeof(bool), typeof(Spot), new PropertyMetadata(false));
        }
    }

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right
    }
}
