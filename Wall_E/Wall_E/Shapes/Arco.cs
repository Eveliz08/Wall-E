using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
//using Wall.Wall_EEngine;


namespace Walle;

internal class Arc : IFigure
{
    public Point Centro { get; set; } //Segmento de inicio del arco
    public Point P2 { get; set; } //Segmento de fin del arco
    public Point P3 { get; set; } //Segmento de fin del arco
    public Measure Radio { get; set; }
    public string identificador { get; set; }
    //Constructo
    public Arc(Point centro, Point p2, Point p3, Measure radio, string identificador)
    {
        this.identificador = identificador;
        Centro = centro;
        P2 = p2;
        P3 = p3;
        Radio = radio;
    }
    public Arc(string identificador)
    {
        this.identificador = identificador;
        Centro = new Point();
        P2 = new Point();
        P3 = new Point();
        Radio = new Measure(50);

    }

    // Método para dibujar el arco en un Canvas
    public void Dibuja(Canvas canvas)
    {

        PathGeometry pathGeometry = new PathGeometry();
        PathFigure pathFigure = new PathFigure();
        pathFigure.StartPoint = P2.GetPoint(); // Punto inicial del arco

        ArcSegment arcSegment = new ArcSegment();
        arcSegment.Point = P3.GetPoint(); // Punto final del arco
        arcSegment.Size = new Size(Radio.valor, Radio.valor); // Tamaño del arco
        arcSegment.SweepDirection = SweepDirection.Counterclockwise; // Dirección del arco (sentido contrario a las agujas del reloj)
        double angle = Linea.FindAngleBetweenLines(Centro, P2, Centro, P3);
        if (angle > 180)
        {
            arcSegment.IsLargeArc = true; // Dibuja un arco mayor de 180 grados
        }
        else
        {
            arcSegment.IsLargeArc = false; // Dibuja un arco menor de 180 grados
        }


        pathFigure.Segments.Add(arcSegment);
        pathGeometry.Figures.Add(pathFigure);

        Path path = new Path();
        path.Data = pathGeometry;
        path.Stroke = Brushes.Black;
        path.StrokeThickness = 2;

        // Agrega el arco al Canvas
        canvas.Children.Add(path);
    }
}


