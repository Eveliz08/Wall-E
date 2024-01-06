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
    public class Parser : Expresiones
    {
        //Diccionario que contiene las variables
        public static Dictionary<string, object> variables = new Dictionary<string, object>();
        public static Dictionary<string, object> constantes = new Dictionary<string, object>();

        static Stack<string> coloresimplementados = new Stack<string>();

        static HashSet<string> coloresDisponibles = new HashSet<string> { "blue", "red", "yellow", "green", "cyan", "white", "gray", "black", "magenta" };

        public static void Reset()
        {
            variables.Clear();
        }

        public static void Identifier(string linea, Canvas lienzo)
        {
            string instruction = linea.Trim();

            if (IsValid(instruction, declaration).Success)
            {
                GroupCollection groups = IsValid(instruction, declaration).Groups;
                string tipo = groups["tipo"].Value.ToString();
                string nombre = groups["nombre"].Value.ToString();

                // Random random = new Random();
                switch (tipo)
                {
                    case "point":
                        Point point = new Point(lienzo);
                        variables.Add(nombre, point);
                        //   Generica<Circle>.SavingShapes.Add(nombre, point);
                        break;
                    case "line":
                        Linea line = new Linea(new Point(lienzo), new Point(lienzo));
                        variables.Add(nombre, line);
                        //    Generica<Line>.SavingShapes.Add(nombre, line);
                        break;
                    case "circle":
                        Circle circle = new Circle(new Point(lienzo), 80);
                        variables.Add(nombre, circle);
                        //    Generica<Circle>.SavingShapes.Add(nombre, circle);
                        break;
                    case "segment":
                        Segment segment = new Segment(new Point(lienzo), new Point(lienzo));
                        variables.Add(nombre, segment);
                        break;
                    case "ray":
                        Ray ray = new Ray(new Point(lienzo), new Point(lienzo));
                        variables.Add(nombre, ray);
                        break;
                }

            }
            else if (IsValid(instruction, definir).Success)
            {
                GroupCollection groups = IsValid(instruction, definir).Groups;
                string nombre = groups["nombre"].Value.ToString();
                string cuerpo = groups["cuerpo"].Value.ToString();
                cuerpo = cuerpo.Trim();

                if (IsValid(cuerpo, inicializartipo).Success)
                {
                    GroupCollection gruposCuerpo = IsValid(cuerpo, inicializartipo).Groups;
                    string tipo = gruposCuerpo["tipo"].Value.ToString();
                    string[] parametros = gruposCuerpo["parametros"].Value.ToString().Split(',');

                    for (int i = 0; i < parametros.Length; i++)
                        parametros[i] = parametros[i].Trim();

                    switch (tipo)
                    {
                        case "point":
                            double x1, y1;
                            if (parametros.Length == 2 && double.TryParse(parametros[0], out x1) && double.TryParse(parametros[1], out y1))
                            {
                                Point point = new Point(x1, y1);

                                if (variables.ContainsKey(nombre))
                                {
                                    if (variables[nombre] is Point)
                                    {
                                        variables[nombre] = point;
                                    }
                                }
                                else
                                {
                                    //hay que capturar una excepcion si ya la constante existe. no se pueden redefinir contantes
                                    constantes.Add(nombre, point);
                                }

                            }
                            break;
                        case "line":
                            if (parametros.Length == 2 && variables.ContainsKey(parametros[0]) && variables.ContainsKey(parametros[1]))
                            {
                                if (variables[parametros[0]] is Point && variables[parametros[1]] is Point)
                                {
                                    Linea line = new Linea((Point)variables[parametros[0]], (Point)variables[parametros[1]]);


                                    if (variables.ContainsKey(nombre))
                                    {
                                        variables[nombre] = line;
                                    }
                                    else
                                    {
                                        //hay que capturar una excepcion si ya la constante existe. no se pueden redefinir contantes
                                        constantes.Add(nombre, line);
                                    }

                                }
                            }
                            break;
                        case "circle":
                            if (parametros.Length == 2)
                            {

                                double r;
                                if (variables[parametros[0]] is Point && double.TryParse(parametros[1], out r))
                                {
                                    Circle circle = new Circle((Point)variables[parametros[0]], r);


                                    if (variables.ContainsKey(nombre))
                                    {
                                        variables[nombre] = circle;
                                    }
                                    else
                                    {
                                        //hay que capturar una excepcion si ya la constante existe. no se pueden redefinir contantes
                                        constantes.Add(nombre, circle);
                                    }

                                }
                                else if (variables[parametros[0]] is Point && variables[parametros[1]] is Measure)
                                {        
                                      Circle circle = new Circle((Point)variables[parametros[0]], (Measure)variables[parametros[1]]);

                                    if (variables.ContainsKey(nombre))
                                    {
                                        variables[nombre] = circle;
                                    }
                                    else
                                    {
                                        //hay que capturar una excepcion si ya la constante existe. no se pueden redefinir contantes
                                        constantes.Add(nombre, circle);
                                    }
                                }
                                else
                                    throw new Exception("Los parametros no son del tipo correcto");
                            }

                            break;
                    }

                }
            }
            else if (IsValid(instruction, color).Success)
            {
                GroupCollection groups = IsValid(instruction, color).Groups;
                string colorImplementado = groups["color"].Value.ToString();

                if (coloresDisponibles.Contains(colorImplementado))
                {
                    coloresimplementados.Push(colorImplementado);
                }
                else
                {
                    //Lanzar una excepcion que diga: El color _ no está disponible
                    throw new Exception("Ese color no esta disponible");
                }
            }
            else if (instruction == "restore")
            {
                coloresimplementados.Pop();
                //System.InvalidOperationException: Stack empty. Si la pila está vacia
            }
            else if (IsValid(instruction, draw).Success)
            {
                GroupCollection groups = IsValid(instruction, draw).Groups;
                string cuerpo = groups["cuerpo"].Value.ToString();
                cuerpo = cuerpo.Trim();

                if (IsValid(cuerpo, inicializartipo).Success)
                {

                }
                else
                {
                    Draw.SimpleDraw(cuerpo, variables, lienzo);
                }


            }
        }
    }
}


