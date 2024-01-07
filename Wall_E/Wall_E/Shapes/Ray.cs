using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Line = System.Windows.Shapes.Line;

namespace Walle;

public class Ray : Linea
{

    //P1 es de donde sale el rayo
    public Ray(Point p1, Point p2) : base(p1, p2)
    {
    }
    public Ray(string identificador):base(identificador)
    {

    }
    public override void Dibuja(Canvas lienzo)
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
        line.X1 = this.p1.x;
        line.Y1 = this.p1.y;

        if (pendiente > 0)
        {
            if (this.p1.x < this.p2.x)
            {
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
                if (n > cero)
                {
                    line.X2 = intersectoY.x;
                    line.Y2 = intersectoY.y;
                }
                else
                {
                    line.X2 = intersectoX.x;
                    line.Y2 = intersectoX.y;
                }
                this.p1.Dibuja(lienzo);
                this.p2.Dibuja(lienzo);
                lienzo.Children.Add(line);
            }
        }
        else
        {
            if (this.p1.x < this.p2.x)
            {
                if (intersectoX.x < points[1].x)
                {
                    line.X2 = intersectoX.x;
                    line.Y2 = intersectoX.y;
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
                if (intersectoY.x > points[0].x)
                {
                    line.X2 = intersectoY.x;
                    line.Y2 = intersectoY.y;
                }
                else
                {
                    line.X2 = points[0].x;
                    line.Y2 = points[0].y;
                }
                this.p1.Dibuja(lienzo);
                this.p2.Dibuja(lienzo);
                lienzo.Children.Add(line);
            }


        }
    }

}


