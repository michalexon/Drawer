using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Drawerr
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int Count = -1;
        List<Point> polygonPoints = new List<Point>();
        public void MousePosition()
        {
            Point position = Mouse.GetPosition(WorkField);
            polygonPoints.Add(position);
        }

        private void RectangleButton(object sender, RoutedEventArgs e)
        {
            Count = 2;
            polygonPoints.Clear();
        }

        private void TriangleButton(object sender, RoutedEventArgs e)
        {
            Count = 1;
            
            polygonPoints.Clear();
        }

        private void CircleButton(object sender, RoutedEventArgs e)
        {
            Count = 0;
            polygonPoints.Clear();

        }

        private void PentagonButton(object sender, RoutedEventArgs e)
        {
            Count = 3;
            polygonPoints.Clear();
        }


        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            
            WorkField.Children.Clear();
        }

        private void WorkFieldClick(object sender, MouseButtonEventArgs e)
        {

            MousePosition();
            if (polygonPoints.Count == 2 && Count == 0)
            {
                double r = Math.Sqrt(Math.Pow(polygonPoints[0].X - polygonPoints[1].X, 2) + Math.Pow(polygonPoints[0].Y - polygonPoints[1].Y, 2));
                Shape.Circlee circle = new Shape.Circlee(polygonPoints[0], r);
                Count = -1;
                polygonPoints.Clear();
            }
            else if (polygonPoints.Count == 3 && Count == 1)
            {
                Shape.Trianglee traingle = new Shape.Trianglee(polygonPoints[0], polygonPoints[1], polygonPoints[2]);
                Count = -1;
                polygonPoints.Clear();
            }
            else if (polygonPoints.Count == 4 && Count == 2)
            {
                Shape.Rectanglee rectangle = new Shape.Rectanglee(polygonPoints[0], polygonPoints[1], polygonPoints[2], polygonPoints[3]);
                Count = -1;
                polygonPoints.Clear();
            }
            else if (polygonPoints.Count == 5 && Count == 3)
            {
                Shape.Pentagonn pentagon = new Shape.Pentagonn(polygonPoints[0], polygonPoints[1], polygonPoints[2], polygonPoints[3], polygonPoints[4]);
                Count = -1;
                polygonPoints.Clear();
            }
        }
    }
        
}
