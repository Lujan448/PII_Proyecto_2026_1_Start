//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para crear y gestionar el diccionario de las preferencias del usuario.
//Además, utilizamos uno de los principios SOLID, el cual es SRP, con el proposito de que la clase User no tenga más de una 
//razón de cambio. Ya que si se le quiere agregar otro tipo de atributo para alguna preferencia tendriamos que cambiar varias clases,
//si solo esta dicha responsabilidad en esta clase solo se modifica esta clase, quedando cada clase con una responsabilidad concreta.
namespace Library
{
    public class Preferences
    {
        //lo que se hace es un diccionario para ir colocando que le gusta y que no le gusta al usuario
        private Dictionary<string, bool> preference = new Dictionary<string, bool>();
        public Dictionary<string,bool> Preference
        {
            get { return preference; }
        }

        //este método va a ir poniendo como claves aquellos atributos del producto
        //y además va a guardar en cada correspondiente clave un valor que corresponde a si le gusta o no usando bools
        public void Select(string attribute, bool likes)
        {
            preference[attribute] = likes;
        }
    }
    
}
