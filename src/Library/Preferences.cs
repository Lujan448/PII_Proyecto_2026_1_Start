namespace Library;

public class Preferences
{
    //lo que se hace es un diccionario para ir colocando que le gusta y que no le gusta al usuario
    private Dictionary<string, bool> preference = new Dictionary<string, bool>();
    public Dictionary<string,bool> Preference
    {
        get { return preference; }
    }

    public void Select(string attribute, bool likes)
    {
        preference[attribute] = likes;
    }
}