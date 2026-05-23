using Library;

namespace LibraryTests;

[TestFixture]
public class OrderTest
{

    [Test]
    public void OrderByScore()
    {
        var products = new List<Product>
        {
            new Product("A", 2021, "USA", "Comedia", "Ingles"),
            new Product("B", 2019, "USA", "Acción", "Ingles"),
            new Product("C", 2020, "URU", "Romance", "Español")
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

        List<Product> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("B"));
    }

    [Test]
    public void OrderByViews()
    {
        List<Product> products = new List<Product>
        {
            new Product("A", 2021, "USA", "Comedia", "Ingles"),
            new Product("B", 2019, "USA", "Acción", "Ingles"),
            new Product("C", 2020, "URU", "Romance", "Español")
        };

        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions(),
            new Interactions()
        };

        for (int i = 0; i < 20; i++)
        {
         interactions[0].SumVisualization();   
        }

        for (int i = 0; i < 100; i++)
        {
         interactions[1].SumVisualization();   
        }

        for (int i = 0; i < 66; i++)
        {
         interactions[2].SumVisualization();   
        }

        Order order = new Order(products, interactions, "views");

        List<Product> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("B"));
    }

    [Test]
    public void OrderByLikes()
     {
        List<Product> products = new List<Product>
        {
            new Product("A", 2021, "USA", "Comedia", "Ingles"),
            new Product("B", 2019, "USA", "Acción", "Ingles"),
            new Product("C", 2020, "URU", "Romance", "Español")
        };

        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions(),
            new Interactions()
        };

        for (int i = 0; i < 101; i++)
        {
         interactions[0].SumLike();   
        }

        for (int i = 0; i < 404; i++)
        {
         interactions[1].SumLike();   
        }

        for (int i = 0; i < 99; i++)
        {
         interactions[2].SumLike();   
        }

        Order order = new Order(products, interactions, "like");

        List<Product> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("B"));
    }

    [Test]
    public void OrderByGenre()
    {
        List<Product> products = new List<Product>
        {
            new Product("A", 2021, "USA", "Comedia", "Ingles"),
            new Product("B", 2020, "USA", "Accion", "Ingles"),
            new Product("C", 2019, "URU", "Romance", "Español")
        };

        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions(),
            new Interactions()
        };

        Order order = new Order(products, interactions, "genre");

        List<Product> result = order.GetRanking();

        Assert.That(result[0].Genre, Is.EqualTo("Accion"));
    }
    

    [Test]
    public void OrderByLanguage()
    {
    List<Product> products = new List<Product>
    {
        new Product("A", 2021, "USA", "Comedia", "Portugues"),
        new Product("B", 2020, "USA", "Accion", "Español"),
        new Product("C", 2019, "URU", "Romance", "Ingles")
    };

    List<Interactions> interactions = new List<Interactions>
    {
        new Interactions(),
        new Interactions(),
        new Interactions()
    };

    Order order = new Order(products, interactions, "language");

    List<Product> result = order.GetRanking();

    Assert.That(result[0].Language, Is.EqualTo("Español"));
}

    [Test]
    public void InvalidCriteriaDefaultsToViews()
    {
        List<Product> products = new List<Product>
        {
            new Product("A", 2021, "USA", "Comedia", "Ingles"),
            new Product("B", 2020, "USA", "Accion", "Español")
        };

        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions()
        };

        for (int i = 0; i < 10; i++)
        {
            interactions[0].SumVisualization();
        }

        for (int i = 0; i < 50; i++)
        {
            interactions[1].SumVisualization();
        }

        Order order = new Order(products, interactions, "algo");

        List<Product> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("B"));
    }


    [Test]
    public void OrderAcceptsUppercaseCriteria()
    {
        List<Product> products = new List<Product>
        {
            new Product("A", 2021, "USA", "Comedia", "Ingles"),
            new Product("B", 2020, "USA", "Accion", "Español")
        };

        List<Interactions> interactions = new List<Interactions>
        {
            new Interactions(),
            new Interactions()
        };

        interactions[0].SumRating(1);
        interactions[1].SumRating(5);

        Order order = new Order(products, interactions, "sCoRe");

        List<Product> result = order.GetRanking();

        Assert.That(result[0].Name, Is.EqualTo("B"));
    }
}