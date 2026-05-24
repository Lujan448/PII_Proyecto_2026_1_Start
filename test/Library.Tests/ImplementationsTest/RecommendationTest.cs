using Library;
namespace LibraryTests;

[TestFixture]
public class RecommendationTest
{
    [Test]
    public void RecommendByPreferences_IfProductMatchesPreference_ReturnsTrue()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        User user = new User("María", 19, "Uruguay");
        user.Preferences.Select("Acción", true);
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);
        bool result = recommendation.RecommendByPreferences(product);
        Assert.That(result, Is.True);
    }

    [Test]
    public void RecommendByPreferences_IfProductDoesNotMatchPreference_ReturnsFalse()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        User user = new User("María", 19, "Uruguay");
        user.Preferences.Select("Romance", true);
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);
        bool result = recommendation.RecommendByPreferences(product);
        Assert.That(result, Is.False);
    }

    [Test]
    public void Recommend_IfProductMatchesPreferenceAndNotConsumed_IsInRecommended()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        User user = new User("María", 19, "Uruguay");
        user.Preferences.Select("Acción", true);
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);
        recommendation.Recommend(product);
        Assert.That(recommendation.Recommended, Does.Contain(product));
    }

    [Test]
    public void Recommend_IfProductIsAlreadyConsumed_IsNotInRecommended()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        User user = new User("María", 19, "Uruguay");
        user.Preferences.Select("Acción", true);
        History history = new History();
        history.AddProductToHistory(product);
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);
        recommendation.Recommend(product);
        Assert.That(recommendation.Recommended, Does.Not.Contain(product));
    }

    [Test]
    public void Recommend_IfProductDoesNotMatchPreference_IsNotInRecommended()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        User user = new User("María", 19, "Uruguay");
        user.Preferences.Select("Romance", true);       //no coincide
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);
        recommendation.Recommend(product);
        Assert.That(recommendation.Recommended, Does.Not.Contain(product));
    }

    [Test]
    public void CompareUsers_IfUsersHaveSimilarPreferences_RecommendSomething()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        User actualUser = new User("María", 19, "Uruguay");
        actualUser.Preferences.Select("Acción", true);
        User similarUser = new User("Juan", 25, "Argentina");
        similarUser.Preferences.Select("Acción", true);
        List<User> users = new List<User> {actualUser, similarUser};
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(actualUser, catalog, history, interactionManager);
        recommendation.CompareUsers(actualUser, product, users);
        Assert.That(recommendation.Recommended, Does.Contain(product));
    }

    [Test]
    public void CompareUsers_IfUsersHaveNotSimilarPreferences_DontRecommendSomething()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        User actualUser = new User("María", 19, "Uruguay");
        actualUser.Preferences.Select("Acción", true);
        User differentUser = new User("Juan", 25, "Argentina");
        differentUser.Preferences.Select("Romance", true);
        List<User> users = new List<User> {actualUser, differentUser};
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(actualUser, catalog, history, interactionManager);
        recommendation.CompareUsers(actualUser, product, users);
        Assert.That(recommendation.Recommended, Does.Contain(product));
    }

    [Test]
    public void CompareAttributes_IfProductHasSameAttributes_IsRecommended()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        catalog.NewProduct("Breaking Bad", 2008, "USA", "Acción", "Inglés");
        IProduct basee = catalog.Products[0];
        User user = new User("María", 19, "Uruguay");
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);
        recommendation.CompareAttributes(basee);
        Assert.That(recommendation.Recommended, Does.Contain(catalog.Products[1]));
    }

    [Test]
    public void CompareAttributes_IfProductHasNotSameAttributes_IsNotRecommended()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        catalog.NewProduct("La casa de los espítitus", 2026, "Chile", "Drama", "Español");
        IProduct basee = catalog.Products[0];
        User user = new User("María", 19, "Uruguay");
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);
        recommendation.CompareAttributes(basee);
        Assert.That(recommendation.Recommended, Does.Not.Contain(catalog.Products[1]));
    }

    [Test]
    public void HasNoHistroy_IfUserHasHistory_ReurnTrue()
    {
        Catalog catalog = new Catalog();
        User user = new User("María", 19, "Uruguay");
        History history = new History();
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);
        Assert.That(recommendation.HasNoHistory(), Is.True);
    }

    [Test]
    public void HasNoHistroy_IfUserHasHistory_ReurnFalse()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];

        User user = new User("María", 19, "Uruguay");
        History history = new History();
        history.AddProductToHistory(product);
        InteractionManager interactionManager = new InteractionManager();
        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);

        Assert.That(recommendation.HasNoHistory(), Is.False);
    }

    [Test]
    public void RecommendPopular_IfItIsPopular_RecommendSomething()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];

        Interactions interactions = new Interactions();
        interactions.SumRating(5); 
        InteractionManager interactionManager = new InteractionManager();
        interactionManager.AddInteraction(interactions);

        User user = new User("María", 19, "Uruguay");
        History history = new History(); 

        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);

        recommendation.RecommendPopular(product);

        Assert.That(recommendation.Recommended, Does.Contain(product));
    }

    [Test]
    public void RecommendPopular_IfItIsNotPopular_RecommendNothing()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];

        Interactions interactions = new Interactions();
        interactions.SumRating(1); 
        InteractionManager interactionManager = new InteractionManager();
        interactionManager.AddInteraction(interactions);

        User user = new User("María", 19, "Uruguay");
        History history = new History();

        Recommendation recommendation = new Recommendation(user, catalog, history, interactionManager);

        recommendation.RecommendPopular(product);

        Assert.That(recommendation.Recommended, Does.Not.Contain(product));
    }
}