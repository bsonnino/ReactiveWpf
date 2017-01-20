using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _3___DragImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupDrag();
        }

        private void SetupDrag()
        {
            var mousedown = Observable.FromEventPattern<MouseButtonEventArgs>(Image, "MouseLeftButtonDown")
                    .Select(evt => evt.EventArgs.GetPosition(Image));
            var mouseup = Observable.FromEventPattern<MouseButtonEventArgs>(this, "MouseLeftButtonUp");
            var mousemove = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove")
                    .Select(evt => evt.EventArgs.GetPosition(this));
            var drag = from start in mousedown
                from move in mousemove.TakeUntil(mouseup)
                select
                new
                {
                    X = move.X - start.X,
                    Y = move.Y - start.Y
                };
            mousedown.Subscribe(p =>
            {
                
            });
            mouseup.Subscribe(e =>
            {
                
            });
            mousemove.Subscribe(p =>
            {
                
            });
            drag.Subscribe(value =>
            {
                Canvas.SetLeft(Image, value.X);
                Canvas.SetTop(Image, value.Y);
            });
        }
    }
}
