using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.VisualBasic;

namespace Library;

public class Record
{
    //lo que se hace es un diccionario para ir colocando que le gusta y que no le gusta al usuario
    private List<Product> records = new List<Product>();
    public List<Product> Records
    {
        get { return records; }
    }
    private List<Interactions> interactions = new List<Interactions>();
    public List<Interactions>  Interactions
    {
        get { return interactions; }
    }

    public void AddProductToRecord(Product product)
    {
        records.Add(product);
    }

    public void AddInteractionToRecord(Interactions interaction)
    {
        interactions.Add(interaction);
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