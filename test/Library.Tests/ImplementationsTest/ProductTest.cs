using Library;

namespace LibraryTests
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void CheckProductAtrributes_IfAttributesAreRight_ReturnTrue()
        {
            Product product = new Product("Peaky Blinders", 2016, "Reino Unido", "Acción", "Inglés");
            Assert.That(product.Name, Is.EqualTo("Peaky Blinders"));
            Assert.That(product.Year, Is.EqualTo(2016));
            Assert.That(product.Country, Is.EqualTo("Reino Unido"));
            Assert.That(product.Genre, Is.EqualTo("Acción"));
            Assert.That(product.Language, Is.EqualTo("Inglés"));
        }
    } 
}