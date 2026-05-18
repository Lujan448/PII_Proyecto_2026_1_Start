using NUnit.Framework;
using Library;

namespace Library.Tests;

public class InteractionsTests
{
    [Test]
    public void LikesStartsAtZero()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Assert
        Assert.AreEqual(0, interactions.Likes);
    }

    [Test]
    public void VisualizationsStartsAtZero()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Assert
        Assert.AreEqual(0, interactions.Visualizations);
    }

    [Test]
    public void RecommendationsStartsAtZero()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Assert
        Assert.AreEqual(0, interactions.Recommendations);
    }

    [Test]
    public void AddLikeAddsOneLike()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Act
        interactions.AddLike();

        // Assert
        Assert.AreEqual(1, interactions.Likes);
    }

    [Test]
    public void AddVisualizationAddsOneVisualization()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Act
        interactions.AddVisualization();

        // Assert
        Assert.AreEqual(1, interactions.Visualizations);
    }

    [Test]
    public void AddRecommendationAddsOneRecommendation()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Act
        interactions.AddRecommendation();

        // Assert
        Assert.AreEqual(1, interactions.Recommendations);
    }

    [Test]
    public void AddLikeAddsMultipleLikes()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Act
        interactions.AddLike();
        interactions.AddLike();
        interactions.AddLike();

        // Assert
        Assert.AreEqual(3, interactions.Likes);
    }

    [Test]
    public void AddVisualizationAddsMultipleVisualizations()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Act
        interactions.AddVisualization();
        interactions.AddVisualization();
        interactions.AddVisualization();

        // Assert
        Assert.AreEqual(3, interactions.Visualizations);
    }

    [Test]
    public void AddRecommendationAddsMultipleRecommendations()
    {
        // Arrange
        Interactions interactions = new Interactions();

        // Act
        interactions.AddRecommendation();
        interactions.AddRecommendation();

        // Assert
        Assert.AreEqual(2, interactions.Recommendations);
    }
}