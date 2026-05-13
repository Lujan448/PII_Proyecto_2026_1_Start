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

       
        public void NewProduct(string name)
        {
           
            Product p = new Product(name, 0, "No definido");
            product.Add(p);
            Console.WriteLine($"Producto '{name}' registrado en el sistema.");
        }
    }
