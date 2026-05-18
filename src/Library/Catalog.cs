namespace Library;

    public class Catalog
    {
        private List<Product> product = new List<Product>();
        public List<Product> Products
        {
            get { return product; }
        }
    
        public void NewProduct(string name, int year, string country, string genre, string language)
        {
            Product products = new Product(name, year, country, genre, language);
            product.Add(products);
            Console.WriteLine($" El producto '{name}' está registrado en el sistema.");
        }

        public void RemoveProduct(Product products)
        {
            product.Remove(products);
        }
    }
