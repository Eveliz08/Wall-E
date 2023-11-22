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
using Wall.Wall_EEngine;
using Point = Wall.Wall_EEngine.Point;
//using Point = Wall_E.Wall_EEngine.Point;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Obtiene la entrada del usuario
            string entrada = TextBox.Text.Replace("\r", "");
            // Limpia el lienzo para dibujar una nueva forma
            lienzo.Children.Clear();

            List<List<string>> lineas = Lexer.SeparaPorLinea(Lexer.Tokenizador(entrada));
            foreach (var line in lineas)
            {
                Parser.QueEs(String.Join(" ", line), lienzo);
            }

            // Dibuja algo en función de la entrada
           // DibujarFormaEnCanvas(entrada);

            // Realiza la interpretación de acuerdo a la entrada
            //string resultado = InterpretarEntrada(entrada);

            // Muestra el resultado en la segunda mitad
            //TextBlock1.Text = resultado;

        }

        private void DibujarFormaEnCanvas(string entrada)
        {

            if (EsComandoDibujo(entrada))
            {
                EjecutarComandoDibujo(entrada, lienzo);
            }
            else
            {
                MostrarTextoEnCanvas(entrada);
            }
        }
        private bool EsComandoDibujo(string entrada)
        {
            // Agrega lógica para determinar si la entrada es un comando de dibujo
            // Por ejemplo, puedes verificar si la entrada es "punto", "dos puntos", "circunferencia", etc.
            return entrada.ToLower() == "punto" || entrada.ToLower() == "dos puntos" || entrada.ToLower() == "circunferencia";
        }

        private void EjecutarComandoDibujo(string comando, Canvas lienzo)
        {
            switch (comando.ToLower())
            {
                case "punto":
                    Point point = new Point(lienzo);
                    point.Dibuja(point, lienzo);
                    break;
                    /*case "dos puntos":
                        DibujarDosPuntos();
                        break;
                    case "circunferencia":
                        DibujarCircunferencia();
                        break;*/
            }
        }

        private void MostrarTextoEnCanvas(string texto)
        {
            TextBlock resultadoTextBlock = new TextBlock
            {
                Text = EvaluadorAritmetico.EvaluarPosfija(texto).ToString(),
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Black
            };
            Canvas.SetLeft(resultadoTextBlock, 10);
            Canvas.SetTop(resultadoTextBlock, 10);

            lienzo.Children.Add(resultadoTextBlock);
        }


        // Función para interpretar la entrada del usuario
        private string InterpretarEntrada(string entrada)
        {
            // Aquí puedes colocar la lógica para interpretar la entrada del usuario
            // y devolver el resultado correspondiente basado en el mini lenguaje de programación

            // Por ejemplo, si el usuario ingresara "IMPRIMIR 'Hola, mundo!'", la función devolvería "Hola, mundo!"

            // Esta es solo una función de ejemplo; debes implementar la lógica que corresponda a tu mini lenguaje

            return "Resultado de la interpretación";
        }

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
