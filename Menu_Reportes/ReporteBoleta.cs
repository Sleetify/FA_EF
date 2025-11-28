using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPORTES;
using Ventas;

namespace Menu_Reportes
{
    public class ReporteBoleta
    {
        public static void ReporteBoletas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                    REPORTE DE BOLETAS                                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            if (Boleta.contadorBoletas == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay boletas registradas.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"Total de boletas emitidas: {Boleta.contadorBoletas}\n");

                decimal totalVentas = 0;
                for (int i = 0; i < Boleta.contadorBoletas; i++)
                {
                    Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"BOLETA: {Boleta.numerosBoleta[i]}");
                    Console.ResetColor();
                    Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine($"Fecha:    {Boleta.fechasBoleta[i]}");
                    Console.WriteLine($"Cliente:  {Boleta.nombresClientesBoleta[i]}");
                    Console.WriteLine($"DNI:      {Boleta.dniClientesBoleta[i]}");
                    Console.WriteLine();
                    Console.WriteLine("{0,-30} {1,-10} {2,-15} {3,-15}", "PRODUCTO", "CANT.", "P.UNITARIO", "SUBTOTAL");
                    Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");

                    for (int j = 0; j < Boleta.cantidadProductosPorBoleta[i]; j++)
                    {
                        decimal subtotalLinea = Boleta.cantidadesVendidas[i, j] * Boleta.preciosVendidos[i, j];
                        Console.WriteLine("{0,-30} {1,-10} S/ {2,-13:F2} S/ {3,-13:F2}",
                            Boleta.productosVendidos[i, j],
                            Boleta.cantidadesVendidas[i, j],
                            Boleta.preciosVendidos[i, j],
                            subtotalLinea);
                    }

                    Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine($"{"",55}Subtotal:  S/ {Boleta.subtotalesBoleta[i],10:F2}");
                    Console.WriteLine($"{"",55}IGV (18%): S/ {Boleta.igvBoleta[i],10:F2}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{"",55}TOTAL:     S/ {Boleta.totalesBoleta[i],10:F2}");
                    Console.ResetColor();
                    Console.WriteLine();

                    totalVentas += Boleta.totalesBoleta[i];
                }

                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n{"",55}TOTAL VENTAS: S/ {totalVentas,10:F2}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
