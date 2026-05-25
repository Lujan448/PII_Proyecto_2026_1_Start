using System.Collections.Generic;
using System;
//Creamos esta interfaz con el proposito de desacoplar la obtención de datos.
//Esta interfaz va a permitir una abstracción para obtener la lista de productos ordenados.
//Nuestra mayor razón para crear esta interfaz es que en el caso de que se vaya a crear una nueva forma
//de ordenar productos, como todas van a tener el mismo método, se va a crear un contrato.
namespace Library
{
    public interface IRanking
    {
        List <IProduct> GetRanking ();
    }  
}
