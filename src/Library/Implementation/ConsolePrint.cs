using System.Collections.Generic;
using System;
//Creamos esta clase aplicando el patrón de diseño Expert, ya que esta clase es la experta de la información
//para imprimir la lista de recomendaciones ordenada.
//Además, utilizamos uno de los principios SOLID, el cual es SRP, con el proposito de que la clase Order no tuviera más 
//de una razón de cambio, entonces, para que no suceda tal cosa, decidimos realizar una clase aparte para las impresiones.
namespace Library
{
    public class ConsolePrint
    {
        //Obtiene la lista de los productos ya ordenados
        private Order order;
        public Order Order { get; }
        public ConsolePrint (Order order)
        {
            this.order = order;
        }
        //Construye el texto para mostrar los productos
        public string TextToPrint()
        {
            List<IProduct> rank = order.GetRanking();
            string result = "";

            for (int i = 0; i < rank.Count; i++)
            {
                result += $"{rank[i].Name} - Puntuación: {order.InteractList[i].AverageRating} - Vistas: {order.InteractList[i].Visualizations} - Idioma: {rank[i].Language} - Género: {rank[i].Genre}\n";
            }
            return result;
        }

        //Imprime el texto generado en la consola
        public void Print()
        {
            Console.WriteLine(TextToPrint());
        }
    }
}