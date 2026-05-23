using System.Diagnostics.Metrics;
using System.Reflection;
using Library;


namespace Program;

class Program
{
    static void Main(string[] args)
    {
        Catalog catalog = new Catalog();
        InteractionManager interManager = new InteractionManager();

        catalog.NewProduct("Euphoria", 2019, "USA", "Drama", "Inglés");
        catalog.NewProduct("A Good Girl's Guide to Murder", 2024, "Reino Unido", "Misterio", "Inglés");
        catalog.NewProduct ("Stranger Things", 2016, "USA", "Ciencia Ficción", "Inglés");

        Interactions inter1 = new Interactions();

        for (int i = 0; i < 10000; i++)
        {
            inter1.SumVisualization();
        }

        inter1.SumRating(3);

        for (int i = 0; i < 500; i++)
        {
            inter1.SumLike();
        }

        Interactions inter2 = new Interactions();

        for (int i = 0; i < 5000; i++)
        {
            inter2.SumVisualization();
        }

        inter2.SumRating(4);

        for (int i = 0; i < 1000; i++)
        {
            inter2.SumLike();
        }

        Interactions inter3 = new Interactions();

        for (int i = 0; i < 50000; i++)
        {
            inter3.SumVisualization();
        }

        inter3.SumRating(4);

        for (int i = 0; i < 1000; i++)
        {
            inter3.SumLike();
        }

        interManager.AddInteraction(inter1);
        interManager.AddInteraction(inter2);
        interManager.AddInteraction(inter3);

        List<Product> products = catalog.Products;
        List<Interactions> interactions = interManager.Interact;

        Order order = new Order (products, interactions, "likes");
        List<Product> ranking = order.GetRanking();
        ConsolePrint printer = new ConsolePrint(ranking, interactions);
        printer.Print();
    }
}
