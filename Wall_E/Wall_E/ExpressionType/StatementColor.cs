namespace Walle;
public class StatementColor : IExpressionType
{
    public string color;
    public ExpressionType expressiontype { get; }
    public StatementColor(string color)
    {
        this.color = color;
        expressiontype = ExpressionType.Color;
    }
    public object Evaluate()
    {
        Parser.color.Push(color);
        return color;
    }

}
