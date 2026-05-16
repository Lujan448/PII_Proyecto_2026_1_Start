namespace Library;

    public class Product
    {
       
        public string Name { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }

        
        private List<Product> product;

    
        public Product(string name, int year, string country, string genre, string language)
        {
            Name = name;
            Year = year;
            Country = country;
            Genre = genre;
            Language = language;
            product = new List<Product>();
        }

       
        public void NewProduct()
        {
            Product p = new Product("PeakyBlinders", 2016, "Inglaterra", "Acción", "inglés");
            product.Add(p);
            Console.WriteLine($" El producto '{this.Name}' está registrado en el sistema.");
        }

        public void RemoveProduct(Product p)
        {
            product.Remove(p);
        }
    }
