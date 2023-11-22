using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Wall.Wall_EEngine
{
    public static class ExpresionesRegulares
    {
        //Definiendo un punto
        public static string punto = @"^\s*point\s+(?<cuerpoin>.+)\;";

        public static string draw = @"^\s*draw\s+(?<pintar>.+)\;";



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



    }
}
