namespace Library;
    public class User
    {
    
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        private Dictionary<string, bool> preference = new Dictionary<string, bool>();
        public Dictionary<string, bool> Preference
        {
            get { return preference; }
        }
    

     
        public User(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

      
        public void CreateCount(List<User> users)
        {
            if (!UserIsValid())
            {
                Console.WriteLine($"Error: Los datos de '{this.Name}' no son válidos.");
                return;
            }

            if (UserExist(users))
            {
                Console.WriteLine($"Error: El usuario '{this.Name}' ya existe.");
                return;
            }

            users.Add(this);
            Console.WriteLine($"Cuenta creada con éxito para {this.Name}.");
        }

      
        public bool UserExist(List<User> users)
        {
            return users.Contains(this);
        }


        public bool UserIsValid()
        {
            return !string.IsNullOrEmpty(this.Name) && 
                   !string.IsNullOrEmpty(this.Country) && 
                   this.Age >= 1;
        }
    }
