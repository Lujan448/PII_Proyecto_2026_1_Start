namespace library;

    public class Product
    {
       
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }

        
        private List<Product> product;

    
        public Product(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
            product = new List<Product>();
        }

       
        public void NewProduct(string name)
        {
           
            Product p = new Product(name, 0, "No definido");
            product.Add(p);
            Console.WriteLine($"Producto '{name}' registrado en el sistema.");
        }
    }
