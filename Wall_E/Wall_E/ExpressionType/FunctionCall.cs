using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walle
{
    public class FunctionCall : IExpressionType
    {
        public string identificador { get; }
        public ExpressionType expressiontype { get; }
        public List<object> parametros { get; }


        public FunctionCall(List<Token> tokens)
        {
            parametros = new List<object>();
            expressiontype = ExpressionType.FunctionCall;
            identificador = tokens[0].Value;


            if (tokens[1].Value == "(")
            {
                int i = 2;
                int cont = 1;
                List<Token> list = new List<Token>();
                for (int j = i; j < tokens.Count; j++)
                {
                    if (tokens[j].Value == ")") cont--;
                    if (tokens[j].Value == "(") cont++;

                    if ((tokens[j].Value == "," && cont == 1) || j == tokens.Count - 1)
                    {
                        List<object> parametro = Parser.Return(list);
                        if (parametro.Count == 1)
                        {
                            parametros.Add(parametro[0]);
                            list.Clear();
                        }
                        else
                        {
                            //Crear una secuencia con con la lista dada
                        }
                    }
                    else //if (tokens[j].Type == TokenType.Identifier || tokens[j].Type == TokenType.Number)
                        list.Add(tokens[j]);
                }


            }
        }
        public object Evaluate()
        {

            if (Parser.funciones.ContainsKey(identificador))
            {

                if (Parser.funciones[identificador].parámetros.Count != parametros.Count)
                {
                    throw new Exception("Ninguna sobrecarga de la funcion " + identificador + " recibe " + parametros.Count + " parametros");
                }
                for (int i = 0; i < parametros.Count; i++)
                {
                    try
                    {
                        Parser.constantes.Add(Parser.funciones[identificador].parámetros[i], parametros[i]);
                    }
                    catch (ArgumentException e)
                    {
                        throw e;
                    }
                }

                IExpressionType expresion = Parser.Parse(Parser.funciones[identificador].cuerpo);
                for (int i = 0; i < parametros.Count; i++)
                {
                    Parser.constantes.Remove(Parser.funciones[identificador].parámetros[i]);
                }
                return expresion.Evaluate();
            }
            else
            {
                throw new Exception("La funcion " + identificador + " no esta definida");
            }
        }
    }
}
