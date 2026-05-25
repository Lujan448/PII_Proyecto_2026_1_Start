using System.Collections.Generic;
using System;
//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para crear y gestionar la lista de productos
//Además, utilizamos uno de los principios SOLID, el cual es SRP, con el proposito de que la clase Product no tenga más de una 
//razón de cambio. La distinción entre esta clase y Product es que Product se va a a encargar de los productos
//de manera individual.
namespace Library
{
    public class Catalog
    {
        private List<IProduct> product = new List<IProduct>();
        public List<IProduct> Products
        {
            get { return product; }
        }
        
        //Crea un nuevo producto y lo agrega a la lista de los productos
        public void NewProduct(string name, int year, string country, string genre, string language)
        {
            Product products = new Product(name, year, country, genre, language);
            product.Add(products);
            Console.WriteLine($" El producto '{name}' está registrado en el sistema.");
        }

        //En caso de que se quiera remover el producto de la lista de productos se implementa este método.
        public void RemoveProduct(IProduct products)
        {
            product.Remove(products);
        }
    }   
}

