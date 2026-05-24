using Library;
namespace LibraryTests;

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
    public void RemoveProduct_IfProductIsRemoved_ProductIsNotInList()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        catalog.RemoveProduct(product);
        Assert.That(catalog.Products, Does.Not.Contain(product));
    }

    [Test]
    public void RemoveProduct_IfProductIsNotRemoved_ProductIsInList()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        Assert.That(catalog.Products, Does.Contain(product));
    }
}