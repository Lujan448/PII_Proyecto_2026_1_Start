namespace Library;
// Interdaz que permite una abstraccion para obtener los productos.
// Permite desacoplar la obtención de datos 
public interface IProduct
{
    string Name { get; }
    int Year { get; }
    string Country { get; }
    string Genre { get; }
    string Language { get; }
}