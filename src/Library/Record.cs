using System.Net.Http.Headers;
using System.Reflection;

namespace Library;

public class Record
{
    //lo que se hace es un diccionario para ir colocando que le gusta y que no le gusta al usuario
    private List<Product> records = new List<Product>();
    public List<Product> Records
    {
        get { return records; }
    }

    public void AddToRecord(Product product)
    {
        records.Add(product);
    }

    public bool Consumed(Product product)
    {
        if (records.Contains(product))
        {
            return true;
        }
        return false;
    }

    public void RemoveFromRecord(Product product)
    {
        records.Remove(product);
    }
}