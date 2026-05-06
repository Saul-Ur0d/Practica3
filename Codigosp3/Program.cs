
//Practica 3 Estructuras de datos compuestas
//Inventario de tienda de electronicos

//Act 1

public class Producto
{
    public int Id { get; set; }
    public string CodigoBarras { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public override string ToString()
    {
        return $"{Id} | {CodigoBarras} - {Nombre} | {Precio:C} | Stock: {Stock}";
    }
}

public class GestorProductos
{
    //Lista para mantener orden de insercion y permitir ordenamientos
    
    private List<Producto> listaProductos = new List<Producto>();

    //Diccionario para busquedas rapidas por codigo de barras

    private Dictionary<string, Producto> diccionarioPorCodigo = new Dictionary<string, Producto>();

    //Operaciones con lista

    public void AgregarProductos(Producto p)
    {
        //Validar codigo de barras unico

        if(diccionarioPorCodigo.ContainsKey(p.CodigoBarras))
        {
            throw new Exception("El codigo de barras ya existe");
        }

        listaProductos.Add(p);
        diccionarioPorCodigo[p.CodigoBarras] = p;
    }

    public List<Producto> ObtenerListaProductos()
    {
        return new List<Producto>(listaProductos);
    }

    public bool EliminarProducto(string codigoBarras)
    {
        if (diccionarioPorCodigo.TryGetValue(codigoBarras, out var producto))
        {
            listaProductos.Remove(producto);
            diccionarioPorCodigo.Remove(codigoBarras);
            return true;
        }

        return false;
    }
    public void MostrarInventario()
    {
        Console.WriteLine("Inventario completo (orden de ingreso): ");

        foreach(Producto p in listaProductos)
        {
            Console.WriteLine(p.ToString());
        }
    }

    //Operaciones con diccionario (para busquedas especificas

    public Producto BuscarPorCodigo(string codigoBarras)
    {
        return diccionarioPorCodigo.TryGetValue(codigoBarras, out var producto) ? producto : null;
    }

    public bool ExisteProducto(string codigoBarras)
    {
        return diccionarioPorCodigo.ContainsKey(codigoBarras);
    }

    public void MostrarProductosPorCategoria(string categoria)
    {
        foreach(Producto producto in diccionarioPorCodigo.Values)
        {
            if(producto.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(producto.ToString());
            }
        }
    }
}















