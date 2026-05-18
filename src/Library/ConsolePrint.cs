namespace Library;
public class ConsolePrint
{
    //Obtiene la lista de los productos ya ordenados
    private List<Interactions> interactList;
    private List<Product> items;
    public ConsolePrint (List<Product> items, List<Interactions> interactions)
    {
        this.items = items;
        this.interactList = interactions;
    }
    // Construye el texto para mostrar los productos
    public string TextToPrint()
    {
        string result = "";

        for (int i = 0; i < items.Count; i++)
        {
            result += $"{items[i].Name} - Puntuación: {interactList[i].AverageRating} - Vistas: {interactList[i].Visualizations} - Idioma: {items[i].Language} - Género: {items[i].Genre}\n";
        }
        return result;
    }

    //Imprime el texto generado en la consola
    public void Print()
    {
     Console.WriteLine(TextToPrint());
    }
}