//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para gestionar el funcionamiento de las interacciones de manera individual.
//Además, utilizamos uno de los principios SOLID, el cual es SRP, con el proposito de que la clase Interactions no tenga más de una 
//razón de cambio. La distinción entre esta clase e InteractionManager es que InteractionManager se va a encargar de la cración y la
//gestión de un conjunto de interacciones.
namespace Library
{
    public class Interactions
    {
        private int likes;
        public int Likes { get {return likes; } }
        private int visualizations;
        public int Visualizations { get {return visualizations; } }
        private int recommendations;
        public int Recommendations { get {return recommendations; } }
        private double totalStars;
        public double TotalStars { get {return totalStars; } }
        private int totalRatings;
        public int TotalRatings { get {return totalRatings; } }
        private int dislikes;
        public int Dislikes { get { return dislikes; } }

        public Interactions()
        {
            this.likes = 0;
            this.visualizations = 0;
            this.recommendations = 0;
            this.totalStars = 0;
            this.totalRatings = 0;
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

        public void SumDislike()
        {
            this.dislikes++;
        }

        public void SumLike()
        {
            this.likes++;
        }

        public void SumVisualization()
        {
            this.visualizations++;
        }

        public void SumRecommendation()
        {
            this.recommendations++;
        }

        public void SumRating(int stars)
        {
            if (stars >= 1 && stars <= 5)
            {
                this.totalStars += stars;
                this.totalRatings++;
            }
        }
        
        //si es popular devuelve true si no es popular devuelve false
        public bool IsPopular()
        {
            if (AverageRating >= 3)     //En esta parte lo que hicimos fue poner una condición donde la evaluacion del producto es mayor o igual a 3
            {                           //para que solo devuelva si el producto es popular, en caso de que no sea mayor o igual a 3, 
                return true;            //devuelve que el producto no es popular. 
            }
            return false;
        }
    }
    
}
