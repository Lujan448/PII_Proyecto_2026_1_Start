using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.VisualBasic;

namespace Library;

public class SavesLater
{
    private List<IProduct> saves = new List<IProduct>();
    public List<IProduct> Saves
    {
        get { return saves; }
    }

    public void SaveItems(IProduct product)
    {
        if (!saves.Contains(product))
        {
            saves.Add(product);
        }
    } 
}