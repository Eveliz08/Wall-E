using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wall.Wall_EEngine;

namespace Wall_E.Wall_EEngine
{
    public static class Draw
    {
        public static List<string> SeparaDraw(List<string> draw)
        {   
            List<string> list = new List<string>();
            foreach (string d in draw)
            {
                if (ExpresionesRegulares.EsConstructor(d).Success||ExpresionesRegulares.EsVariable(d))
                {
                    list.Add(d);
                }
            }
            return list;
        }
        //Metodo generico para dibujar segun el tipo que se desea dibujar
       /* public static void SimpleDraw(string figura, Dictionary<string, IElements> variables, Canvas lienzo)
        {
            if (variables.ContainsKey(figura))
            {
                variables[figura].Dibuja(lienzo);
            }
        }*/
    }
}
