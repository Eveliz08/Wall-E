using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Wall_E.Wall_EEngine;
using System.Windows;
//using Point = Wall.Wall_EEngine.Point;


namespace Wall.Wall_EEngine
{
    public class Point : IElements
    {
        public double x { get; private set; }
        public double y { get; private set; }
        public int grosor;

        public Point(Canvas lienzo)
        {
            grosor = 2;
            Random rnd = new Random();
            x = rnd.Next(0, (int)lienzo.ActualWidth);
            y = rnd.Next(0, (int)lienzo.ActualHeight);
        }
        public Point(double x, double y)
        {
            grosor = 2;
            //Random rnd = new Random();
            this.x = x;
            this.y = y;
        }
        //Metodo para dibujar un punto en el lienzo
        public void Dibuja(Canvas lienzo)
        {
            Ellipse punto = new Ellipse
            {
                Width = this.grosor * 2,
                Height = this.grosor * 2,
                Fill = Brushes.Black
            };

            Canvas.SetLeft(punto, this.x - grosor);
            Canvas.SetTop(punto, this.y - grosor);

            lienzo.Children.Add(punto);
        }

        public System.Windows.Point GetPoint()
        {
            return new System.Windows.Point(this.x, this.y);
        }

        public static Point ObtenerPunto(Point centro, Point p2, Measure radio)
        {
            Linea recta = new Linea(centro, p2);
            double X2;
            double Y2;
            if (centro.x <= p2.x)
            {
                X2 = centro.x + radio.valor / Math.Sqrt(1 + Math.Pow(recta.pendiente, 2));
                Y2 = centro.y + (recta.pendiente * radio.valor) / Math.Sqrt(1 + Math.Pow(recta.pendiente, 2));
            }
            else
            {
                X2 = centro.x - radio.valor / Math.Sqrt(1 + Math.Pow(recta.pendiente, 2));
                Y2 = centro.y - (recta.pendiente * radio.valor) / Math.Sqrt(1 + Math.Pow(recta.pendiente, 2));
            }
            return new Point(X2, Y2);
        }
    }
}
