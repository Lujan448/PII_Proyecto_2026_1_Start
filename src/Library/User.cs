namespace Library;

    public class User
    {
    
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        private List<string> usuarios;
        private Dictionary<string, bool> preference = new Dictionary<string, bool>();
        public Dictionary<string, bool> Preference
        {
            get { return preference; }
        }
    

     
        public User(string name)
        {
            Name = name;
            usuarios = new List<string>();
        }

      
        public void CreateCount()
        {
            if (!UserIsValid())
            {
                Console.WriteLine($"Error: Los datos de '{Name}' no son válidos.");
                return;
            }

            if (UserExist())
            {
                Console.WriteLine($"Error: El usuario '{Name}' ya existe.");
                return;
            }

            usuarios.Add(Name);
            Console.WriteLine($"Cuenta creada con éxito para {Name}.");
        }

      
        public bool UserExist()
        {
            return usuarios.Contains(Name);
        }


        public bool UserIsValid()
        {
            return !string.IsNullOrEmpty(Name) && 
                   !string.IsNullOrEmpty(Country) && 
                   Age >= 1;
        }
    }
