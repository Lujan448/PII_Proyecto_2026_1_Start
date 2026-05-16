//visualizaciones - likes - puntuaciones(estrellas)- recomendaciones a otros usuarios
public class Interactions
{
    private int likes;
    private int visualizations;
    private int recommendations;
    private double totalStars;
    private int totalRatings;

    public Interactions()
    {
        this.likes = 0;
        this.visualizations = 0;
        this.recommendations = 0;
        this.totalStars = 0;
        this.totalRatings = 0;
    }

    public int Likes
    {
        get { return this.likes; }
    }

    public int Visualizations
    {
        get { return this.visualizations; }
    }

    public int Recommendations
    {
        get { return this.recommendations; }
    }

    public double AverageRating
    {
        get
        {
            if (this.totalRatings == 0)
            {
                return 0;
            }

            return this.totalStars / this.totalRatings;
        }
    }

    public void AddLike()
    {
        this.likes++;
    }

    public void AddVisualization()
    {
        this.visualizations++;
    }

    public void AddRecommendation()
    {
        this.recommendations++;
    }

    public void AddRating(int stars)
    {
        if (stars >= 1 && stars <= 5)
        {
            this.totalStars += stars;
            this.totalRatings++;
        }
    }
}


