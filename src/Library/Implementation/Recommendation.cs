using System.Collections.Generic;
using System;
//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para crear y gestionar las recomendaciones.
//Si bien esta clase utiliza las preferencias, el catálogo y el encargado de las interacciones, no viola SRP
//ya que todas estas dependencias se utilizan solamente con el propósito de realizar la responsabilidad de la clase Recommendation,
//la cual es crear una lista con recomendaciones a partir de diferentes condiciones.
//Es por esto, que la clase Recommendation solo tiene una razón de cambio.
//Para gestionar las dependencias de esta clase, decidimos pasar History e InteractionManager por constructor
//en lugar de crearlos internamente. Tomamos esta decisión porque necesitamos que el mismo objeto History
//sea compartido entre la fachada y Recommendation, de forma que cuando se registra una interacción en la fachada,
//Recommendation pueda verla y excluir ese producto de las recomendaciones.
//Si bien este concepto se conoce como inyección de dependencias y no fue visto en clase,
//nos pareció la solución más correcta para evitar tener dos historiales desconectados.
namespace Library
{
    public class Recommendation
    {
        //lista para agregar los productos recomendados
        private List<IProduct> recommended = new List<IProduct>();
        public List<IProduct> Recommended
        {
            get { return recommended; }
        }

        private History history;
        public History History { get{ return history; } }

        private Preferences preferences;
        public Preferences Preferences { get{ return preferences; } }

        private Catalog catalog;
        public Catalog Catalog { get { return catalog; } }

        private InteractionManager interactionManager;
        public InteractionManager InteractionManager { get { return interactionManager; } }

        //constuctor
        public Recommendation(User user, Catalog catalog, History history, InteractionManager interactionManager)
        {
            this.preferences = user.Preferences;
            this.history = history;
            this.interactionManager = interactionManager;
            this.catalog = catalog;
        }
        

        public bool RecommendByPreferences(IProduct product)
        {
            foreach(KeyValuePair<string, bool> pair in preferences.Preference)
            {
                if(pair.Value == true && (pair.Key == product.Genre || pair.Key == product.Language || pair.Key == product.Country))
                {
                    return true;
                }
            }
            return false;
        }
        
        public void Recommend(IProduct product)
        {
            bool fancy = RecommendByPreferences(product);
            if (fancy && !history.Histories.Contains(product) && !recommended.Contains(product))
            {
                recommended.Add(product);
            }
        }

        public void CompareUsers(User actualUser, IProduct product, List<User> users)
        {
            foreach (User user in users)
            {
                if (actualUser == user) continue;

                int matches = 0;
                foreach (KeyValuePair<string, bool> pair in actualUser.Preferences.Preference)
                {
                    if (user.Preferences.Preference.ContainsKey(pair.Key) &&
                        user.Preferences.Preference[pair.Key] == pair.Value)
                    {
                        matches++;
                    }
                }

                bool similar = matches >= 2;

                //en esta parte se verifica que no se tenga atributos rechazados
                bool rejected = false;
                foreach (KeyValuePair<string, bool> pair in actualUser.Preferences.Preference)
                {
                    if (pair.Value == false && (pair.Key == product.Genre || pair.Key == product.Language || pair.Key == product.Country))
                    {
                        rejected = true;
                        break;
                    }
                }

                if (similar && !rejected && !history.Histories.Contains(product) && !recommended.Contains(product))
                {
                    recommended.Add(product);
                }
            }
        }

        public void CompareAttributes(IProduct basee)
        {
            foreach(IProduct product in catalog.Products)
            {
                if((basee.Genre == product.Genre || basee.Language == product.Language || basee.Country == product.Country) && !recommended.Contains(product) && !history.Histories.Contains(product))
                {
                    recommended.Add(product);
                }
            }   
        }

        public bool HasNoHistory()
        {
            if(history.Histories.Count == 0)
            {
                return true;  
            }
        return false;
        }

        public void RecommendPopular(IProduct product)
        {
            int index = catalog.Products.IndexOf(product);
            if (index < 0 || index >= interactionManager.Interact.Count) return;
        
            bool popular = interactionManager.Interact[index].IsPopular();
            bool noHistory = HasNoHistory();
        
            if (popular && noHistory)
            {
                recommended.Add(product);
            }
        }

        public void ClearRecommended()
        {
            recommended.Clear();
        }
    }
}
