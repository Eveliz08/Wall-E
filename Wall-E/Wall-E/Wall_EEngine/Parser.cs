using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wall_E;

namespace Wall.Wall_EEngine
{
    public static class Parser
    {
        public static Dictionary<string, dynamic> variables = new Dictionary<string, dynamic>();

        public static string[] palabrasreservadas { get; } = new string[] { "if", "else", "let", "in", "then", "point", "circle" };
        public static void QueEs(string linea, Canvas lienzo)
        {
            if (ExpresionesRegulares.EsPunto(linea).Success)
            {
                Match match = ExpresionesRegulares.EsPunto(linea);
                if (EsVariable(match.Groups[1].ToString()))
                {
                    Point p = new Point(lienzo);
                    variables.Add(match.Groups[1].ToString(), p);
                    p.Dibuja(p, lienzo);
                }
                else if(ExpresionesRegulares.EsDraw(linea).Success)
                {

                }
                else
                    throw new Exception("Nombre incorrecto");
            }
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
