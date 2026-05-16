using System.IO.Compression;
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

    private List<User> users = new List<User>();
    public List<User> Users
    {
        get { return users; }
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
            if(pair.Value == true && (pair.Key == product.Genre || pair.Key == product.Language || pair.Key == product.Country))
            {
                return true;
            }
        }
        return false;
    }
    
    public void Recommend(Product product)
    {
        bool fancy = RecommendByPreferences(product);
        if (fancy && !products.Contains(product) && !recommended.Contains(product))
        {
            recommended.Add(product);
        }
    }

    public void CompareUsers(User actualUser, Product product)
    {
        foreach(User user in users)
        {   
            if(actualUser.Preference.SequenceEqual(user.Preference) && actualUser != user && !products.Contains(product) && !recommended.Contains(product))
            {
                recommended.Add(product);  
            }
        }    
    }

    public void CompareAttributes(Product basee)
    {
        foreach(Product product in products)
        {
            if((basee.Genre == product.Genre || basee.Language == product.Language || basee.Country == product.Country) && !recommended.Contains(product) && !products.Contains(product))
            {
                recommended.Add(product);
            }
        }   
    }

    public bool HasNoRecord(Product product)
    {
        if(products.Count == 0)
        {
            return true;  
        }
    return false;
    }

    public void RecommendPopular(Product product, Interaction interaction)
    {
        bool popular = IsPopular(product);
        bool noRecord = HasNoRecord(product);
        if (popular && noRecord)
        {
            recommended.Add(product);
        } 
    }
}