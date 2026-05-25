using System.Collections.Generic;
using System;
//Creamos esta interfaz con el proposito de desacoplar la obtención de datos.
//Esta interfaz va a permitir una abstraccion para obtener los diferentes productos.
//Nuestra mayor razón para crear esta interfaz es que en el caso de que se vaya a crear una clase o varias con productos distintos,
//como todas van a tener más o menos las mismas abstracciones, se va a crear un contrato.
namespace Library
{
    public interface IProduct
    {
        string Name { get; }
        int Year { get; }
        string Country { get; }
        string Genre { get; }
        string Language { get; }
    }    
}
