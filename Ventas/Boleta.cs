using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPORTES;

namespace Ventas
{
    public class Boleta
    {

    // Arreglos para almacenar boletas (hasta 100)
    public static string[] numerosBoleta = new string[100];
    public static string[] fechasBoleta = new string[100];
    public static string[] dniClientesBoleta = new string[100];
    public static string[] nombresClientesBoleta = new string[100];
    public static string[,] productosVendidos = new string[100, 10]; // 100 boletas, hasta 10 productos por boleta
    public static int[,] cantidadesVendidas = new int[100, 10];
    public static decimal[,] preciosVendidos = new decimal[100, 10];
    public static int[] cantidadProductosPorBoleta = new int[100];
    public static decimal[] subtotalesBoleta = new decimal[100];
    public static decimal[] igvBoleta = new decimal[100];
    public static decimal[] totalesBoleta = new decimal[100];
    public static int contadorBoletas = 0;
    
        public static void GenerarBoleta()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    GENERAR BOLETA                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            if (contadorBoletas >= 100)
            {
                Console.WriteLine("No se pueden registrar más boletas. Límite alcanzado.");
                Console.ReadKey();
                return;
            }

            if (Cliente.contadorClientes == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Error! No hay clientes registrados. Debe registrar clientes primero.");
                Console.ResetColor();
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            if (Productos.contadorProductos == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Error! No hay productos registrados. Debe registrar productos primero.");
                Console.ResetColor();
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // Generar número de boleta automático
            string numeroBoleta = "B001-" + (contadorBoletas + 1).ToString("D4");
            numerosBoleta[contadorBoletas] = numeroBoleta;

            // Obtener fecha actual
            DateTime fechaActual = DateTime.Now;
            fechasBoleta[contadorBoletas] = fechaActual.ToString("dd/MM/yyyy");

            // Buscar cliente por DNI
            string dniCliente;
            int indiceCliente = -1;
            while (true)
            {
                Console.Write("Ingrese DNI del cliente (8 dígitos): ");
                dniCliente = Console.ReadLine();

                if (dniCliente.Length != 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El DNI debe tener exactamente 8 dígitos.");
                    Console.ResetColor();
                    continue;
                }

                // Buscar cliente
                for (int i = 0; i < Cliente.contadorClientes; i++)
                {
                    if (Cliente.dniClientes[i] == dniCliente)
                    {
                        indiceCliente = i;
                        break;
                    }
                }

                if (indiceCliente == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! Cliente no encontrado. Verifique el DNI.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            dniClientesBoleta[contadorBoletas] = dniCliente;
            nombresClientesBoleta[contadorBoletas] = Cliente.nombresClientes[indiceCliente] + " " + Cliente.apellidosClientes[indiceCliente];

            Console.WriteLine($"\nCliente: {nombresClientesBoleta[contadorBoletas]}");
            Console.WriteLine($"Dirección: {Cliente.direccionesClientes[indiceCliente]}");
            Console.WriteLine();

            // Agregar productos
            int cantidadProductosEnBoleta = 0;
            decimal subtotal = 0;
            bool continuarAgregando = true;

            while (continuarAgregando && cantidadProductosEnBoleta < 10)
            {
                Console.WriteLine($"\n--- Producto {cantidadProductosEnBoleta + 1} ---");

                string codigoProducto;
                int indiceProducto = -1;

                while (true)
                {
                    Console.Write("Código del producto (o 'fin' para terminar): ");
                    codigoProducto = Console.ReadLine();

                    if (codigoProducto.ToLower() == "fin")
                    {
                        if (cantidadProductosEnBoleta == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("¡Error! Debe agregar al menos un producto.");
                            Console.ResetColor();
                            continue;
                        }
                        continuarAgregando = false;
                        break;
                    }

                    // Buscar producto
                    for (int i = 0; i < Productos.contadorProductos; i++)
                    {
                        if (Productos.codigosProductos[i] == codigoProducto)
                        {
                            indiceProducto = i;
                            break;
                        }
                    }

                    if (indiceProducto == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("¡Error! Producto no encontrado.");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }

                if (!continuarAgregando)
                    break;

                Console.WriteLine($"Producto: {Productos.nombresProductos[indiceProducto]}");
                Console.WriteLine($"Precio unitario: S/ {Productos.preciosProductos[indiceProducto]:F2}");
                Console.WriteLine($"Stock disponible: {Productos.stockProductos[indiceProducto]}");

                // Solicitar cantidad
                int cantidad;
                while (true)
                {
                    Console.Write("Cantidad: ");
                    string cantidadInput = Console.ReadLine();

                    if (int.TryParse(cantidadInput, out cantidad) && cantidad > 0)
                    {
                        if (cantidad <= Productos.stockProductos[indiceProducto])
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"¡Error! Stock insuficiente. Disponible: {Productos.stockProductos[indiceProducto]}");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("¡Error! Ingrese una cantidad válida mayor a 0.");
                        Console.ResetColor();
                    }
                }

                // Guardar producto en la boleta
                productosVendidos[contadorBoletas, cantidadProductosEnBoleta] = Productos.nombresProductos[indiceProducto];
                cantidadesVendidas[contadorBoletas, cantidadProductosEnBoleta] = cantidad;
                preciosVendidos[contadorBoletas, cantidadProductosEnBoleta] = Productos.preciosProductos[indiceProducto];

                // Actualizar stock
                Productos.stockProductos[indiceProducto] -= cantidad;

                decimal totalProducto = cantidad * Productos.preciosProductos[indiceProducto];
                subtotal += totalProducto;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Total por este producto: S/ {totalProducto:F2}");
                Console.ResetColor();

                cantidadProductosEnBoleta++;

                if (cantidadProductosEnBoleta < 10)
                {
                    Console.Write("\n¿Desea agregar otro producto? (S/N): ");
                    string respuesta = Console.ReadLine();
                    if (respuesta.ToUpper() != "S")
                    {
                        continuarAgregando = false;
                    }
                }
            }

            cantidadProductosPorBoleta[contadorBoletas] = cantidadProductosEnBoleta;
            subtotalesBoleta[contadorBoletas] = subtotal;
            igvBoleta[contadorBoletas] = subtotal * 0.18m;
            totalesBoleta[contadorBoletas] = subtotal + igvBoleta[contadorBoletas];

            // Mostrar boleta
            MostrarBoleta(contadorBoletas);

            contadorBoletas++;

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
        public static void MostrarBoleta(int indiceBoleta)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                         BOLETA                             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"Número de Boleta: {numerosBoleta[indiceBoleta]}");
            Console.WriteLine($"Fecha: {fechasBoleta[indiceBoleta]}");
            Console.WriteLine($"Cliente: {nombresClientesBoleta[indiceBoleta]}");
            Console.WriteLine($"DNI: {dniClientesBoleta[indiceBoleta]}");
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine("{0,-25} {1,-10} {2,-12} {3,-12}", "PRODUCTO", "CANT.", "P.UNIT.", "TOTAL");
            Console.WriteLine("═══════════════════════════════════════════════════════════════");

            for (int i = 0; i < cantidadProductosPorBoleta[indiceBoleta]; i++)
            {
                decimal totalLinea = cantidadesVendidas[indiceBoleta, i] * preciosVendidos[indiceBoleta, i];
                Console.WriteLine("{0,-25} {1,-10} S/ {2,-10:F2} S/ {3,-10:F2}",
                    productosVendidos[indiceBoleta, i],
                    cantidadesVendidas[indiceBoleta, i],
                    preciosVendidos[indiceBoleta, i],
                    totalLinea);
            }

            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine($"{"",48}Subtotal: S/ {subtotalesBoleta[indiceBoleta],10:F2}");
            Console.WriteLine($"{"",48}IGV (18%): S/ {igvBoleta[indiceBoleta],10:F2}");
            Console.WriteLine("───────────────────────────────────────────────────────────────");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"",48}TOTAL:    S/ {totalesBoleta[indiceBoleta],10:F2}");
            Console.ResetColor();
            Console.WriteLine("═══════════════════════════════════════════════════════════════");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✓ Boleta generada exitosamente!");
            Console.ResetColor();
        }
    }
}
