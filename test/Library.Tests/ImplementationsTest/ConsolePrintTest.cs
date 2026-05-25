using NUnit.Framework;
using Library;
using System.Collections.Generic;
namespace LibraryTests
{
    [TestFixture]
    public class ConsolePrintTest
    {
        [Test]
        public void TextToPrint_IfOneProduct_DisplaysCorrectly()
        {
            List<IProduct> products = new List<IProduct>
            {
                new Product("Red", 2012, "USA", "Pop", "Ingles")
            };
            List<Interactions> interactions = new List<Interactions>
            {
                new Interactions()
            };
            interactions[0].SumRating(5);
            for (int i = 0; i < 1000; i++) interactions[0].SumVisualization();

            Order order = new Order(products, interactions, "views");
            ConsolePrint printer = new ConsolePrint(order);

            string result = printer.TextToPrint();

            Assert.That(result, Is.EqualTo("Red - Puntuación: 5 - Vistas: 1000 - Idioma: Ingles - Género: Pop\n"));
        }

        [Test]
        public void TextToPrint_IfMultipleProducts_DisplaysAllNames()
        {
            List<IProduct> products = new List<IProduct>
            {
                new Product("Red", 2012, "USA", "Pop", "Ingles"),
                new Product("Greedy", 2023, "CAN", "Pop", "Ingles"),
                new Product("Colmillo", 2023, "COL", "Reggaeton", "Español")
            };
            List<Interactions> interactions = new List<Interactions>
            {
                new Interactions(),
                new Interactions(),
                new Interactions()
            };
            interactions[0].SumRating(5);
            interactions[1].SumRating(4);
            interactions[2].SumRating(4);
            for (int i = 0; i < 1000; i++) interactions[0].SumVisualization();
            for (int i = 0; i < 606; i++) interactions[1].SumVisualization();
            for (int i = 0; i < 400; i++) interactions[2].SumVisualization();

            Order order = new Order(products, interactions, "views");
            ConsolePrint printer = new ConsolePrint(order);

            string result = printer.TextToPrint();

            Assert.That(result, Does.Contain("Red"));
            Assert.That(result, Does.Contain("Greedy"));
            Assert.That(result, Does.Contain("Colmillo"));
        }
    }
    
}

