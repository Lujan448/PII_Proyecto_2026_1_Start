using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.VisualBasic;

namespace Library;

public class History
{
    private List<IProduct> histories = new List<IProduct>();
    public List<IProduct> Histories
    {
        get { return histories; }
    }
    private List<Interactions> interactions = new List<Interactions>();
    public List<Interactions>  Interactions
    {
        get { return interactions; }
    }

    public void AddProductToRecord(IProduct product)
    {
        histories.Add(product);
    }

    public void AddInteractionToRecord(Interactions interaction)
    {
        interactions.Add(interaction);
    }

    public bool Consumed(IProduct product)
    {
        if (histories.Contains(product))
        {
            return true;
        }
        return false;
    }

    public void RemoveFromRecord(IProduct product)
    {
        histories.Remove(product);
    }
}