namespace Library;
public class ConsolePrint
{
    //Obtiene la lista de los productos ya ordenados
    private Order order;
    public Order Order { get; }
    public ConsolePrint (Order order)
    {
        this.order = order;
    }
    // Construye el texto para mostrar los productos
    public string TextToPrint()
    {
        List<IProduct> rank = order.GetRanking();
        string result = "";

        for (int i = 0; i < rank.Count; i++)
        {
            result += $"{rank[i].Name} - Puntuación: {order.InteractList[i].AverageRating} - Vistas: {order.InteractList[i].Visualizations} - Idioma: {rank[i].Language} - Género: {rank[i].Genre}\n";
        }
        return result;
    }

    //Imprime el texto generado en la consola
    public void Print()
    {
     Console.WriteLine(TextToPrint());
    }
}