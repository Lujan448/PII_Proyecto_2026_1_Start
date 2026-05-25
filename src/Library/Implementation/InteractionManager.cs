using System.Collections.Generic;
using System;
//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para crear y gestionar la lista de las interacciones de los productos.
//Además, utilizamos uno de los principios SOLID, el cual es SRP, con el proposito de que la clase Interactions no tenga más de una 
//razón de cambio. La distinción entre esta clase e Interactions es que Interactions se va a encargar de las interacciones de los productos
//de manera individual.
namespace Library
{
    public class InteractionManager
    {
        private List<Interactions> interact = new List<Interactions>();
        public List<Interactions> Interact
        {
            get { return interact; }
        }
        
        //Va a ser el método que se va a encargar de agregar una interaccion a la lista de interacciones.
        public void AddInteraction(Interactions interactions)
        {
            interact.Add(interactions); 
        }

        //Va a ser el método que se va a encargar de remover una interaccion de la lista de interacciones.
        public void RemoveInteraction(Interactions interactions)
        {
            interact.Remove(interactions);
        }
    }
}