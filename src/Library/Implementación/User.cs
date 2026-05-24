using System.Security.Cryptography;
//En este caso usamos composición, ya que consideramos que las preferencias no van a poder existir de manera independiente sin la clase
//usuario, ya que si eliminamos usuarios las preferencias de este no existirian.
namespace Library;
    public class User
    {
        private string name;
        public string Name
        { 
            get {return name; } set {name = value;} 
        }
        private int age;
        public int Age
        { 
            get {return age; } set {age = value;} 
        }
        private string country;
        public string Country 
        { 
            get {return country; } set {country = value;} 
        }
        private Preferences preferences;
        public Preferences Preferences
        {
            get {return preferences; }
        }
    

     
        public User(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
            this.preferences = new Preferences();
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
