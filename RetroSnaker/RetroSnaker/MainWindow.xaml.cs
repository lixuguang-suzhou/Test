using RetroSnaker.Controls;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace RetroSnaker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int ScatterNumber = 20;

        private List<SnakeBody> _scatters;
        private List<SnakeBody> _snakes;
        private SnakeHead _snakeHead;

        private Timer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _scatters = new List<SnakeBody>();
            _snakes = new List<SnakeBody>();

            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => { Moving(); }));
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_snakeHead == null) return;

            _snakeHead.MoveDirection = (Direction)int.Parse((sender as Border).Tag.ToString());
        }

        public void Start()
        {
            AddScatterSpot();

            AddSnakeHead();

            _timer.Start();
        }

        private void AddSnakeHead()
        {
            _snakeHead = new SnakeHead();

            _snakeHead.SetValue(Canvas.LeftProperty, (cvsMain.ActualWidth - _snakeHead.Width) / 2);
            _snakeHead.SetValue(Canvas.TopProperty, (cvsMain.ActualHeight - _snakeHead.Height) / 2);

            cvsMain.Children.Add(_snakeHead);
        }

        private void AddScatterSpot()
        {
            if (_scatters.Count > 0)
            {
                return;
            }

            Random rd = new Random();

            for (int i = 0; i < ScatterNumber; i++)
            {
                var snakeBody = new SnakeBody();

                snakeBody.Tag = i;

                snakeBody.SetValue(Canvas.LeftProperty, (double)rd.Next(0, (int)(cvsMain.ActualWidth - snakeBody.Width)));
                snakeBody.SetValue(Canvas.TopProperty, (double)rd.Next(0, (int)(cvsMain.ActualHeight - snakeBody.Height)));

                cvsMain.Children.Add(snakeBody);

                _scatters.Add(snakeBody);
            }
        }
        
        private void Moving()
        {
            switch (_snakeHead.MoveDirection)
            {
                case Direction.Top:
                    _snakeHead.SetValue(Canvas.TopProperty, (double)_snakeHead.GetValue(Canvas.TopProperty) - _snakeHead.Height);
                    break;
                case Direction.Bottom:
                    _snakeHead.SetValue(Canvas.TopProperty, (double)_snakeHead.GetValue(Canvas.TopProperty) + _snakeHead.Height);
                    break;
                case Direction.Left:
                    _snakeHead.SetValue(Canvas.LeftProperty, (double)_snakeHead.GetValue(Canvas.LeftProperty) - _snakeHead.Width);
                    break;
                case Direction.Right:
                    _snakeHead.SetValue(Canvas.LeftProperty, (double)_snakeHead.GetValue(Canvas.LeftProperty) + _snakeHead.Width);
                    break;
            }

            if (_snakes.Count > 0)
            {
                Move(_snakeHead.SpotChild as SnakeBody);
            }

            var headLeft = Canvas.GetLeft(_snakeHead);
            var headTop = Canvas.GetTop(_snakeHead);

            if (headLeft < 0 || headTop < 0 || headLeft > cvsMain.ActualWidth || headTop > cvsMain.ActualHeight)
            {
                Death();
            }

            foreach (var item in _scatters)
            {
                var left = Canvas.GetLeft(item as SnakeBody);
                var top = Canvas.GetTop(item as SnakeBody);

                if (Math.Abs(headLeft - left) < _snakeHead.Width && Math.Abs(headTop - top) < _snakeHead.Height)
                {
                    Eat(item as SnakeBody);

                    break;
                }
            }
        }

        private void Move(SnakeBody body)
        {
            var direction = (body.SpotParent as Spot).MoveDirection;
            var top = Canvas.GetTop(body.SpotParent as Spot);
            var left = Canvas.GetLeft(body.SpotParent as Spot);

            switch (direction)
            {
                case Direction.Top:
                    body.SetValue(Canvas.TopProperty, top + body.Height);
                    body.SetValue(Canvas.LeftProperty, left);
                    break;
                case Direction.Bottom:
                    body.SetValue(Canvas.TopProperty, top - body.Height);
                    body.SetValue(Canvas.LeftProperty, left);
                    break;
                case Direction.Left:
                    body.SetValue(Canvas.LeftProperty, left + body.Width);
                    body.SetValue(Canvas.TopProperty, top);
                    break;
                case Direction.Right:
                    body.SetValue(Canvas.LeftProperty, left - body.Width);
                    body.SetValue(Canvas.TopProperty, top);
                    break;
            }

            body.MoveDirection = direction;

            if (body.SpotChild != null)
            {
                Move(body.SpotChild as SnakeBody);
            }
        }

        private void Eat(SnakeBody body)
        {
            var left = 0.0;
            var top = 0.0;
            var direction = Direction.Right;

            if (_snakes.Count == 0)
            {
                _snakeHead.SpotChild = body;

                direction = _snakeHead.MoveDirection;
                left = Canvas.GetLeft(_snakeHead);
                top = Canvas.GetTop(_snakeHead);

                body.SpotParent = _snakeHead;
            }
            else
            {
                var last = _snakes[_snakes.Count - 1];
                last.SpotChild = body;

                direction = last.MoveDirection;
                left = Canvas.GetLeft(last);
                top = Canvas.GetTop(last);

                body.SpotParent = last;
            }

            _snakes.Insert(_snakes.Count, body);
            _scatters.Remove(body);

            body.MoveDirection = direction;

            switch (direction)
            {
                case Direction.Top:
                    body.SetValue(Canvas.LeftProperty, left);
                    body.SetValue(Canvas.TopProperty, top + body.Height);
                    break;
                case Direction.Bottom:
                    body.SetValue(Canvas.LeftProperty, left);
                    body.SetValue(Canvas.TopProperty, top - body.Height);
                    break;
                case Direction.Left:
                    body.SetValue(Canvas.LeftProperty, left + body.Width);
                    body.SetValue(Canvas.TopProperty, top);
                    break;
                case Direction.Right:
                    body.SetValue(Canvas.LeftProperty, left - body.Width);
                    body.SetValue(Canvas.TopProperty, top);
                    break;
            }

            AddScatterSpot();
        }

        private void Death()
        {
            _timer.Stop();

            new MessageWindow(_snakes.Count) { Owner = this }.Show();

            _snakeHead = null;
            _scatters.Clear();
            _snakes.Clear();

            cvsMain.Children.Clear();
        }
    }
}
