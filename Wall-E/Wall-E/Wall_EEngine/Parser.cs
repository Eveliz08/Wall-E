using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wall_E;
using Wall_E.Wall_EEngine;

namespace Wall.Wall_EEngine
{
    public static class Parser
    {   
        //Diccionario que contiene las variables
        public static Dictionary<string, object> variables = new Dictionary<string, object>();

        public static void Reset()
        {
            variables.Clear();
        }

        //Metodo para parsear
        public static void QueEs(string linea, Canvas lienzo)
        {   
            //Identificar si es un punto
            if (ExpresionesRegulares.EsPunto(linea).Success)
            {   //Obtener el nombre de dicho punto
                Match match = ExpresionesRegulares.EsPunto(linea);
                if (ExpresionesRegulares.EsVariable(match.Groups[1].ToString()))
                {
                    Point p = new Point(lienzo);
                    variables.Add(match.Groups[1].ToString(), p);
                    //p.Dibuja(p, lienzo);
                }
                else
                    throw new Exception("Variable invalida");
            }
            //Identificar si es un Draw
            else if (ExpresionesRegulares.EsDraw(linea).Success)
            {   
                //Obtener la secuencia que se quiere dibujar en caso de que sea una secuencia
                List<string> dibujos = Draw.SeparaDraw(Lexer.Tokenizador(linea));
                //Recorrer todo lo que se quiere dibujar
                foreach (string d in dibujos)
                {   //Si el nombre de lo que se quiere dibujar es una variable
                    if (ExpresionesRegulares.EsVariable(d))
                    {
                        if (variables.TryGetValue(d, out object valorAlmacenado))
                        {
                            if (valorAlmacenado is IElements objetoConInterfaz)
                            {
                                objetoConInterfaz.Dibuja(lienzo);
                            }
                            else
                                throw new Exception("La variable " + d + " no es dibujable");
                        }
                        else
                            throw new Exception("La Variable " + d + " no esta definida");
                    }
                    //Si no es una variable ver si es el constructor de algun tipo
                    else if (ExpresionesRegulares.EsConstructor(d).Success)
                    {
                        // Crear switch case para los distintos tipos de constructores luego de tener las clases y los parametros que se necesitan
                    }
                    else
                        throw new Exception("Lo que se quiere dibujar no es correcto");
                }
            }
            else
                throw new Exception("Nombre incorrecto");
        }






    }
}
