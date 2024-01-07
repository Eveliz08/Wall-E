using System;
using System.Collections.Generic;
using System.Drawing;

namespace Walle;
public static class Parser
{
    public static Stack<string> color = new Stack<string>();
    public static Dictionary<string, object> variables = new Dictionary<string, object>();
    public static string[] coloresvalidos = new string[] { "blue", "red", "yellow", "green", "black", "white", "magenta", "gray", "cyan" };
    public static Dictionary<string, object> constantes = new Dictionary<string, object>();
    public static Dictionary<string, StatementFunction> funciones = new Dictionary<string, StatementFunction>();
    public static List<Draw> draws = new List<Draw>();

    public static IEnumerable<List<Token>> SeparaPorLinea(List<Token> tokens)
    {
        //comprobar si estamos dentro de una expresion let in
        bool flag = false;
        int cont = 0;
        // List<List<string>> lineas = new List<List<string>>();
        List<Token> linea = new List<Token>();
        for (int i = 0; i < tokens.Count; i++)
        {
            linea.Add(tokens[i]);
            if (tokens[i].Value == "let")
            {
                cont++;
                flag = true;
            }
            else if (tokens[i].Value == "in")
            {
                cont--;
                if (cont == 0)
                {
                    flag = false;
                }
            }
            if (tokens[i].Value == ";" && !flag)
            {
                yield return linea;
                linea = new List<Token>();
            }

        }

    }
    public static IExpressionType Parse(List<Token> instruction)
    {
        if (instruction[0].Type == TokenType.Shape)
        {
            if (instruction.Count != 2 || instruction[1].Type != TokenType.Identifier) {/*Lanzar excepcion*/}

            return new StatementFigure(ExpressionType.StatementShapes, instruction[0].Value, instruction[1].Value);
        }
        else if (instruction[0].Value == TokenValues.color)
        {
            if (instruction.Count != 2) {/*Lanzar excepcion*/}
            return new StatementColor(instruction[1].Value);

        }
        else if (instruction[0].Value == TokenValues.import)
        {
            if (instruction.Count != 2 || instruction[1].Type != TokenType.Text) {/*Lanzar excepcion*/}

            return new Import(ExpressionType.Import, instruction[1].Value);
        }
        else if (instruction[0].Value == TokenValues.draw)
        {
            if (instruction.Count == 1)
                throw new Exception("La instruccion draw de la linea " + instruction[0].Location.File + "no recibe objetos a dibujar");
            instruction.RemoveAt(0);
            return new Draw(instruction);
        }
        else if (instruction[0].Value == TokenValues.print)
        {

        }
        return null;
    }

    public static bool EstáIdentificadorDeclarado(string identificador, out object valor)
    {
        //Se pregunta si el identificador es clase del diccionario con los tipos declarados
        if (variables.ContainsKey(identificador))
        {
            valor = variables[identificador];
            return true;
        }
        else if (constantes.ContainsKey(identificador))
        {
            valor = constantes[identificador];
            return true;
        }
        else
        {
            valor = null;
            return false;

        }

    }

    public static List<object> Return(List<Token> tokens)
    {
        List<object> valores = new List<object>();
        if (tokens.Count == 1)
        {
            if (tokens[0].Type == TokenType.Keyword)
            {
                if (EstáIdentificadorDeclarado(tokens[0].Value, out object valor))
                {
                    valores.Add(valor);
                    return valores;
                }
                else
                    throw new Exception("El identificador no esta delarado");
            }
            else
                throw new Exception("El token " + tokens[0].Value + " en la fila " + tokens[0].Location.File + " y la columna " + tokens[0].Location.Column + " no es un identificador");
        }
        else if (tokens[0].Value == "{" || tokens[tokens.Count - 1].Value == "}")
        {
            if (tokens[0].Value == "{" && tokens[tokens.Count - 1].Value == "}")
            {
                for (int i = 1; i < tokens.Count - 2; i++)
                {
                    if (tokens[i].Type == TokenType.Identifier)
                    {
                        if (Parser.EstáIdentificadorDeclarado(tokens[i].Value, out object valor))
                        {
                            valores.Add(valor);
                        }
                        else { throw new Exception("El identificador " + tokens[i].Value + " en la fila " + tokens[i].Location.File + " y la columna " + tokens[i].Location.Column + " no esta declarado"); }
                    }
                    else if (tokens[i].Value == ",")
                    {

                    }
                    else if (tokens[i].Type == TokenType.Number)
                    {
                        valores.Add(tokens[i].Value);
                    }
                    else
                        throw new Exception("El token " + tokens[i].Value + " de la secuencia de la linea " + tokens[i].Location.File + " es invalido");
                }
            }
            else
            {
                throw new Exception((tokens[0].Value == "{") ? "Se esperaba un } en la linea" + tokens[0].Location.File : "Se esperaba un { en la linea" + tokens[0].Location.File);
            }

        }
        else if ((tokens[0].Type == TokenType.Identifier || tokens[0].Type == TokenType.Shape) && tokens[1].Value == "(")
        {

        }
        return valores;

    }


}
