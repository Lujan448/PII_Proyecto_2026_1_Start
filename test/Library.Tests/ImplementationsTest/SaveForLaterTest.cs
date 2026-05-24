using Library;

namespace LibraryTests;

[TestFixture]
public class SaveForLaterTest
{
    [Test]
    public void SaveItems_IfItemIsSaved_ItsInList()
    {
        SavesLater savesLater = new SavesLater();
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        savesLater.SaveItems(product);
        Assert.That(savesLater.Saves, Does.Contain(product)); 
    }

    [Test]
    public void SaveItems_IfItemIsNotSaved_ItsNotInList()
    {
        SavesLater savesLater = new SavesLater();
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        Assert.That(savesLater.Saves, Does.Not.Contain(product)); 
    }

    [Test]
    public void SaveItems_IfItemIsSavedTwice_OnlyAppearsOnce()
    {
        SavesLater savesLater = new SavesLater();
        Catalog catalog = new Catalog();
        catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
        IProduct product = catalog.Products[0];
        savesLater.SaveItems(product);
        savesLater.SaveItems(product);
        Assert.That(savesLater.Saves.Count, Is.EqualTo(1));
    }
}