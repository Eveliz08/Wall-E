using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E.Wall_EEngine
{
    public static class Lexer
    {
        //Metodo para tokenizar un string
        public static List<string> Tokenizador(string input)
        {
            List<string> tokens = new List<string>();
            //  bool recorriendostring = false;
            string tokenactual = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (Cambio(input[i]))
                {
                    //tokenactual.Trim();
                    if (tokenactual != "")
                    {
                        tokens.Add(tokenactual.Trim());
                        tokenactual = "";
                    }
                    if (!EsEspacio(input[i]))
                    {
                        tokens.Add(input[i].ToString());
                        continue;
                    }
                    continue;
                }

                tokenactual += input[i];
                if (EsFinal(i, input.Length - 1))
                {
                    tokens.Add(tokenactual.Trim());
                }
            }

            for (int i = 1; i < tokens.Count - 1; i++)
            {

                if (EsComparador(tokens[i - 1], tokens[i], tokens[i + 1]))
                {
                    string cambio = tokens[i - 1].ToString() + tokens[i];
                    tokens.RemoveRange(i - 1, 2);
                    tokens.Insert(i - 1, cambio);
                }
            }

            return tokens;
            ///////////

        }
        //Metodo para identificar cuando un caracter es un cambio de token
        static bool Cambio(char caracter)
        {
            switch (caracter)
            {
                case '(': return true;
                case ')': return true;
                case ',': return true;
                case '.': return true;
                case '-': return true;
                case '/': return true;
                case '^': return true;
                case '%': return true;
                case '+': return true;
                case '*': return true;
                case '!': return true;
                case '=': return true;
                case '<': return true;
                case '>': return true;
                case ' ': return true;
                case '"': return true;
                case '@': return true;
                case '\n': return true;
                case '\r': return true;
                case ';': return true;
            }
            return false;
        }
        //Metodo para identificar si estamos al final del string
        static bool EsFinal(int posicion, int length)
        {
            return posicion == length;
        }
        //Metodo para identificar si un caracter es un espacio en blanco
        static bool EsEspacio(char caracter)
        {
            if (caracter == ' ') return true;
            return false;
        }
        //Metodo para identificar si tenemos comparadores "compuestos"
        static bool EsComparador(string caracter1, string caracter2, string caracter3)
        {
            if (caracter1 == "!")
            {
                switch (caracter2)
                {
                    case "<": return true;
                    case ">": return true;
                    case "=": return true;
                }
            }

            if (caracter2 == "=")
            {
                switch (caracter1)
                {
                    case "<": return true;
                    case ">": return true;
                    case "=": return true;
                }
            }
            /* switch (caracter2)
             {
                 case "<": return true;
                 case ">": return true;

             }*/

            return false;

        }
        //Metodo para separar la instruccion linea por linea
        public static List<List<string>> SeparaPorLinea(List<string> tokens)
        {
            //comprobar si estamos dentro de una expresion let in
            bool flag = false;
            int cont = 0;
            List<List<string>> lineas = new List<List<string>>();
            List<string> linea = new List<string>();
            for (int i = 0; i < tokens.Count; i++)
            {
                linea.Add(tokens[i]);
                if (tokens[i] == "let")
                {
                    cont++;
                    flag = true;
                }
                else if (tokens[i] == "in")
                {
                    cont--;
                    if (cont == 0)
                    {
                        flag = false;
                    }
                }
                if (tokens[i] == ";" && !flag)
                {
                    lineas.Add(linea);
                    linea = new List<string>();
                }

            }
            return lineas;
        }

    }
}
