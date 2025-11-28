using System;
using System.Text.RegularExpressions;
using REPORTES;
using Ventas;
using Menu_Reportes;

class SistemaVentas
{


    static void Main()
    {
        bool salir = false;
        while (!salir)
        {
            salir = MostrarMenuPrincipal();
        }
    }

    static bool MostrarMenuPrincipal()
    {
        string[] opcionesMenu = { "REGISTRAR", "VENTAS", "REPORTES", "MODIFICAR", "AYUDA", "SALIR" };
        int opcionSeleccionada = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║        \tSISTEMA PARA GESTIONAR VENTAS                ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Use las flechas ← → para navegar y Enter para seleccionar\n");

            for (int i = 0; i < opcionesMenu.Length; i++)
            {
                if (i == opcionSeleccionada)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"  [ {opcionesMenu[i]} ]  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"    {opcionesMenu[i]}    ");
                }
            }
            Console.WriteLine("\n");

            ConsoleKeyInfo tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.LeftArrow)
            {
                opcionSeleccionada = (opcionSeleccionada - 1 + opcionesMenu.Length) % opcionesMenu.Length;
            }
            else if (tecla.Key == ConsoleKey.RightArrow)
            {
                opcionSeleccionada = (opcionSeleccionada + 1) % opcionesMenu.Length;
            }
            else if (tecla.Key == ConsoleKey.Enter)
            {
                if (opcionSeleccionada == 0)
                {
                    MenuRegistrar();
                }
                else if (opcionSeleccionada == 1)
                {
                    MenuVentas();
                }
                else if (opcionSeleccionada == 2)
                {
                    MenuReportes();
                }
                else if (opcionSeleccionada == 5)
                {
                    return true; // Salir del programa
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n[Opción en desarrollo]");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }

    static void MenuRegistrar()
    {
        string[] opcionesRegistro = { "PRODUCTOS", "CLIENTES", "VENDEDORES", "PROVEEDORES" };
        int opcionSeleccionada = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    MENÚ REGISTRAR                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Use las flechas ↑ ↓ para navegar, Enter para seleccionar y ESC para volver\n");

            for (int i = 0; i < opcionesRegistro.Length; i++)
            {
                if (i == opcionSeleccionada)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  ► {opcionesRegistro[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"    {opcionesRegistro[i]}");
                }
            }

            ConsoleKeyInfo tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.UpArrow)
            {
                opcionSeleccionada = (opcionSeleccionada - 1 + opcionesRegistro.Length) % opcionesRegistro.Length;
            }
            else if (tecla.Key == ConsoleKey.DownArrow)
            {
                opcionSeleccionada = (opcionSeleccionada + 1) % opcionesRegistro.Length;
            }
            else if (tecla.Key == ConsoleKey.Enter)
            {
                switch (opcionSeleccionada)
                {
                    case 0:
                        Productos.RegistrarProducto();
                        break;
                    case 1:
                        Cliente.RegistrarCliente();
                        break;
                    case 2:
                        Vendedor.RegistrarVendedor();
                        break;
                    case 3:
                        Proveedor.RegistrarProveedor();
                        break;
                }
            }
            else if (tecla.Key == ConsoleKey.Escape)
            {
                return; // Volver al menú principal
            }
        }
    }
    static void MenuVentas()
    {
        string[] opcionesVentas = { "BOLETA", "FACTURA", "GUIA REM", "PROFORMA" };
        int opcionSeleccionada = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      MENÚ VENTAS                           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Use las flechas ↑ ↓ para navegar, Enter para seleccionar y ESC para volver\n");

            for (int i = 0; i < opcionesVentas.Length; i++)
            {
                if (i == opcionSeleccionada)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  ► {opcionesVentas[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"    {opcionesVentas[i]}");
                }
            }

            ConsoleKeyInfo tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.UpArrow)
            {
                opcionSeleccionada = (opcionSeleccionada - 1 + opcionesVentas.Length) % opcionesVentas.Length;
            }
            else if (tecla.Key == ConsoleKey.DownArrow)
            {
                opcionSeleccionada = (opcionSeleccionada + 1) % opcionesVentas.Length;
            }
            else if (tecla.Key == ConsoleKey.Enter)
            {
                switch (opcionSeleccionada)
                {
                    case 0:
                        Boleta.GenerarBoleta();
                        break;
                    case 1:
                    case 2:
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n[Opción en desarrollo]");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
            else if (tecla.Key == ConsoleKey.Escape)
            {
                return;
            }
        }
    }
    static void MenuReportes()
    {
        string[] opcionesReportes = { "CLIENTES", "PRODUCTOS", "VENDEDORES", "PROVEEDORES", "BOLETAS" };
        int opcionSeleccionada = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                     MENÚ REPORTES                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Use las flechas ↑ ↓ para navegar, Enter para seleccionar y ESC para volver\n");

            for (int i = 0; i < opcionesReportes.Length; i++)
            {
                if (i == opcionSeleccionada)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  ► {opcionesReportes[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"    {opcionesReportes[i]}");
                }
            }

            ConsoleKeyInfo tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.UpArrow)
            {
                opcionSeleccionada = (opcionSeleccionada - 1 + opcionesReportes.Length) % opcionesReportes.Length;
            }
            else if (tecla.Key == ConsoleKey.DownArrow)
            {
                opcionSeleccionada = (opcionSeleccionada + 1) % opcionesReportes.Length;
            }
            else if (tecla.Key == ConsoleKey.Enter)
            {
                switch (opcionSeleccionada)
                {
                    case 0:
                        ReporteCliente.ReporteClientes();
                        break;
                    case 1:
                        ReporteProducto.ReporteProductos();
                        break;
                    case 2:
                        ReporteVendedor.ReporteVendedores();
                        break;
                    case 3:
                        ReporteProveedor.ReporteProveedores();
                        break;
                    case 4:
                        ReporteBoleta.ReporteBoletas();
                        break;
                }
            }
            else if (tecla.Key == ConsoleKey.Escape)
            {
                return;
            }
        }
    }
}
