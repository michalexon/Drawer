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
    class Shape
    {
        public abstract class Shapee
        {
            double Surface { get; set; }

            double Sides { get; set; }
        }
        public class Circlee : Shapee
        {
            private double radius;
            private const double PI = Math.PI;

            MainWindow main = (MainWindow)Application.Current.MainWindow;

            public Circlee(Point point1, double radius)
            {
                this.radius = radius;

                Ellipse elipse = new Ellipse();
                elipse.Width = radius;
                elipse.Height = radius;
                elipse.SetValue(Canvas.LeftProperty, point1.X);
                elipse.SetValue(Canvas.TopProperty, point1.Y);

                SolidColorBrush yellowBrush = new SolidColorBrush { Color = Colors.Yellow };
                SolidColorBrush blackBrush = new SolidColorBrush { Color = Colors.Black };
                elipse.Stroke = blackBrush;
                elipse.Fill = yellowBrush;
                elipse.StrokeThickness = 4;

                main.WorkField.Children.Add(elipse);

                main.LengtOfSides.Text = "Lenght of sides: " + Sides();
                main.Surface.Text = "Surface: " + Surface();
            }
            public double Surface()
            {
                return PI * Math.Pow(radius, 2);
            }
            public double Sides()
            {
                return 2 * PI * radius;
            }
        }
        public class Trianglee : Shapee
        {
            private double a, b, c;

            MainWindow main = (MainWindow)Application.Current.MainWindow;

            public Trianglee(Point point1, Point point2, Point point3)
            {
                Polygon triangle = new Polygon();

                a = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
                b = Math.Sqrt(Math.Pow(point2.X - point3.X, 2) + Math.Pow(point2.Y - point3.Y, 2));
                c = Math.Sqrt(Math.Pow(point1.X - point3.X, 2) + Math.Pow(point1.Y - point3.Y, 2));

                PointCollection polygonPoints = new PointCollection();
                polygonPoints.Add(point1);
                polygonPoints.Add(point2);
                polygonPoints.Add(point3);
                triangle.Points = polygonPoints;

                SolidColorBrush yellowBrush = new SolidColorBrush();
                yellowBrush.Color = Colors.Yellow;
                SolidColorBrush blackBrush = new SolidColorBrush();
                blackBrush.Color = Colors.Black;
                triangle.Stroke = blackBrush;
                triangle.Fill = yellowBrush;
                triangle.StrokeThickness = 4;

                main.WorkField.Children.Add(triangle);

                main.LengtOfSides.Text = "Lenght of sides: " + Sides();
                main.Surface.Text = "Surface: " + Surface();
            }
            public double Surface()
            {
                double s = (a + b + c) / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
            public double Sides()
            {
                return a + b + c;
            }
        }
        public class Rectanglee : Shapee
        {
            private double a, b, c, d;

            MainWindow main = (MainWindow)Application.Current.MainWindow;

            public Rectanglee(Point point1, Point point2, Point point3, Point point4)
            {
                Polygon rectangle = new Polygon();

                a = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
                b = Math.Sqrt(Math.Pow(point3.X - point2.X, 2) + Math.Pow(point3.Y - point2.Y, 2));
                c = Math.Sqrt(Math.Pow(point4.X - point3.X, 2) + Math.Pow(point4.Y - point3.Y, 2));
                d = Math.Sqrt(Math.Pow(point1.X - point4.X, 2) + Math.Pow(point1.Y - point4.Y, 2));

                PointCollection rectanglePoints = new PointCollection();
                rectanglePoints.Add(point1);
                rectanglePoints.Add(point2);
                rectanglePoints.Add(point3);
                rectanglePoints.Add(point4);
                rectangle.Points = rectanglePoints;

                SolidColorBrush yellowBrush = new SolidColorBrush { Color = Colors.Yellow };
                SolidColorBrush blackBrush = new SolidColorBrush { Color = Colors.Black };
                rectangle.Stroke = blackBrush;
                rectangle.Fill = yellowBrush;
                rectangle.StrokeThickness = 4;

                main.WorkField.Children.Add(rectangle);

                main.LengtOfSides.Text = "Lenght of sides: " + Sides();
                main.Surface.Text = "Surface: " + Surface(rectanglePoints);
            }
            
            public double Surface(PointCollection points)
            {
                return Math.Abs(points.Take(points.Count - 1).Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y)).Sum() / 2);
            }
            public double Sides()
            {
                return a + b + c + d;
            }
        }
        public class Pentagonn : Shapee
        {
            private double a, b, c, d, e;

            MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;

            public Pentagonn(Point point1, Point point2, Point point3, Point point4, Point point5)
            {
                Polygon polygon = new Polygon();

                a = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
                b = Math.Sqrt(Math.Pow(point3.X - point2.X, 2) + Math.Pow(point3.Y - point2.Y, 2));
                c = Math.Sqrt(Math.Pow(point4.X - point3.X, 2) + Math.Pow(point4.Y - point3.Y, 2));
                d = Math.Sqrt(Math.Pow(point5.X - point4.X, 2) + Math.Pow(point5.Y - point4.Y, 2));
                e = Math.Sqrt(Math.Pow(point1.X - point5.X, 2) + Math.Pow(point1.Y - point5.Y, 2));

                PointCollection polygonPoints = new PointCollection();
                polygonPoints.Add(point1);
                polygonPoints.Add(point2);
                polygonPoints.Add(point3);
                polygonPoints.Add(point4);
                polygonPoints.Add(point5);
                polygon.Points = polygonPoints;

                SolidColorBrush yellowBrush = new SolidColorBrush { Color = Colors.Yellow };
                SolidColorBrush blackBrush = new SolidColorBrush { Color = Colors.Black };
                polygon.Stroke = blackBrush;
                polygon.Fill = yellowBrush;
                polygon.StrokeThickness = 4;

                main.WorkField.Children.Add(polygon);

                main.LengtOfSides.Text = "Lenght of sides: " + Sides();
                main.Surface.Text = "Surface: " + Surface(polygonPoints);
            }
            public double Surface(PointCollection points)
            {
                return Math.Abs(points.Take(points.Count - 1).Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y)).Sum() / 2);
            }
            public double Sides()
            {
                return a + b + c + d + e;
            }
        }
    }
}