//Metodo para parsear
//public static void QueEs(string linea, Canvas lienzo)
//{   
//    //Identificar si es un punto
//    if (Expresiones.EsPunto(linea).Success)
//    {   //Obtener el nombre de dicho punto
//        Match match = Expresiones.EsPunto(linea);
//        if (Expresiones.EsVariable(match.Groups[1].ToString()))
//        {
//            Point p = new Point(lienzo);
//            variables.Add(match.Groups[1].ToString(), p);
//            //p.Dibuja(p, lienzo);
//        }
//        else
//            throw new Exception("Variable invalida");
//    }
//    //Identificar si es un Draw
//    else if (Expresiones.EsDraw(linea).Success)
//    {   
//        //Obtener la secuencia que se quiere dibujar en caso de que sea una secuencia
//        List<string> dibujos = Draw.SeparaDraw(Lexer.Tokenizador(linea));
//        //Recorrer todo lo que se quiere dibujar
//        foreach (string d in dibujos)
//        {   //Si el nombre de lo que se quiere dibujar es una variable
//            if (Expresiones.EsVariable(d))
//            {
//                if (variables.TryGetValue(d, out object valorAlmacenado))
//                {
//                    if (valorAlmacenado is IElements objetoConInterfaz)
//                    {
//                        objetoConInterfaz.Dibuja(lienzo);
//                    }
//                    else
//                        throw new Exception("La variable " + d + " no es dibujable");
//                }
//                else
//                    throw new Exception("La Variable " + d + " no esta definida");
//            }
//            //Si no es una variable ver si es el constructor de algun tipo
//            else if (Expresiones.EsConstructor(d).Success)
//            {
//                // Crear switch case para los distintos tipos de constructores luego de tener las clases y los parametros que se necesitan
//            }
//            else
//                throw new Exception("Lo que se quiere dibujar no es correcto");
//        }
//    }
//    else
//        throw new Exception("Nombre incorrecto");
//}




