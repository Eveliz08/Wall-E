namespace Walle;
public interface IExpressionType
{
    public object Evaluate();
    public ExpressionType expressiontype { get; }
}
