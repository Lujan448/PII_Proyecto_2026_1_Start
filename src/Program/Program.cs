using Library;
using System.Collections.Generic;
using System;
class Program
{
    static void Main(string[] args)
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        catalog.NewProduct("Breaking Bad", 2008, "USA", "Acción", "Inglés");
        catalog.NewProduct("La Casa de los espíritus", 2026, "Chile", "Drama", "Español");

        User user = new User("María", 19, "Uruguay");
        User user1 = new User("Juan", 25, "Argentina");

        Interactions interactions1 = new Interactions();
        interactions1.SumRating(5);
        interactions1.SumVisualization();
        interactions1.SumVisualization();
        Interactions interactions2 = new Interactions();
        interactions2.SumRating(3);
        interactions2.SumVisualization();
        Interactions interactions3 = new Interactions();
        interactions3.SumRating(4);

        InteractionManager interactionManager = new InteractionManager();
        interactionManager.AddInteraction(interactions1);
        interactionManager.AddInteraction(interactions2);
        interactionManager.AddInteraction(interactions3);

        Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
        Console.WriteLine($"Cuenta creada con exito para {user.Name}");
        fachada.RegisterUser(user1);

        fachada.DefinePreferences("Acción", true, user);
        fachada.DefinePreferences("Drama", false, user);
        fachada.DefinePreferences("Acción", true, user1); 
        fachada.DefinePreferences("Drama", false, user1);

        Console.WriteLine("Recomendaciones por historial:");
        fachada.RecommendationsByHistory();
        foreach(IProduct p in fachada.Recommendation.Recommended)
            Console.WriteLine(p.Name);
        fachada.Recommendation.ClearRecommended();

        Console.WriteLine("Recomendaciones por preferencia:");
        fachada.RecommendationsByPreference();
        foreach(IProduct p in fachada.Recommendation.Recommended)
            Console.WriteLine(p.Name);
        fachada.Recommendation.ClearRecommended();

        Console.WriteLine("Recomendaciones por usuarios similares:");
        fachada.RecommendationToSimilarPeople(user1);
        foreach(IProduct p in fachada.Recommendation.Recommended)
            Console.WriteLine(p.Name);
        fachada.Recommendation.ClearRecommended();

        Console.WriteLine("Recomendaciones populares:");
        fachada.RecommendationByPopular();
        foreach(IProduct p in fachada.Recommendation.Recommended)
            Console.WriteLine(p.Name);
        fachada.Recommendation.ClearRecommended();


        Console.WriteLine("Lista de recomendaciones ordenada:");
        fachada.GetRecommendationList();
        fachada.Recommendation.ClearRecommended();


        fachada.RegisterInteractions(catalog.Products[0], interactions1);

        Console.WriteLine("Likes:");
        fachada.Like(catalog.Products[0], user, interactions1, true);
        fachada.Like(catalog.Products[1], user, interactions2, false);

        Console.WriteLine("Historial:");
        foreach(IProduct product in fachada.LookHistory())
            Console.WriteLine(product.Name);

        Console.WriteLine("Guardar para más tarde:");
        fachada.SaveItemForLater(catalog.Products[1]);
        Console.WriteLine($"Guardado: {fachada.GetSavedItems()[0].Name}");

        Console.WriteLine($"Contenido relacionado a {catalog.Products[0].Name}:");
        fachada.RelatedContent(catalog.Products[0]);
        foreach(IProduct p in fachada.Recommendation.Recommended)
            Console.WriteLine(p.Name);

        Console.WriteLine($"Productos antes de eliminar: {catalog.Products.Count}");
        fachada.RemoveItemsFromCatalog(catalog.Products[2]);
        Console.WriteLine($"Productos después de eliminar: {catalog.Products.Count}");
    }
}
