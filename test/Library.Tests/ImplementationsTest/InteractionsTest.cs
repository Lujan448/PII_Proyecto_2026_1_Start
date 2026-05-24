using NUnit.Framework;
using Library;

namespace LibraryTests;

public class InteractionsTests
{
    [Test]
    public void Likes_WhenCreated_StartsAtZero()
    {
        Interactions interactions = new Interactions();
        Assert.That(interactions.Likes, Is.EqualTo(0));
    }

    [Test]
    public void Visualizations_WhenCreated_StartsAtZero()
    {
        Interactions interactions = new Interactions();
        Assert.That(interactions.Visualizations, Is.EqualTo(0));
    }

    [Test]
    public void Recommendations_WhenCreated_StartsAtZero()
    {
        Interactions interactions = new Interactions();
        Assert.That(interactions.Recommendations, Is.EqualTo(0));
    }

    [Test]
    public void SumLike_IfLikeIsAdded_LikesIncreasesByOne()
    {
        Interactions interactions = new Interactions();
        interactions.SumLike();
        Assert.That(interactions.Likes, Is.EqualTo(1));
    }

    [Test]
    public void SumVisualization_IfVisualizationIsAdded_VisualizationsIncreasesByOne()
    {
        Interactions interactions = new Interactions();
        interactions.SumVisualization();
        Assert.That(interactions.Visualizations, Is.EqualTo(1));
    }

    [Test]
    public void SumRecommendation_IfRecommendationIsAdded_RecommendationsIncreasesByOne()
    {
        Interactions interactions = new Interactions();
        interactions.SumRecommendation();
        Assert.That(interactions.Recommendations, Is.EqualTo(1));
    }

    [Test]
    public void SumLike_IfMultipleLikesAdded_LikesEqualsThree()
    {
        Interactions interactions = new Interactions();
        interactions.SumLike();
        interactions.SumLike();
        interactions.SumLike();
        Assert.That(interactions.Likes, Is.EqualTo(3));
    }

    [Test]
    public void SumVisualization_IfMultipleVisualizationsAdded_VisualizationsEqualsThree()
    {
        Interactions interactions = new Interactions();
        interactions.SumVisualization();
        interactions.SumVisualization();
        interactions.SumVisualization();
        Assert.That(interactions.Visualizations, Is.EqualTo(3));
    }

    [Test]
    public void SumRecommendation_IfMultipleRecommendationsAdded_RecommendationsEqualsTwo()
    {
        Interactions interactions = new Interactions();
        interactions.SumRecommendation();
        interactions.SumRecommendation();
        Assert.That(interactions.Recommendations, Is.EqualTo(2));
    }
}