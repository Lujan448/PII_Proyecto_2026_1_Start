using Library;
namespace LibraryTests
{
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

        [Test]
        public void RecommendationsByPreference_IfProductIsNotConsumed_IsRecommended()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User user = new User("María", 19, "Uruguay");
            user.Preferences.Select("Acción", true);
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.RecommendationsByPreference();
            Assert.That(fachada.Recommendation.Recommended, Does.Contain(product));
        }

        [Test]
        public void RecommendationsByPreference_IfProductIsConsumed_IsNotRecommended()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User user = new User("María", 19, "Uruguay");
            user.Preferences.Select("Acción", true);
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.RegisterInteractions(product, new Interactions()); // producto consumido
            fachada.RecommendationsByPreference();
            Assert.That(fachada.Recommendation.Recommended, Does.Not.Contain(product));
        }

        [Test]
        public void RecommendationsToSimilarPeople_IfProductIsNotConsumed_IsRecommended()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User actualUser = new User("María", 19, "Uruguay");
            actualUser.Preferences.Select("Acción", true);
            actualUser.Preferences.Select("Inglés", true);
            User similarUser = new User("Juan", 25, "Argentina");
            similarUser.Preferences.Select("Acción", true);
            similarUser.Preferences.Select("Inglés", true);
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(actualUser, catalog, interactionManager, "views");
            fachada.RegisterUser(similarUser);
            fachada.RecommendationToSimilarPeople(actualUser);
            Assert.That(fachada.Recommendation.Recommended, Does.Contain(product));
        }

        [Test]
        public void RecommendationsToSimilarPeople_IfProductIsConsumed_IsNotRecommended()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User actualUser = new User("María", 19, "Uruguay");
            actualUser.Preferences.Select("Acción", true);
            actualUser.Preferences.Select("Inglés", true);
            User similarUser = new User("Juan", 25, "Argentina");
            similarUser.Preferences.Select("Acción", true);
            similarUser.Preferences.Select("Inglés", true); 
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(actualUser, catalog, interactionManager, "views");
            fachada.RegisterUser(similarUser);
            fachada.RegisterInteractions(product, new Interactions());
            fachada.RecommendationToSimilarPeople(actualUser);
            Assert.That(fachada.Recommendation.Recommended, Does.Not.Contain(product));
        }

        [Test]
        public void RecommendationsToSimilarPeople_IfUsersAreNotSimilar_IsNotRecommended()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User actualUser = new User("María", 19, "Uruguay");
            actualUser.Preferences.Select("Acción", true);
            User similarUser = new User("Juan", 25, "Argentina");
            similarUser.Preferences.Select("Romance", true);
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(actualUser, catalog, interactionManager, "views");
            fachada.RegisterUser(similarUser);
            fachada.RegisterInteractions(product, new Interactions()); // producto consumido
            fachada.RecommendationToSimilarPeople(actualUser);
            Assert.That(fachada.Recommendation.Recommended, Does.Not.Contain(product));
        }

        [Test]
        public void RecommendationsByPopular_IfProductIsNotConsumed_IsRecommended()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            Interactions interactions = new Interactions();
            interactions.SumRating(5);
            InteractionManager interactionManager = new InteractionManager();
            interactionManager.AddInteraction(interactions); // faltaba esto
            User user = new User("María", 19, "Uruguay");
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.RecommendationByPopular();
            Assert.That(fachada.Recommendation.Recommended, Does.Contain(product));
        }

        [Test]
        public void RecommendationsByPopular_IfProductIsConsumed_IsNotRecommended()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            Interactions interactions = new Interactions();
            interactions.SumRating(5); 
            InteractionManager interactionManager = new InteractionManager();
            interactionManager.AddInteraction(interactions);
            User user = new User("María", 19, "Uruguay");
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.RegisterInteractions(product, interactions); 
            fachada.RecommendationByPopular();
            Assert.That(fachada.Recommendation.Recommended, Does.Not.Contain(product));
        }

        [Test]
        public void OrderRecommendations_IfRecommendationsExist_ReturnsOrdered()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            catalog.NewProduct("Breaking Bad", 2008, "USA", "Drama", "Inglés");
            Interactions interactions1 = new Interactions();
            interactions1.SumVisualization();
            Interactions interactions2 = new Interactions();
            for (int i = 0; i < 10; i++) interactions2.SumVisualization();
            InteractionManager interactionManager = new InteractionManager();
            interactionManager.AddInteraction(interactions1);
            interactionManager.AddInteraction(interactions2);
            User user = new User("María", 19, "Uruguay");
            user.Preferences.Select("Acción", true);
            user.Preferences.Select("Drama", true);
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.RecommendationsByPreference();
            fachada.OrderRecommendations();
            Assert.That(fachada.Recommendation.Recommended[0].Name, Is.EqualTo("Breaking Bad"));
        }

        [Test]
        public void RegisterInteractions_IfProductIsRegistered_IsInHistory()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User user = new User("María", 19, "Uruguay");
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            Interactions interactions = new Interactions();
            fachada.RegisterInteractions(product, interactions);
            Assert.That(fachada.LookHistory(), Does.Contain(product));
        }

        [Test]
        public void Like_IfUserLikes_LikesIncrease()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User user = new User("María", 19, "Uruguay");
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            Interactions interactions = new Interactions();
            fachada.Like(product, user, interactions, true);
            Assert.That(interactions.Likes, Is.EqualTo(1));
        }

        [Test]
        public void Like_IfUserDislikes_DislikesIncrease()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User user = new User("María", 19, "Uruguay");
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            Interactions interactions = new Interactions();
            fachada.Like(product, user, interactions, false);
            Assert.That(interactions.Dislikes, Is.EqualTo(1));
        }

        [Test]
        public void LookHistory_IfProductIsConsumed_IsInHistory()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User user = new User("María", 19, "Uruguay");
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.RegisterInteractions(product, new Interactions());
            Assert.That(fachada.LookHistory(), Does.Contain(product));
        }

        [Test]
        public void SaveItemForLater_IfItemIsSaved_IsInSavedList()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User user = new User("María", 19, "Uruguay");
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.SaveItemForLater(product);
            Assert.That(fachada.GetSavedItems(), Does.Contain(product));
        }

        [Test]
        public void RelatedContent_IfProductHasSameGenre_IsRecommended()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            catalog.NewProduct("Breaking Bad", 2008, "USA", "Acción", "Inglés");
            IProduct basee = catalog.Products[0];
            IProduct related = catalog.Products[1];
            User user = new User("María", 19, "Uruguay");
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.RelatedContent(basee);
            Assert.That(fachada.Recommendation.Recommended, Does.Contain(related));
        }

        [Test]
        public void RemoveItemsFromCatalog_IfProductIsRemoved_IsNotInCatalog()
        {
            Catalog catalog = new Catalog();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            User user = new User("María", 19, "Uruguay");
            InteractionManager interactionManager = new InteractionManager();
            Fachadas fachada = new Fachadas(user, catalog, interactionManager, "views");
            fachada.RemoveItemsFromCatalog(product);
            Assert.That(catalog.Products, Does.Not.Contain(product));
        }
    }  
}

