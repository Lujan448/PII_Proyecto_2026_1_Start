using Library;
namespace LibraryTests;

[TestFixture]
public class FachadaTest
{
    [Test]
    public void RegisterUser_IfUserIsValid_UserIsInList()
    {
        Catalog catalog = new Catalog();
        User user = new User("María", 19, "Uruguay");
        InteractionManager interactionManager = new InteractionManager();
        Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
        fachada.RegisterUser(user);
        Assert.That(fachada.Users, Does.Contain(user));
    }

    [Test]
    public void RegisterUser_IfUserIsNotValid_UserIsNotInList()
    {
        Catalog catalog = new Catalog();
        User validUser = new User("María", 19, "Uruguay");      //usuario válido para crear la fachada
        User invalidUser = new User("", 19, "Uruguay");         //usuario inválido para registrar
        InteractionManager interactionManager = new InteractionManager();
        Fachadas fachada = new Fachadas(validUser, catalog, interactionManager, "views");
        fachada.RegisterUser(invalidUser);
        Assert.That(fachada.Users, Does.Not.Contain(invalidUser));
    }

    [Test]
    public void DefinePreferences_IfPreferencesIsLike_IsStoredAsTrue()
    {
        Catalog catalog = new Catalog();
        InteractionManager interactionManager = new InteractionManager();
        User user = new User("María", 19, "Uruguay");
        Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
        fachada.DefinePreferences("Acción", true, user);
        Assert.That(user.Preferences.Preference.ContainsKey("Acción"), Is.True);
        Assert.That(user.Preferences.Preference["Acción"], Is.True);
    }

    [Test]
    public void DefinePreferences_IfPreferenceIsDisliked_IsStoredAsFalse()
    {
        Catalog catalog = new Catalog();
        InteractionManager interactionManager = new InteractionManager();
        User user = new User("María", 19, "Uruguay");
        Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
        fachada.DefinePreferences("Romance", false, user);
        Assert.That(user.Preferences.Preference.ContainsKey("Romance"), Is.True);
        Assert.That(user.Preferences.Preference["Romance"], Is.False);
    }

    [Test]
    public void RecommendationsByHistory_IfProductIsNotConsumed_IsRecommended()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];

        User user = new User("María", 19, "Uruguay");
        user.Preferences.Select("Acción", true);

        InteractionManager interactionManager = new InteractionManager();
        Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");

        fachada.RecommendationsByHistory();

        Assert.That(fachada.Recommendation.Recommended, Does.Contain(product));
    }

    [Test]
    public void RecommendationsByHistory_IfProductIsConsumed_IsNotRecommended()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];

        User user = new User("María", 19, "Uruguay");
        user.Preferences.Select("Acción", true);

        InteractionManager interactionManager = new InteractionManager();
        Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
        fachada.RegisterInteractions(product, new Interactions()); // producto consumido

        fachada.RecommendationsByHistory();

        Assert.That(fachada.Recommendation.Recommended, Does.Not.Contain(product));
    }
}