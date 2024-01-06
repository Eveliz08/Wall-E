
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Wall.Wall_EEngine;

namespace Wall_E.Wall_EEngine
{
    public class Segment : Linea
    {
        public Segment(Point p1, Point p2) : base(p1, p2)
        {
        }
        public override void Dibuja(Canvas lienzo)
        {
            Line line = new Line
            {
                //Color
                Stroke = Brushes.Black
            };

            line.X1 = this.p1.x;
            line.Y1 = this.p1.y;
            line.X2 = this.p2.x;
            line.Y2 = this.p2.y;
            this.p1.Dibuja(lienzo);
            this.p2.Dibuja(lienzo);
            lienzo.Children.Add(line);
        }
    }
}
