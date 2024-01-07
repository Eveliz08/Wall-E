using System.Collections.Generic;

namespace Walle;
public class StatementFunction: IExpressionType
{   
    public ExpressionType expressiontype { get;}
    public string identificador { get; }
    public List<string> parámetros { get; }
    public List<Token> cuerpo { get; }

    public StatementFunction(List<Token> instruccion)
    {
        identificador = instruccion[0].Value;
        parámetros = new List<string>();
        cuerpo = new List<Token>();
        expressiontype = ExpressionType.StatementFunction;
    
        int i = 0;

        if (instruccion[1].Value == "(")
        {
            i = 2;
            while (instruccion[i].Value != ")")
            {
                
                if (instruccion[i].Type == TokenType.Identifier)
                    parámetros.Add(instruccion[i].Value);
                else if (instruccion[i].Value != ",")
                {

                }
                else
                {
                    //Lanzar excepción
                }
                i++;
            }
        }
        else
        {
            //Lanzar excepción
        }

        if(instruccion[i].Value == "=")
        {
            cuerpo.CopyTo(instruccion.ToArray(), i+1);
        }
        else
        {
            //Lanzar excepción

        }

    }

    public object Evaluate()
    {   

        return null;
    }
}
