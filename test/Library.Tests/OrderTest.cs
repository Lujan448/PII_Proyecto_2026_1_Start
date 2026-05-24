using Library;
namespace LibraryTests;

[TestFixture]
public class OrderTest
{
    [Test]
    public void OrderByScore_IfScoreIsCriteria_FirstIsHighestRated()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Product("Luna nueva", 2009, "USA", "Drama", "Ingles"),
            new Product("IT", 2018, "USA", "Terror", "Ingles"),
            new Product("Balada de pájaros cantores", 2023, "USA", "Romance", "Inglés")
        };
        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions(),
            new Interactions()
        };
        interactions[0].SumRating(2);
        interactions[1].SumRating(5);
        interactions[2].SumRating(1);

        Order order = new Order(products, interactions, "score");
        List<IProduct> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("B"));
    }

    [Test]
    public void OrderByViews_IfViewsIsCriteria_FirstIsMostViewed()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Product("Luna nueva", 2009, "USA", "Drama", "Ingles"),
            new Product("IT", 2018, "USA", "Terror", "Ingles"),
            new Product("Balada de pájaros cantores", 2023, "USA", "Romance", "Inglés")
        };
        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions(),
            new Interactions()
        };
        for (int i = 0; i < 20; i++) interactions[0].SumVisualization();
        for (int i = 0; i < 100; i++) interactions[1].SumVisualization();
        for (int i = 0; i < 66; i++) interactions[2].SumVisualization();

        Order order = new Order(products, interactions, "views");
        List<IProduct> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("B"));
    }

    [Test]
    public void OrderByLikes_IfLikesIsCriteria_FirstIsMostLiked()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Product("Luna nueva", 2009, "USA", "Drama", "Ingles"),
            new Product("IT", 2018, "USA", "Terror", "Ingles"),
            new Product("Balada de pájaros cantores", 2023, "USA", "Romance", "Inglés")
        };
        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions(),
            new Interactions()
        };
        for (int i = 0; i < 101; i++) interactions[0].SumLike();
        for (int i = 0; i < 404; i++) interactions[1].SumLike();
        for (int i = 0; i < 99; i++) interactions[2].SumLike();

        Order order = new Order(products, interactions, "likes"); 
        List<IProduct> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("IT"));
    }

    [Test]
    public void OrderByGenre_IfGenreIsCriteria_FirstIsAlphabetically()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Product("Luna nueva", 2009, "USA", "Drama", "Ingles"),
            new Product("IT", 2018, "USA", "Terror", "Ingles"),
            new Product("Balada de pájaros cantores", 2023, "USA", "Romance", "Inglés")
        };
        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions(),
            new Interactions()
        };

        Order order = new Order(products, interactions, "genre");
        List<IProduct> result = order.GetRanking();

        Assert.That(result[0].Genre, Is.EqualTo("Accion"));
    }

    [Test]
    public void OrderByLanguage_IfLanguageIsCriteria_FirstIsAlphabetically()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Product("Luna nueva", 2009, "USA", "Drama", "Ingles"),
            new Product("IT", 2018, "USA", "Terror", "Ingles"),
            new Product("Balada de pájaros cantores", 2023, "USA", "Romance", "Inglés")
        };
        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions(),
            new Interactions()
        };

        Order order = new Order(products, interactions, "language");
        List<IProduct> result = order.GetRanking();

        Assert.That(result[0].Language, Is.EqualTo("Inglés"));
    }

    [Test]
    public void InvalidCriteria_IfCriteriaIsInvalid_DefaultsToViews()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Product("Luna nueva", 2009, "USA", "Drama", "Ingles"),
            new Product("IT", 2018, "USA", "Terror", "Ingles")
        };
        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions()
        };
        for (int i = 0; i < 10; i++) interactions[0].SumVisualization();
        for (int i = 0; i < 50; i++) interactions[1].SumVisualization();

        Order order = new Order(products, interactions, "algo");
        List<IProduct> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("IT"));
    }

    [Test]
    public void OrderAcceptsUppercaseCriteria_IfCriteriaIsMixedCase_StillWorks()
    {
        List<IProduct> products = new List<IProduct>
        {
            new Product("Luna nueva", 2009, "USA", "Drama", "Ingles"),
            new Product("IT", 2018, "USA", "Terror", "Ingles")
        };
        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions()
        };
        interactions[0].SumRating(1);
        interactions[1].SumRating(5);

        Order order = new Order(products, interactions, "sCoRe");
        List<IProduct> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("IT"));
    }
}