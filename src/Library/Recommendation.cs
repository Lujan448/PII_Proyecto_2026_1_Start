using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace Library;

public class Recommendation
{
    private List<Product> recommended = new List<Product>();
    public List<Product> Recommended
    {
        get { return recommended; }
    }

    private List<Product> products = new List<Product>();
    public List<Product> Products
    {
        get { return products; }
    }
    private List<Interactions> interaction = new List<Interactions>();
    public List<Interactions> Interaction
    {
        get { return interaction; }
    }
    private Dictionary<string, bool> preference = new Dictionary<string, bool>();
    public Dictionary<string,bool> Preference
    {
        get { return preference; }
    }

    public bool RecommendByPreferences(Product product)
    {
        foreach(KeyValuePair<string, bool> pair in preference)
        {
            if(pair.Value == true && (pair.Key == product.Genre || pair.Key == product.Lenguage || pair.Key == product.Country))
            {
                return true;
            }
        }
        return false;
    }

    public void Recommend(Product product)
    {
        bool fancy = RecommendByPreferences(product);
        if (fancy && !products.Contains(product))
        {
            recommended.Add(product);
        }  
    }
}