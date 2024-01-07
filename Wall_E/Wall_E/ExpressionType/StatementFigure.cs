namespace Walle;
public class Statement: IExpressionType
{
    public ExpressionType expressiontype { get; }
    private readonly string tipo;
    private readonly string identificador;

    public Statement(ExpressionType expressionType, string tipo, string identificador)
    {
        this.expressiontype = expressionType;
        this.tipo = tipo;
        this.identificador = identificador;
    }

    public object Evaluate()
    {
        if (tipo == "point")
        {
            Point point = new Point(identificador);
            return point;
        }
        else if (tipo == "circle")
        {
            Circle circle = new Circle(identificador);
            return circle;
        }
        else if (tipo == "line")
        {
            Linea line = new Linea(identificador);
            return line;
        }
        else if (tipo == "segment")
        {
            Segment segment = new Segment(identificador);
            return segment;
        }
        else if (tipo == "ray")
        {
            Ray ray = new Ray(identificador);
            return ray;
        }
        else
        {
            Arc arc = new Arc(identificador);
            return arc;
        }
    }


}
