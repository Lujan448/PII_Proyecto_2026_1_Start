using System.Collections.Generic;

namespace Library;
public class Order : IProductSource
{
    // Se guarda en una lista los productos que seran ordenados
    private List<Interactions> interactList;
    private List<Product> rankedList;
    private int totalItems;
    private string criteria;

    public Order (List<Product> products, List<Interactions> interactions, string criteria)
    {
        rankedList = products;
        interactList = interactions;
        totalItems = rankedList.Count;
        //Se normaliza el criterio para evitar errores
        string criter = criteria.ToLower();

        //Se valida el criterio, en caso de que sea invalido se elije "views" por defecto 
        if (criter != "score" && criter != "views" && criter != "language" && criter != "genre" && criter != "likes")
        {
            this.criteria = "views";
        }
        else
        {
            this.criteria = criter;
        }

    }

    // Ordena la lista de productos según el criterio seleccionado 
    public void Sort()
    {
        for (int j = 0; j < totalItems - 1; j++)
        {
            for (int i = 0; i < totalItems - 1; i++)
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
                    Product productOrder = rankedList[i];
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
    public List<Product> GetRanking()
    {
        Sort();
        return rankedList;
    }
}
