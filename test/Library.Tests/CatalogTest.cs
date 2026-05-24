using Library;
namespace LibraryTests;

[TestFixture]
public class CatalogTests
{
    [Test]
    public void AddNewProduct_IfProductIsAdd_ItsInList()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        Assert.That(catalog.Products.Count, Is.EqualTo(1));
        Assert.That(catalog.Products[0].Name, Is.EqualTo("Peaky Blinders"));   
    }

    [Test]
    public void AddNewProduct_IfProductIsNotAdd_ItsNotInList()
    {
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        Assert.That(catalog.Products.Count, Is.Not.EqualTo(1)); 
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