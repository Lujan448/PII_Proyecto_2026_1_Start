namespace Library;

    public class Product : IProduct
    {
        private string name;
        public string Name
        { 
            get {return name; } set {name = value;} 
        }
        private int year;
        public int Year
        { 
            get {return year; } set {year = value;} 
        }
        private string country;
        public string Country 
        { 
            get {return country; } set {country = value;} 
        }
        private string genre;
        public string Genre 
        { 
            get {return genre; } set {genre = value;} 
        }
        private string language;
        public string Language 
        { 
            get {return language; } set {language = value;} 
        }

    
        public Product(string name, int year, string country, string genre, string language)
        {
            this.Name = name;
            this.Year = year;
            this.Country = country;
            this.Genre = genre;
            this.Language = language;
        }
    }
