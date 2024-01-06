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
    public class Linea : IElements
    {
        public Point p1 { get; }
        public Point p2 { get; }
        public double pendiente { get; }
        public Linea(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.pendiente = (p2.y - p1.y) / (p2.x - p1.x);
        }


        public virtual Point[] IntersectosPendienteNegativa(double m, Point p, Canvas lienzo)
        {
            Point[] result = new Point[2];
            double n = p.y - m * p.x;
            double x = (lienzo.ActualHeight - n) / m;
            //X
            result[0] = new Point(x, lienzo.ActualHeight);
            double y = (lienzo.ActualWidth * m) + n;
            //Y
            result[1] = new Point(lienzo.ActualWidth, y);
            return result;

        }

        public virtual void Dibuja(Canvas lienzo)
        {

            //Calculo de la pendiente
            double pendiente = this.pendiente;
            //Interseccion con el eje Y
            double n = this.p1.y - pendiente * this.p1.x;
            //Interseccion con el eje X
            double cero = -n / pendiente;
            //Interseccion con los ejes derechos del CANVAS
            Point[] points = IntersectosPendienteNegativa(pendiente, this.p1, lienzo);
            Line line = new Line
            {
                //Color
                Stroke = Brushes.Black
            };

            Point intersectoY = new Point(0, n);
            Point intersectoX = new Point(cero, 0);

            if (pendiente > 0)
            {
                if (n > cero)
                {
                    line.X1 = intersectoY.x;
                    line.Y1 = intersectoY.y;
                    if (points[0].x < points[1].x)
                    {
                        line.X2 = points[0].x;
                        line.Y2 = points[0].y;
                    }
                    else
                    {
                        line.X2 = points[1].x;
                        line.Y2 = points[1].y;
                    }
                    this.p1.Dibuja(lienzo);
                    this.p2.Dibuja(lienzo);
                    lienzo.Children.Add(line);

                }
                else
                {
                    line.X1 = intersectoX.x;
                    line.Y1 = intersectoX.y;
                    if (points[0].x < points[1].x)
                    {
                        line.X2 = points[0].x;
                        line.Y2 = points[0].y;
                    }
                    else
                    {
                        line.X2 = points[1].x;
                        line.Y2 = points[1].y;
                    }
                    this.p1.Dibuja(lienzo);
                    this.p2.Dibuja(lienzo);
                    lienzo.Children.Add(line);
                }
            }
            else
            {
                if (points[1].x > intersectoX.x)
                {
                    line.X1 = intersectoX.x;
                    line.Y1 = intersectoX.y;
                    if (points[0].x > intersectoY.x)
                    {
                        line.X2 = points[0].x;
                        line.Y2 = points[0].y;

                    }
                    else
                    {
                        line.X2 = intersectoY.x;
                        line.Y2 = intersectoY.y;
                    }
                    this.p1.Dibuja(lienzo);
                    this.p2.Dibuja(lienzo);
                    lienzo.Children.Add(line);

                }
                else
                {
                    line.X1 = points[1].x;
                    line.Y1 = points[1].y;
                     if (points[0].x > intersectoY.x)
                    {
                        line.X2 = points[0].x;
                        line.Y2 = points[0].y;

                    }
                    else
                    {
                        line.X2 = intersectoY.x;
                        line.Y2 = intersectoY.y;
                    }
                    this.p1.Dibuja(lienzo);
                    this.p2.Dibuja(lienzo);
                    lienzo.Children.Add(line);


                }
            }

        }
    }
}
