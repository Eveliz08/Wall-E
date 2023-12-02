using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Wall.Wall_EEngine;

namespace Wall_E.Wall_EEngine
{
    public class Circle : IElements
    {
        //Centro de la circunferencia
        public Point centro { get; private set; }
        //Radio de la circunferencia
        public double radio { get; private set; }

        public Circle(Point c, double r)
        {
            this.centro = c;
            this.radio = r;
        }
        //Metodo que dibuja una circunferencia
        public void Dibuja(Canvas lienzo)
        {
            Ellipse circunferencia = new Ellipse
            {
                Width = this.radio * 2,
                Height = this.radio * 2,
                Fill = null,
                Stroke = Brushes.Black,
            };
            
            Canvas.SetLeft(circunferencia, this.centro.x-radio);
            Canvas.SetTop(circunferencia, this.centro.y-radio);

            lienzo.Children.Add(circunferencia);
        }

        //Metodo para saber si un circulo se puede dibujar en el lienzo
        public static bool SePuedeDibujar(Circle c, Canvas lienzo)
        {
            double radio = c.radio;
            double x = c.centro.x;
            double y = c.centro.y;

            if (x - radio > 0 && y - radio > 0 && x + radio < lienzo.ActualWidth && y + radio < lienzo.ActualHeight)
                return true;
            return false;
        }
    }
}
