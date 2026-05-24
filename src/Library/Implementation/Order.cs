//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para ordenar la lista de recomendaciones.
//Además, utilizamos uno de los principios SOLID, el cual es SRP, con el proposito de que la clase Order no tuviera más 
//de una razón de cambio.
namespace Library
{
    public class Order : IRanking
    {
        private List<Interactions> interactList;
        public List<Interactions> InteractList { get { return interactList; } }
        private List<IProduct> rankedList;
        private string criteria;

        public Order(List<IProduct> products, List<Interactions> interactions, string criteria)
        {
            rankedList = products;
            interactList = interactions;
            //Se normaliza el criterio para evitar errores.
            string criter = criteria.ToLower();

            //Se valida el criterio, en caso de que sea invalido se elije "views" por defecto.
            if (criter != "score" && criter != "views" && criter != "language" && criter != "genre" && criter != "likes")
            {
                this.criteria = "views";
            }
            else
            {
                this.criteria = criter;
            }

        }

        //se ordena la lista de productos según el criterio seleccionado.
        public void Sort()
        {
            for (int j = 0; j < rankedList.Count - 1; j++)
            {
                for (int i = 0; i < rankedList.Count - 1; i++)
                {
                    bool needSwap = false;

                    if (criteria == "score")
                    {
                        if (interactList[i].AverageRating < interactList[i + 1].AverageRating)
                        {
                            needSwap = true;
                        }
                    }

                    else if (criteria == "views")
                    {
                        if (interactList[i].Visualizations < interactList[i + 1].Visualizations)
                        {
                            needSwap = true;
                        }
                    }

                    else if (criteria == "language")
                    {
                        if (rankedList[i].Language.CompareTo(rankedList[i + 1].Language) > 0)
                        {
                            needSwap = true;
                        }
                    }

                    else if (criteria == "genre")
                    {
                        if (rankedList[i].Genre.CompareTo(rankedList[i + 1].Genre) > 0)
                        {
                            needSwap = true;
                        }
                    }

                    else if (criteria == "likes")
                    {
                        if (interactList[i].Likes < interactList[i + 1].Likes)
                        {
                            needSwap = true;
                        }
                    }

                    if (needSwap)
                    {
                        IProduct productOrder = rankedList[i];
                        rankedList[i] = rankedList[i + 1];
                        rankedList[i + 1] = productOrder; 

                        Interactions interactOrder = interactList[i];   
                        interactList[i] =  interactList[i + 1];
                        interactList[i + 1] = interactOrder; 
                    }

                }
            }
        }
        //Devuelve la lista ya ordenada
        public List<IProduct> GetRanking()
        {
            Sort();
            return rankedList;
        }
    }
}

