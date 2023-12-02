using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Wall.Wall_EEngine
{
    public static class ExpresionesRegulares
    {   //Palabras reservadas del lenguaje
        public static string[] palabrasreservadas { get; } = new string[] { "if", "else", "let", "in", "then", "point", "circle", "draw" };
        //Definiendo un punto
        public static string punto = @"^\s*point\s+(?<cuerpoin>.+)";

        public static string draw = @"^\s*draw";

        //public static string draw2 = @"^\s*draw\s*{\(?<pintar>.+)\}";

        public static string constructor = @"\s*(?<type>.+)\s*(\(?<parametros>.+)\)";






        public static Match EsPunto(string expresion)
        {
            Match match = Regex.Match(expresion, punto);
            return match;
        }
        public static Match EsDraw(string expresion)
        {
            Match match = Regex.Match(expresion, draw);
            return match;
        }
        /*public static Match EsDraw2(string expresion)
        {
            Match match = Regex.Match(expresion, draw2);
            return match;
        }*/
        public static Match EsConstructor(string expresion)
        {
            Match match = Regex.Match(expresion, constructor);
            return match;
        }
        public static bool EsVariable(string v)
        {   //Patron de variables
            string variable = @"^[a-zA-Z]+[\w]*";
            Match match = Regex.Match(v, variable);
            if (match.Success)
            {   //Excluir el caso de que sea una palabra reservada
                for (int i = 0; i < palabrasreservadas.Length; i++)
                {
                    if (v == palabrasreservadas[i]) return false;
                }
                return true;
            }
            return false;
        }




    }
}
