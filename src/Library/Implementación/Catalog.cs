namespace Library;
//Creamos esta clase a partir de que usamos SRP, ya que esta clase va a ser la experta de la información a la hora de crear y gestionar la 
//lista de los productos, mientras que la clase product se va a encargar de los productos de manera individual.
    public class Catalog
    {
        private List<IProduct> product = new List<IProduct>();
        public List<IProduct> Products
        {
            get { return product; }
        }
    
        public void NewProduct(string name, int year, string country, string genre, string language)
        {
            Product products = new Product(name, year, country, genre, language);
            product.Add(products);
            Console.WriteLine($" El producto '{name}' está registrado en el sistema.");
        }

        public void RemoveProduct(IProduct products)
        {
            product.Remove(products);
        }
    }
