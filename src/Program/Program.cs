using Library;

class Program
{
    static void Main(string[] args)
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        
        User user = new User("María", 19, "Uruguay");
        InteractionManager interactionManager = new InteractionManager();
        Interactions interactions = new Interactions();
        interactionManager.AddInteraction(interactions); 
        
        Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
        
        fachada.RegisterUser(user);
        fachada.DefinePreferences("Acción", true, user);
        fachada.GetRecommendationList();
        fachada.RecommendationsByHistory();
        fachada.RecommendationsByPreference();
        fachada.RecommendationToSimilarPeople(user);
        fachada.RecommendationByPopular();
        fachada.OrderRecommendations();
    }
}
