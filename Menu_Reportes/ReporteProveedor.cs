using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPORTES;
using Ventas;

namespace Menu_Reportes
{
    public class ReporteProveedor
    {
        public static void ReporteProveedores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                  REPORTE DE PROVEEDORES                                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            if (Proveedor.contadorProveedores == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay proveedores registrados.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Total de proveedores registrados: {Proveedor.contadorProveedores}\n");

                for (int i = 0; i < Proveedor.contadorProveedores; i++)
                {
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"PROVEEDOR #{i + 1}");
                    Console.ResetColor();
                    Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine($"Código:        {Proveedor.codigosProveedores[i]}");
                    Console.WriteLine($"Empresa:       {Proveedor.empresasProveedores[i]}");
                    Console.WriteLine($"RUC:           {Proveedor.rucProveedores[i]}");
                    Console.WriteLine($"Representante: {Proveedor.representantesProveedores[i]}");
                    Console.WriteLine($"Teléfono:      {Proveedor.telefonosProveedores[i]}");
                    Console.WriteLine($"Dirección:     {Proveedor.direccionesProveedores[i]}");
                    Console.WriteLine($"Ciudad:        {Proveedor.ciudadesProveedores[i]}");
                }
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
