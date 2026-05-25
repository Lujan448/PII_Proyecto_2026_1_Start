//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para crear y gestionar los productos de manera individual.
//Además, utilizamos uno de los principios SOLID, el cual es SRP, con el proposito de que la clase Product no tenga más de una 
//razón de cambio. La distinción entre esta clase y Catalog es que Catalog se va a encargar de la cración y la
//gestión de un conjunto de productos.
//Utiliza la interafaz de IProduct con el proposito de que en el caso de que se vaya a crear una clase o varias con productos distintos,
//como todas van a tener más o menos las mismas abstracciones, se va a crear un contrato.
namespace Library
{
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
}

