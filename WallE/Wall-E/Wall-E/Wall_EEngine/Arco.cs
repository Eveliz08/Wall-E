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


namespace Wall_E.Wall_EEngine
{
    internal class Arco : IElements
    {
        public Point  Centro { get; set; } //Segmento de inicio del arco
        public Point P2 { get; set; } //Segmento de fin del arco
        public Point P3 { get; set; } //Segmento de fin del arco
        public Measure Radio { get; set; }
        //Constructo
        public Arco(Point centro, Point  p2, Point p3,Measure radio)
        {   
            Centro = centro;
            P2 = p2;
            P3 = p3;
            Radio = radio;
        }

        // Método para dibujar el arco en un Canvas
        public void Dibuja(Canvas canvas)
        {

            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext ctx = streamGeometry.Open())
            {
                ctx.BeginFigure(P2, false, false); //Centro 
                ctx.ArcTo(P3, new Size(Radio.valor, Radio.valor), 0, false, SweepDirection.Counterclockwise, true, false);
                // ctx.LineTo(Centro,true,false);

            };


            Path arco = new Path();
            arco.Stroke = Brushes.Black; // Color del arco
                                         //  arco.StrokeThickness = 2; // Grosor del arco
            arco.Data = streamGeometry;


            //canvas.Children.Add(arco);

            //PathGeometry pathGeometry = new PathGeometry();
            //PathFigure pathFigure = new PathFigure();
            //pathFigure.StartPoint = new Point(P2.X, P2.Y); // Punto inicial del arco

            //ArcSegment arcSegment = new ArcSegment();
            //arcSegment.Point = new Point(P3.X, P3.Y); // Punto final del arco
            //arcSegment.Size = new Size(Radio.valor, Radio.valor); // Tamaño del arco
            //arcSegment.SweepDirection = SweepDirection.Counterclockwise; // Dirección del arco (sentido contrario a las agujas del reloj)
            //arcSegment.IsLargeArc = true; // Dibuja un arco mayor de 180 grados

            //pathFigure.Segments.Add(arcSegment);
            //pathGeometry.Figures.Add(pathFigure);

            //arco.Data = pathGeometry;

            // Agrega el arco al Canvas
            canvas.Children.Add(arco);
        }
    }


}

