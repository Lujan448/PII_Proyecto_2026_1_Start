//Creamos esta clase llamada Fachada, cuyo propósito es simplificar
//el acceso a los diferentes clases del programa. En lugar de que el cliente interactúe
//directamente con cada clase (Catalog, Recommendation, History, etc.), la fachada va a juntar
//todas las operaciones en un único lugar, haciendo que el sistema sea más fácil de usar.

namespace Library
{
    public class Fachadas 
    {
        private List<User> users = new List<User>();
        public List<User> Users { get { return users; } }
        private Recommendation recommendation;
        public Recommendation Recommendation { get { return recommendation; } }
        private Preferences preferences;
        public Preferences Preferences { get { return preferences; } }
        private Catalog catalog;
        private SavesLater savesLater;
        private History history;
        private InteractionManager interactionManager; 
        private string criteria;

        public Fachadas(User user, Catalog catalog, InteractionManager interactionManager, string criteria)
        {
            this.interactionManager = interactionManager;
            this.criteria = criteria;  
            users.Add(user);
            this.catalog = catalog;
            this.history = new History(); 
            this.recommendation = new Recommendation(user, catalog, this.history, interactionManager);
            this.preferences = new Preferences();
            this.savesLater = new SavesLater();
        }

        //HU1   
        public void RegisterUser(User user)
        {
            user.CreateCount(users);
        }

        //HU2 y HU8
        public void DefinePreferences(string attribute, bool likes, User user)
        {
            user.Preferences.Select(attribute, likes);
        }

        //HU3
        public void GetRecommendationList()
        {
            RecommendationsByPreference();
            if (recommendation.Recommended.Count == 0)
            {
                Console.WriteLine("No hay recomendaciones disponibles.");
                return;
            }
            
            List<Interactions> recommendedInteractions = new List<Interactions>();
            foreach (IProduct product in recommendation.Recommended)
            {
                int index = catalog.Products.IndexOf(product);
                if (index >= 0 && index < interactionManager.Interact.Count)
                {
                    recommendedInteractions.Add(interactionManager.Interact[index]);
                }
            }
            
            Order order = new Order(recommendation.Recommended, recommendedInteractions, criteria);
            ConsolePrint print = new ConsolePrint(order);
            print.Print();
        }

        //HU4
        public void RecommendationsByHistory()
        {
            foreach(IProduct product in catalog.Products)
            {
                recommendation.Recommend(product); 
            }
        }

        //HU5
        public void RecommendationsByPreference()
        {
            foreach (IProduct product in catalog.Products)
            {
                recommendation.Recommend(product);   
            }
        }

        //HU6
        public void RecommendationToSimilarPeople(User actualUser)
        {
            foreach(IProduct product in catalog.Products)
            {
                recommendation.CompareUsers(actualUser, product, users);
            }
        }

        //HU7
        public void RecommendationByPopular()
        {
            foreach (IProduct product in catalog.Products)
            {
                recommendation.RecommendPopular(product);   
            }
        }

        //HU9
        public void OrderRecommendations()
        {
            Order order = new Order(recommendation.Recommended, interactionManager.Interact, criteria);
            order.GetRanking();  
        }

        //HU10
        public void RegisterInteractions(IProduct product, Interactions interactions)
        {
            history.AddProductToHistory(product);           //registra el producto consumido
            history.AddInteractionToHistory(interactions); //registra la interacción
        }

        //HU11
        public void Like(IProduct product, User user, Interactions interactions, bool likes)
        {
            if (likes)
            {
                interactions.SumLike();
                Console.WriteLine($"A {user.Name} le gustó: {product.Name}");
            }
            else
            {
                interactions.SumDislike();
                Console.WriteLine($"A {user.Name} no le gustó: {product.Name}");
            }
        }

        //HU12
        public List<IProduct> LookHistory ()
        {
            return history.Histories;
        }

        //HU13 (este método como tal no llama al método que excluye a los consumidos, ya que esto lo hacemos de manera interna en recommendations para cada caso
        // sin embargo, nos parecía bueno de alguna forma ver aquellos que ya fueron consumidos)
        public void ExcludeHistory()
        {
            foreach(IProduct product in catalog.Products)
            {
                history.Consumed(product);
            }
        }

        //HU14
        public void SaveItemForLater(IProduct product)
        {
            savesLater.SaveItems(product);
        }

        public List<IProduct> GetSavedItems()
        {
            return savesLater.Saves;
        }

        //HU15
        public void RelatedContent(IProduct basee)
        {
            recommendation.CompareAttributes(basee);
        }

        //HU16
        public void RemoveItemsFromCatalog(IProduct product)
        {
            catalog.RemoveProduct(product);  
        } 
    }
    
}

