
using System;
using System.Collections.Generic;

class Producto
{
    public string Id { get; set; }

    public string Name { get; set; }

    public double Precio { get; set; }
}



class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World");

        List<Producto> ProductosCarrito = new List<Producto>();


        List<Producto> ListaProductos = new List<Producto>();


        Producto producto1 = new Producto { Id = "a1", Name = "Producto 1", Precio = 11.3 };
        ListaProductos.Add(producto1 );

        Producto producto2 = new Producto { Id = "a2", Name = "Producto 2", Precio = 12.3 };
        ListaProductos.Add(producto2);


        Producto producto3 = new Producto { Id = "a3", Name = "Producto 3", Precio = 13.3 };
        ListaProductos.Add(producto3);


        List<double> precios = new List<double>();

        foreach (var pre in ProductosCarrito)
        {
            precios.Add(pre.Precio);
        }

        

        
        int opcion = 0;

        while (opcion != 4)
        {
            // Mostramos el menú
            Console.WriteLine("=== Carrito de compras ===");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Ver carrito de compras");
            Console.WriteLine("3. Calcular precio total");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarAlCarro(ListaProductos, ProductosCarrito);
                    break;
                case 2:
                    MostrarProductos(ProductosCarrito);
                    break;
                case 3:
                    if (ProductosCarrito.Count == 0)
                    {
                        Console.WriteLine("El carrito de compras está vacío.");
                    }
                    else
                    {
                        CalcularPrecio(precios,ProductosCarrito);                      
                    }
                    break;
                case 4:
                    Console.WriteLine("Gracias por usar el carrito de compras.");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor seleccione una opción del menú.");
                    break;

            }

        }

    }

    static void MostrarProductos(List<Producto> lista)
    {
        Console.WriteLine("ID    NOMBRE    PRECIO");

        foreach (Producto producto in lista)
        {
            Console.WriteLine(producto.Id + "    " + producto.Name + "    " + producto.Precio);
        }
    }

    static void AgregarAlCarro(List<Producto> ListaProductos, List<Producto> ProductosCarrito)
    {
        MostrarProductos(ListaProductos);
        string codigo = "";
        Console.WriteLine("Ingresa el codigo del producto a elegir: ");
        codigo = Console.ReadLine();

        //MostrarProductos(ProductosCarrito);
        foreach (var producto in ListaProductos)
        {
            if (producto.Id == codigo)
            {
                ProductosCarrito.Add(producto);
                Console.WriteLine($"Se añadio {producto.Name}...");
                break;
            }
        }

        Console.WriteLine("No existe ese producto...");
        //MostrarProductos(ProductosCarrito);
    }

    static void CalcularPrecio(List<double> precios, List<Producto> ProductosCarrito)
    {

        foreach (var pre in ProductosCarrito)
        {
            precios.Add(pre.Precio);
        }

        int contador = 0;
        double PrecioFinal= 0;
        
        for (int i = 0; i < precios.Count; i++)
        {
            PrecioFinal += precios[i];
            contador++;
        }

        Console.WriteLine("El precio total de los productos en el carrito es de: {0:C}", PrecioFinal);
    }
}