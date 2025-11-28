using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPORTES;
using Ventas;

namespace Menu_Reportes
{
    public class ReporteProducto
    {
        public static void ReporteProductos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                   REPORTE DE PRODUCTOS                                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            if (Productos.contadorProductos == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay productos registrados.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Total de productos registrados: {Productos.contadorProductos}\n");
                Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine("{0,-12} {1,-30} {2,-20} {3,-10} {4,-12}", "CÓDIGO", "NOMBRE", "CATEGORÍA", "STOCK", "PRECIO");
                Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════");

                for (int i = 0; i < Productos.contadorProductos; i++)
                {
                    Console.WriteLine("{0,-12} {1,-30} {2,-20} {3,-10} S/ {4,-10:F2}",
                        Productos.codigosProductos[i],
                        Productos.nombresProductos[i],
                        Productos.categoriasProductos[i],
                        Productos.stockProductos[i],
                        Productos.preciosProductos[i]);
                }
                Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
