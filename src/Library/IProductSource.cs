namespace Library;
// Interdaz que permite una abstraccion para obtener los productos.
// Permite desacoplar la obtención de datos 
public interface IProductSource
{
    List <Product> GetRanking ();
}