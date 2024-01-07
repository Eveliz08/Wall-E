using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Walle;
using Point = Walle.Point;

namespace Wall_E
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Point centro = new Point(200, 200);
            Point point2 = new Point(400, 100);
            Point point3 = new Point(100, 300);
            Measure radio = new Measure(100);
            Point inicio = Point.ObtenerPunto(centro, point2, radio);
            Point fin = Point.ObtenerPunto(centro, point3, radio);

            // Circle c = new Circle(centro,radio);

            Arc arco = new Arc(centro, inicio, fin, radio,"arco");
            centro.Dibuja(lienzo);
            point2.Dibuja(lienzo);
            point3.Dibuja(lienzo);
            inicio.Dibuja(lienzo);
            fin.Dibuja(lienzo);
            arco.Dibuja(lienzo);

            // Crear un objeto  Arco y dibujarlo en un Canvas

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(TextBox.ActualHeight.ToString()+" "+ TextBox.ActualWidth.ToString());

            // Parser.Reset();
            // Obtiene la entrada del usuario
            string entrada = TextBox.Text.Replace("\r", "").Replace("\n", "");
            // Limpia el lienzo para dibujar una nueva forma
            lienzo.Children.Clear();

            //Segment s1 = new Segment(new Point(400, 400), new Point(300, 50));
            //Segment s2 = new Segment(new Point(400, 400), new Point(50, 100));
            //Arco arco = new Arco(s1,s2, 50);
            //s1.Dibuja(lienzo);
            //s2.Dibuja(lienzo);
            //arco.Dibuja(lienzo);


            //try
            //{
            //    DibujarFormaEnCanvas(entrada);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}


            //List<List<string>> lineas = Lexer.SeparaPorLinea(Lexer.Tokenizador(entrada));
            //try
            //{
            //    foreach (var line in lineas)
            //    {

            //        ///////////////////////

            //        if (line.Last() != ";") throw new Exception("Falta punto y coma");

            //        line.Remove(line.Last());

            //        Parser.Identifier(String.Join(" ", line).Trim(), lienzo);

            //        //////////////

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            // Dibuja algo en función de la entrada


            // Realiza la interpretación de acuerdo a la entrada
            //string resultado = InterpretarEntrada(entrada);

            // Muestra el resultado en la segunda mitad
            //TextBlock1.Text = resultado;

        }

        //private void DibujarFormaEnCanvas(string entrada)
        //{

        //    if (EsComandoDibujo(entrada))
        //    {
        //        EjecutarComandoDibujo(entrada, lienzo);
        //    }
        //    else
        //    {
        //        MostrarTextoEnCanvas(entrada);
        //    }
        //}
        //private bool EsComandoDibujo(string entrada)
        //{
        //    // Agrega lógica para determinar si la entrada es un comando de dibujo
        //    // Por ejemplo, puedes verificar si la entrada es "punto", "dos puntos", "circunferencia", etc.
        //    return entrada.ToLower() == "punto" || entrada.ToLower() == "linea" || entrada.ToLower() == "ray" || entrada.ToLower() == "segmento" || entrada.ToLower() == "circle";
        //}

        //private void EjecutarComandoDibujo(string comando, Canvas lienzo)
        //{
        //    switch (comando.ToLower())
        //    {
        //        case "circle":

        //            Point point = new Point(lienzo);
        //            point.Dibuja(lienzo);
        //            Circle circle = new Circle(point, 80);
        //            if (Circle.SePuedeDibujar(circle, lienzo))
        //                circle.Dibuja(lienzo);
        //            else
        //                throw new Exception("La circunferencia no cabe");
        //            break;
        //        case "linea":
        //            Point point1 = new Point(lienzo);
        //            //  point1.Dibuja(lienzo);
        //            Point point2 = new Point(lienzo);
        //            // point2.Dibuja(lienzo);
        //            Linea linea = new Linea(point1, point2);
        //            MessageBox.Show(linea.pendiente.ToString());

        //            linea.Dibuja(lienzo);

        //            break;
        //        case "punto":
        //            Point p = new Point(lienzo);
        //            p.Dibuja(lienzo); break;
        //        case "ray":
        //            Point point3 = new Point(lienzo);
        //            //  point1.Dibuja(lienzo);
        //            Point point4 = new Point(lienzo);
        //            // point2.Dibuja(lienzo);
        //            Ray ray = new Ray(point3, point4);
        //            ray.Dibuja(lienzo);
        //            break;
        //        case "segmento":
        //            //  point1.Dibuja(lienzo);
        //            Point point5 = new Point(lienzo);
        //            //  point1.Dibuja(lienzo);
        //            Point point6 = new Point(lienzo);
        //            // point2.Dibuja(lienzo);
        //            Segment segment = new Segment(point5, point6);
        //            segment.Dibuja(lienzo);
        //            break;




        //            /*case "dos puntos":
        //                DibujarDosPuntos();
        //                break;
        //            case "circunferencia":
        //                DibujarCircunferencia();
        //                break;*/
        //    }
        //}

        //private void MostrarTextoEnCanvas(string texto)
        //{
        //    TextBlock resultadoTextBlock = new TextBlock
        //    {
        //        Text = EvaluadorAritmetico.EvaluarPosfija(texto).ToString(),
        //        FontSize = 14,
        //        FontWeight = FontWeights.Bold,
        //        Foreground = Brushes.Black
        //    };
        //    Canvas.SetLeft(resultadoTextBlock, 10);
        //    Canvas.SetTop(resultadoTextBlock, 10);

        //    lienzo.Children.Add(resultadoTextBlock);
        //}


        // Función para interpretar la entrada del usuario
        //private string InterpretarEntrada(string entrada)
        //{
        //    // Aquí puedes colocar la lógica para interpretar la entrada del usuario
        //    // y devolver el resultado correspondiente basado en el mini lenguaje de programación

        //    // Por ejemplo, si el usuario ingresara "IMPRIMIR 'Hola, mundo!'", la función devolvería "Hola, mundo!"

        //    // Esta es solo una función de ejemplo; debes implementar la lógica que corresponda a tu mini lenguaje

        //    return "Resultado de la interpretación";
        //}

        private void Click_Guardar(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string nombreArchivo = saveFileDialog.FileName;
                string contenido = TextBox.Text;

                try
                {
                    File.WriteAllText(nombreArchivo, contenido);
                    MessageBox.Show("Contenido guardado con éxito en " + nombreArchivo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }

        }
        private void Click_Abrir(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string contenido = File.ReadAllText(openFileDialog.FileName);
                TextBox.Text = contenido;
            }
        }

        private void Click_Limpiar(object sender, RoutedEventArgs e)
        {
            TextBox.Clear();
        }
    }
}

