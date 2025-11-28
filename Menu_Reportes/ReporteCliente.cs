using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPORTES;
using Ventas;

namespace Menu_Reportes
{
    public class ReporteCliente
    {
        public static void ReporteClientes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                    REPORTE DE CLIENTES                                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            if (Cliente.contadorClientes == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay clientes registrados.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Total de clientes registrados: {Cliente.contadorClientes}\n");
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine("{0,-10} {1,-25} {2,-25} {3,-12} {4,-30}", "DNI", "NOMBRES", "APELLIDOS", "TELÉFONO", "EMAIL");
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");

                for (int i = 0; i < Cliente.contadorClientes; i++)
                {
                    Console.WriteLine("{0,-10} {1,-25} {2,-25} {3,-12} {4,-30}",
                        Cliente.dniClientes[i],
                        Cliente.nombresClientes[i],
                        Cliente.apellidosClientes[i],
                        Cliente.telefonosClientes[i],
                        Cliente.emailsClientes[i]);
                    Console.WriteLine($"           Dirección: {Cliente.direccionesClientes[i]}");
                    Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
