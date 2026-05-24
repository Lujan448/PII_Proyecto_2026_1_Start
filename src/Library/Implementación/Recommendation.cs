using System.IO.Compression;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;

namespace Library;

public class Recommendation
{
    //lista para agregar los productos recomendados
    private List<IProduct> recommended = new List<IProduct>();
    public List<IProduct> Recommended
    {
        get { return recommended; }
    }

    //usamos composicion
    private History history;
    public History History { get; }

    private Preferences preferences;
    public Preferences Preferences { get; }

    private Catalog catalog;
    public Catalog Catalog { get; }

    private InteractionManager interactionManager;
    public InteractionManager InteractionManager { get; }

    //constuctor
    public Recommendation(User user, Catalog catalog, History history, InteractionManager interactionManager)
    {
        this.preferences = user.Preferences;
        this.history = history;
        this.interactionManager = interactionManager;
        this.catalog = catalog;
    }
    

    public bool RecommendByPreferences(IProduct product)
    {
        foreach(KeyValuePair<string, bool> pair in preferences.Preference)
        {
            if(pair.Value == true && (pair.Key == product.Genre || pair.Key == product.Language || pair.Key == product.Country))
            {
                return true;
            }
        }
        return false;
    }
    
    public void Recommend(IProduct product)
    {
        bool fancy = RecommendByPreferences(product);
        if (fancy && !history.Histories.Contains(product) && !recommended.Contains(product))
        {
            recommended.Add(product);
        }
    }

    public void CompareUsers(User actualUser, IProduct product, List<User> users)
    {
        foreach (User user in users)
        {
            if (actualUser == user) continue;

            int matches = 0;
            foreach (KeyValuePair<string, bool> pair in actualUser.Preferences.Preference)
            {
                if (user.Preferences.Preference.ContainsKey(pair.Key) &&
                    user.Preferences.Preference[pair.Key] == pair.Value)
                {
                    matches++;
                }
            }

            bool similar = matches >= 2; //al menos 2 preferencias en común

            if (similar && !history.Histories.Contains(product) && !recommended.Contains(product))
            {
                recommended.Add(product);
            }
        }
    }

    public void CompareAttributes(IProduct basee)
    {
        foreach(IProduct product in catalog.Products)
        {
            if((basee.Genre == product.Genre || basee.Language == product.Language || basee.Country == product.Country) && !recommended.Contains(product) && !history.Histories.Contains(product))
            {
                recommended.Add(product);
            }
        }   
    }

    public bool HasNoRecord()
    {
        if(history.Histories.Count == 0)
        {
            return true;  
        }
    return false;
    }

    public void RecommendPopular(IProduct product)
    {
        int index = catalog.Products.IndexOf(product);
        if (index < 0 || index >= interactionManager.Interact.Count) return;
    
        bool popular = interactionManager.Interact[index].IsPopular();
        bool noRecord = HasNoRecord();
    
        if (popular && noRecord)
        {
            recommended.Add(product);
        }
    }
}