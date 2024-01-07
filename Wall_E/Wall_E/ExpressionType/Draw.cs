using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Walle;
public class Draw : IExpressionType
{
    public ExpressionType expressiontype { get; }
    public string etiqueta;
    public List<Token> cuerpoDraw;

    public Draw(List<Token> tokens)
    {
        cuerpoDraw = tokens;
        expressiontype = ExpressionType.Draw;
    }

    public object Evaluate()
    {
        if (cuerpoDraw[cuerpoDraw.Count - 1].Type == TokenType.Text)
        {
            etiqueta = cuerpoDraw[cuerpoDraw.Count - 1].Value;
            cuerpoDraw.RemoveAt(cuerpoDraw.Count - 1);
        }

        List<object> figuras = Parser.Return(cuerpoDraw);

        if (!(figuras[0] is IFigure))
        {
            throw new Exception("La instruccion draw de la linea " + cuerpoDraw[0].Location.File + " recibe objetos que no son dibujables");
        }

        return figuras;
    }

   

}
