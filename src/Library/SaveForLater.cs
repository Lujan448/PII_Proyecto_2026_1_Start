using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.VisualBasic;

namespace Library;

public class SavesLater
{
    private List<Product> saves = new List<Product>();
    public List<Product> Saves
    {
        get { return saves; }
    }

    public void SaveItems(Product product)
    {
        if (!saves.Contains(product))
        {
            saves.Add(product);
        }
    } 
}