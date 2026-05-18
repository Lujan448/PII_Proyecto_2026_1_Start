using System.IO.Compression;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace Library;

public class Recommendation
{
    //lista para agregar los productos recomendados
    private List<Product> recommended = new List<Product>();
    public List<Product> Recommended
    {
        get { return recommended; }
    }

    //lista para los productos que estan en el historial
    private List<Product> products = new List<Product>();
    public List<Product> Products
    {
        get { return products; }
    }

    //lista oara las interacciones
    private List<Interactions> interaction = new List<Interactions>();
    public List<Interactions> Interaction
    {
        get { return interaction; }
    }

    //lista para los usuarios
    private List<User> users = new List<User>();
    public List<User> Users
    {
        get { return users; }
    }

    //diccionario para las preferencias
    private Dictionary<string, bool> preference = new Dictionary<string, bool>();
    public Dictionary<string,bool> Preference
    {
        get { return preference; }
    }

    //constuctor
    public Recommendation(List<Product> records, List<Interactions> interactions, Dictionary<string , bool> preferences, List<User> user)
    {
        this.products = records;
        this.interaction = interactions;
        this.preference = preferences;
        this.users = user;
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

    public bool HasNoRecord()
    {
        if(products.Count == 0)
        {
            return true;  
        }
    return false;
    }

    public void RecommendPopular(Product product, Interactions interaction)
    {
        bool popular = interaction.IsPopular();
        bool noRecord = HasNoRecord();
        if (popular && noRecord)
        {
            recommended.Add(product);
        } 
    }
}