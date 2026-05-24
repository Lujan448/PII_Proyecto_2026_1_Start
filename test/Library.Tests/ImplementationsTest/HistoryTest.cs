using Library;
namespace LibraryTests
{
    [TestFixture]
    public class HistoryTests
    {
        [Test]
        public void AddNewProductToTheHistory_IfProductIsAdd_ItsInList()
        {
            Catalog catalog = new Catalog();
            History history = new History();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            history.AddProductToHistory(product);
            Assert.That(history.Histories.Count, Is.EqualTo(1));
            Assert.That(history.Histories[0].Name, Is.EqualTo("Peaky Blinders"));   
        }

        [Test]
        public void AddNewProductToTheHistory_IfProductIsNotAdd_ItsNotInList()
        {
            Catalog catalog = new Catalog();
            History history = new History();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            Assert.That(history.Histories.Count, Is.Not.EqualTo(1)); 
        }

        [Test]
        public void AddInteractionToHistory_IfInteractionAdd_ItsInList()
        {
            History history = new History();
            Interactions interactions = new Interactions();
            history.AddInteractionToHistory(interactions);
            Assert.That(history.Interactions.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddInteractionToHistory_IfInteractionIsNotAdd_ItsNotInList()
        {
            History history = new History();
            Interactions interactions = new Interactions();
            Assert.That(history.Interactions.Count, Is.Not.EqualTo(1));
        }

        [Test]
        public void GetConsumedPorducts_IfProductIsConsumed_ReturnTrue()
        {
            Catalog catalog = new Catalog();
            History history = new History();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            history.AddProductToHistory(product);
            Assert.That(history.Consumed(product), Is.True);
        }

        [Test]
        public void GetConsumedPorducts_IfProductIsNotConsumed_ReturnFalse()
        {
            Catalog catalog = new Catalog();
            History history = new History();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            Assert.That(history.Consumed(product), Is.False);
        }

        [Test]
        public void RemoveProductFromHistory_IfProductIsRemoved_ProductIsNotInHistory()
        {
            Catalog catalog = new Catalog();
            History history = new History();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            history.AddProductToHistory(product);
            history.RemoveFromHistory(product);
            Assert.That(history.Histories, Does.Not.Contain(product));   
        }

        [Test]
        public void RemoveProductFromHistory_IfProductIsNotRemoved_ProductIsInHistory()
        {
            Catalog catalog = new Catalog();
            History history = new History();
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            history.AddProductToHistory(product);
            Assert.That(history.Histories, Does.Contain(product));   
        }
    }
    
}

