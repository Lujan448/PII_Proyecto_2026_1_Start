namespace Library;
public class ConsolePrint
{
    //Obtiene la lista de los productos ya ordenados
    private IEnumerable<Product> items;
    public ConsolePrint (IEnumerable<Product> items)
    {
        this.items = items;
    }
    // Construye el texto para mostrar los productos
    public string TextToPrint()
    {
        string result = "";

        foreach (Product p in items)
        {
            result += $"{p.Name} - Puntuación: {p.Score} - Vistas: {p.Views} - Idioma: {p.Language} - Género: {p.Genre}\n";
        }

        return result;

        }

    //Imprime el texto generado en la consola
    public void Print()
    {
     Console.WriteLine(TextToPrint());
    }
}