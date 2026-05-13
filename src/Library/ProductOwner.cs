namespace Library;

public class ProductOwner
{
    private string name;
    public string Name
    {
        get { return name; } set { name = value;}
    }

    public ProductOwner(string name)
    {
        this.Name = name;
    }

    public bool IsOwner(string name)
    {
        if(this.name == name)
        {
            return true;   
        }
        return false;
    }
}