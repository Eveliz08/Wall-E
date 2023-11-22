using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Wall_E.Wall_EEngine;
using Point = Wall.Wall_EEngine.Point;


namespace Wall.Wall_EEngine
{
    public class Point:Elements<Point>
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int grosor;

        public Point(Canvas lienzo)
        {
            grosor = 5;
            Random rnd = new Random();
            x = rnd.Next(0, (int)lienzo.ActualWidth);
            y = rnd.Next(0, (int)lienzo.ActualHeight);

        }
        //Metodo para dibujar un punto en el lienzo
        public void Dibuja( Point p, Canvas lienzo)
        {
            Ellipse punto = new Ellipse
            {
                Width = p.grosor,
                Height = p.grosor,
                Fill = Brushes.Black
            };

            Canvas.SetLeft(punto, p.x);
            Canvas.SetTop(punto, p.y);

            lienzo.Children.Add(punto);
        }

    }
}
