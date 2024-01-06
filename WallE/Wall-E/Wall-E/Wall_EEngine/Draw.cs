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
        /*  public static List<string> SeparaDraw(List<string> draw)
          {   
              List<string> list = new List<string>();
              foreach (string d in draw)
              {
                  if (Expresiones.EsConstructor(d).Success||Expresiones.EsVariable(d))
                  {
                      list.Add(d);
                  }
              }
              return list;
          }
          //Metodo generico para dibujar segun el tipo que se desea dibujar*/
        public static void SimpleDraw(string figura, Dictionary<string, object> variables, Canvas lienzo)
        {
            //if (variables.ContainsKey(figura))
            //{
            //    variables[figura].Dibuja(lienzo);
            //}
            //   Obtener la secuencia que se quiere dibujar en caso de que sea una secuencia
            // List<string> dibujos = Draw.SeparaDraw(Lexer.Tokenizador(linea));
            //Recorrer todo lo que se quiere dibujar
            //  foreach (string d in dibujos)
            //   {   //Si el nombre de lo que se quiere dibujar es una variable
            if (Expresiones.EsVariable(figura))
            {
                if (variables.TryGetValue(figura, out object valorAlmacenado))
                {
                    if (valorAlmacenado is IElements objetoConInterfaz)
                    {
                        objetoConInterfaz.Dibuja(lienzo);
                    }
                    else
                        throw new Exception("La variable " + figura + " no es dibujable");
                }
                else
                    throw new Exception("La Variable " + figura + " no esta definida");
            }
            //Si no es una variable ver si es el constructor de algun tipo
            //else if (Expresiones.EsConstructor(d).Success)
            //{
            //    // Crear switch case para los distintos tipos de constructores luego de tener las clases y los parametros que se necesitan
            //}
            else
                throw new Exception("Lo que se quiere dibujar no es correcto");
            //   }
        }
    }
}
