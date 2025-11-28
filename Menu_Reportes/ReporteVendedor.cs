using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPORTES;
using Ventas;

namespace Menu_Reportes
{
    public class ReporteVendedor
    {
        public static void ReporteVendedores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                  REPORTE DE VENDEDORES                                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            if (Vendedor.contadorVendedores == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay vendedores registrados.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Total de vendedores registrados: {Vendedor.contadorVendedores}\n");
                Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine("{0,-12} {1,-25} {2,-25} {3,-12} {4,-12}", "CÓDIGO", "NOMBRES", "APELLIDOS", "TELÉFONO", "SUELDO");
                Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════");

                decimal totalSueldos = 0;
                for (int i = 0; i < Vendedor.contadorVendedores; i++)
                {
                    Console.WriteLine("{0,-12} {1,-25} {2,-25} {3,-12} S/ {4,-10:F2}",
                        Vendedor.codigosVendedores[i],
                        Vendedor.nombresVendedores[i],
                        Vendedor.apellidosVendedores[i],
                        Vendedor.telefonosVendedores[i],
                        Vendedor.sueldosVendedores[i]);
                    totalSueldos += Vendedor.sueldosVendedores[i];
                }
                Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{"",78}Total en sueldos: S/ {totalSueldos:F2}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
