using System.Collections.Generic;

namespace Library;
public class Order : IProductSource
{
    // Se guarda en una lista los productos que seran ordenados
    private List<Product> rankedList;
    private int totalItems;
    private string criteria;

    public Order (List<Product> products, string criteria)
    {
        rankedList = products;
        totalItems = rankedList.Count;
        //Se normaliza el criterio para evitar errores
        string c = criteria.ToLower();

        //Se valida el criterio, en caso de que sea invalido se elije "views" por defecto 
        if (c != "score" && c != "views" && c != "language" && c != "genre")
        {
            this.criteria = "views";
        }
        else
        {
            this.criteria = c;
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
                    if (rankedList[i].Score < rankedList[i + 1].Score)
                    {
                        needSwap = true;
                    }
                }

                else if (criteria == "views")
                {
                    if (rankedList[i].Views< rankedList[i + 1].Views)
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

                if (needSwap)
                {
                    Product productOrder = rankedList[i];

                    rankedList[i] = rankedList[i + 1];

                    rankedList[i + 1] = productOrder;    
                }

            }
        }

    }
    //Devuelve la lista ya ordenada
    public IEnumerable <Product> GetRanking()
    {
        Sort();
        return rankedList;
    }


}
