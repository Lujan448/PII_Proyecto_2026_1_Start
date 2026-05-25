using System.Collections.Generic;
using System;
//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para crear y gestionar el historial del usuario, incluyendo los productos consumidos y sus interacciones asociadas.
//Si bien esta clase gestiona tanto productos como interacciones, no viola SRP ya que ambas cosas forman parte
//del historial, por lo tanto, solo tiene una razón de cambio.
namespace Library
{
    public class History
    {
        //Esta lista utiliza el tipo IProduct y no el tipo de la clase Product porque nosotros necesitamos
        //el contrato de los productos, en caso de que posteriormente se agregue otro tipo de producto al programa.
        private List<IProduct> histories = new List<IProduct>();
        public List<IProduct> Histories
        {
            get { return histories; }
        }
        private List<Interactions> interactions = new List<Interactions>();
        public List<Interactions>  Interactions
        {
            get { return interactions; }
        }

        //Este método se va a encargar de agregrar un producto a la historia.
        public void AddProductToHistory(IProduct product)
        {
            histories.Add(product);
        }

        //Este método se va a encargar de agregrar las interacciones de un producto a la historia.
        public void AddInteractionToHistory(Interactions interaction)
        {
            interactions.Add(interaction);
        }

        //Este método se va a encargar de verificar si un producto fue consumido.
        public bool Consumed(IProduct product)
        {
            if (histories.Contains(product))
            {
                return true;
            }
            return false;
        }

        //Este método se va a encargar de remover un producto de la historia.
        public void RemoveFromHistory(IProduct product)
        {
            histories.Remove(product);
        }
    }
    
}

