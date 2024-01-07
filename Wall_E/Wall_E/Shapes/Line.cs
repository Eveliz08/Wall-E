using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Walle;

public class Linea : IFigure
{
    public Point p1 { get; }
    public Point p2 { get; }
    public double pendiente { get; }
    public string identificador { get; }
    public Linea(Point p1, Point p2)
    {
        identificador = "";
        this.p1 = p1;
        this.p2 = p2;
        this.pendiente = (p2.y - p1.y) / (p2.x - p1.x);
    }
    public Linea(string identificador)
    {
        this.identificador = identificador;
        p1 = new Point();
        p2 = new Point();
        pendiente = (p2.y - p1.y) / (p2.x - p1.x);
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
    public static double FindAngleBetweenLines(Point start1, Point end1, Point start2, Point end2)
    {
        // Calcular los vectores que representan las rectas
        Linea vector1 = new Linea(start1, end1);
        Linea vector2 = new Linea(start2, end2);

        //θ = arctan((m_2 - m_1) / (1 + m_1 · m_2))
        double angleInDegrees = Math.Atan2(vector2.pendiente - vector1.pendiente, 1 + vector1.pendiente * vector2.pendiente) * (180 / Math.PI); ;
        //   double angleInDegrees = angleInRadians * (180 / Math.PI);
        // Convertir a grados
        // Calcular el ángulo entre los vectores utilizando el arcotangente
        // double angle = Math.Atan2(vector2.y, vector2.x) - Math.Atan2(vector1.y, vector1.x);
        //  angle = angle * 180 / Math.PI;  // Convertir de radianes a grados

        // Asegurarse de devolver un ángulo positivo (entre 0 y 360 grados)
        if (angleInDegrees < 0)
        {
            angleInDegrees += 360;
        }
        return angleInDegrees;
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
        System.Windows.Shapes.Line line = new System.Windows.Shapes.Line
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

