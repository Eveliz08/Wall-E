using System.IO;

namespace Walle;
public class Import: IExpressionType
{
    public ExpressionType expressiontype { get; }
    private readonly string archivo;
    public Import(ExpressionType expressionType, string archivo)
    {
        this.expressiontype = expressionType;
        //El nombre del archivo a importar introducido por el usuario viene entre comillas.
        archivo = archivo.Remove(0, 1);
        archivo = archivo.Remove(archivo.Length - 1);
        this.archivo = archivo;

    }
    public object Evaluate()
    {
        if (archivo.LastIndexOf(".geo") != archivo.Length - 4)
        {
            //Lanzar excepcion
        }
        //Capturar la excepción que el archivo no aparezca
        string code = File.ReadAllText(@".\Projects\" + archivo + ".geo.txt");

        return code;
    }


}
