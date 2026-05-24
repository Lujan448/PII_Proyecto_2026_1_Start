//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para crear y gestionar aquel contenido que el usuario desea guardar para consumir más tarde.
//Si bien esta clase gestiona productos, no viola SRP ya que toda su responsabilidad
//gira en torno a los guardados, por lo tanto, solo tiene una razón de cambio.
namespace Library
{
    public class SavesLater
    {
        private List<IProduct> saves = new List<IProduct>();
        public List<IProduct> Saves
        {
            get { return saves; }
        }

        //este método permite guardar en la lista de los guardados los productos que se quieren consumir después.
        public void SaveItems(IProduct product)
        {
            if (!saves.Contains(product))
            {
                saves.Add(product);
            }
        } 
    }
    
}

