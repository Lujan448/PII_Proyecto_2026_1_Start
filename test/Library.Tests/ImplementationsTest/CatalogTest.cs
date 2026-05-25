using Library;
using NUnit.Framework;
using System.Collections.Generic;
namespace LibraryTests
{
    [TestFixture]
    public class CatalogTests
    {
        Catalog catalog = new Catalog();
        [Test]
        public void AddNewProduct_IfProductIsAdd_ItsInList()
        {
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            Assert.That(catalog.Products.Count, Is.EqualTo(1));
            Assert.That(catalog.Products[0].Name, Is.EqualTo("Peaky Blinders"));   
        }

        [Test]
        public void AddNewProduct_IfProductIsNotAdd_ItsNotInList()
        {
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            Assert.That(catalog.Products.Count, Is.Not.EqualTo(0)); 
        }

        [Test]
        public void RemoveProduct_IfProductIsRemoved_ProductIsNotInList()
        {
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            catalog.RemoveProduct(product);
            Assert.That(catalog.Products, Does.Not.Contain(product));
        }

        [Test]
        public void RemoveProduct_IfProductIsNotRemoved_ProductIsInList()
        {
            catalog.NewProduct("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            IProduct product = catalog.Products[0];
            Assert.That(catalog.Products, Does.Contain(product));
        }
    }
    
}
