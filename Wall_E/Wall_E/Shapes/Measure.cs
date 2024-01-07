using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walle;

public class Measure
{
    public int valor { get; private set; }
    public Measure(double valor)
    {
        this.valor = Math.Abs((int)valor);
    }

    public static Measure DistanciaPuntos(Point p1, Point p2)
    {
        double distancia = Math.Sqrt(Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2));
        return new Measure(distancia);
    }
    public static Measure DistanciaPuntoRecta(Point p, Linea l)
    {
        double A = -l.pendiente;
        double B = 1;
        double C = l.pendiente * l.p1.x - l.p1.y;

        double result = Math.Abs(A * p.x + B * p.y + C) / Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
        return new Measure(result);

    }
}

