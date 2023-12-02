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
            this.pendiente = p2.y - p1.y / p2.x - p1.x;
        }

        public void Dibuja(Canvas lienzo)
        {
            
            Line line = new Line();
            //Color
            line.Stroke = Brushes.Black;
            line.X1 = this.p1.x;
            line.Y1 = this.p1.y;
            line.X2 = this.p2.x;
            line.Y2 = this.p2.y;

           // double factor = lienzo.Width/Math.Sqrt(Math.Pow(line.X2-line.X1, 2) + Math.Pow(line.Y2-line.Y1, 2));
           // line.RenderTransform = new ScaleTransform(factor,factor);


            //double pendiente = this.pendiente;
            ////Calcular interseccion con el borde derecho del lienzo
            //double yInterseccionDerecha = this.p2.y + (lienzo.Width - this.p2.x) / pendiente;
            ////Calcular interseccion con el borde inferior del lienzo
            //double xInterseccionInferior = this.p2.x + (lienzo.Height - this.p2.y) / pendiente;

            //if(yInterseccionDerecha >= 0 && yInterseccionDerecha <= lienzo.Height)
            //{
            //    line.X1 = this.p1.x;
            //    line.Y1 = this.p1.y;
            //    line.X2 = lienzo.Width;
            //    line.Y2 = yInterseccionDerecha;
            //}
            //else
            //{
            //    line.X1 = this.p1.x;
            //    line.Y1 = this.p1.y;
            //    line.X2 = xInterseccionInferior;
            //    line.Y2 = lienzo.Height;
            //}

            lienzo.Children.Add(line);


          
               // line.StrokeDashArray = new DoubleCollection(new double[] { 4, 2 });
           
        }
    }
}
