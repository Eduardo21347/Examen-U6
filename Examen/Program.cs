using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen
{
    class Program
    {
        public class InventarioA
        {
            // Campos 
            public string NombreP, DescripcionP;
            public float Precio;
            public int Stock;

            public void CrearAchivo()
            {
                StreamWriter sw = new StreamWriter("Productos.txt", true);

                try
                {
                    // Captura de datos
                    Console.Clear();
                    Console.WriteLine("Llenado de inventario");
                    Console.Write("\nEscriba el nombre del producto: ");
                    NombreP = Console.ReadLine();
                    Console.Write("Escriba la descripción del producto: ");
                    DescripcionP = Console.ReadLine();
                    Console.Write("Escriba el precio del producto: ");
                    Precio = float.Parse(Console.ReadLine());
                    Console.Write("Escriba el stock disponible: ");
                    Stock = int.Parse(Console.ReadLine());

                    sw.WriteLine("Nombre: " + NombreP);
                    sw.WriteLine("Descripción: " + DescripcionP);
                    sw.WriteLine("Precio: " + Precio);
                    sw.WriteLine("Cantidad: " + Stock);
                }
                catch (IOException e)
                {
                    Console.WriteLine("\nError : " + e.Message);
                    Console.WriteLine("\nRuta : " + e.StackTrace);
                }
                finally
                {
                    Console.Write("\nPresione ''Enter'' para regresar al Menu.");
                    sw.Close();
                    Console.ReadKey();
                }
            }
            public void Mostrar()
            {
                StreamWriter sw = new StreamWriter("Productos.txt", true);
                try
                {
                    // Despliegue de datos 
                    Console.Clear();
                    // Muestra los datos 
                    Console.WriteLine("\nInventario de Amazon");
                    Console.WriteLine("Nombre del producto: " + NombreP);
                    Console.WriteLine("Descripción del producto: " + DescripcionP);
                    Console.WriteLine("Precio del producto: " + Precio);
                    Console.WriteLine("Stock del producto: " + Stock);
                    Console.WriteLine("\n");
                }
                catch (EndOfStreamException)
                {
                    Console.WriteLine("\n\nFin del Inventario");
                    Console.Write("\nPresione ENTER para continuar");
                }
                finally
                {
                    Console.Write("\nPresione ''Enter'' para terminar la lectura de datos y regresar al menú");
                    sw.Close();
                    Console.ReadKey();
                }
            }
        }
        static void Main(string[] args)
        {
            // Variable
            int Opcion;

            // Objeto
            InventarioA In = new InventarioA();
            // Menu de opciones
            do
            {
                Console.Clear();
                Console.WriteLine("\nInventario Amazon");
                Console.WriteLine("1.- Llenar inventario.");
                Console.WriteLine("2.- Ver inventario.");
                Console.WriteLine("3.- Salir del programa.");
                Console.Write("\n¿Cual opción deseas? ");
                Opcion = Int16.Parse(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        // Llenado del archivo 
                        try
                        {
                            // Llamada al metodo
                            In.CrearAchivo();
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                            Console.WriteLine("\nRuta: " + e.StackTrace);
                        }
                        break;

                    case 2:
                        // Bloque de lectura 
                        try
                        {
                            // Llamada al metodo
                            In.Mostrar();
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError: " + e.Message);
                            Console.WriteLine("\nRuta: " + e.StackTrace);
                        }
                        break;
                    case 3:
                        Console.Write("\nPresione ''Enter'' para salir del programa.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nOpción no valida, presione ''Enter'' para continuar");
                        Console.ReadKey();
                        break;
                }

            } while (3 == Opcion);
        }
    }
}
