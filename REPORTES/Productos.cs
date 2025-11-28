using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPORTES
{
    public class Productos
    {
        // Arreglos para almacenar productos (hasta 50)
        public static string[] codigosProductos = new string[50];
        public static string[] nombresProductos = new string[50];
        public static string[] categoriasProductos = new string[50];
        public static int[] stockProductos = new int[50];
        public static decimal[] preciosProductos = new decimal[50];
        public static int contadorProductos = 0;
        public static void RegistrarProducto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("═══════════════ REGISTRAR PRODUCTO ═══════════════");
            Console.ResetColor();
            Console.WriteLine();

            if (contadorProductos >= 50)
            {
                Console.WriteLine("No se pueden registrar más productos. Límite alcanzado.");
                Console.ReadKey();
                return;
            }

            string codigo;
            while (true)
            {
                Console.Write("Código del producto (8 dígitos): ");
                codigo = Console.ReadLine();

                // Validar que tenga 8 dígitos
                if (codigo.Length != 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El código debe tener exactamente 8 dígitos.");
                    Console.ResetColor();
                    continue;
                }

                // Validar que solo contenga números
                bool soloNumeros = true;
                for (int i = 0; i < codigo.Length; i++)
                {
                    if (codigo[i] < '0' || codigo[i] > '9')
                    {
                        soloNumeros = false;
                        break;
                    }
                }

                if (!soloNumeros)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El código solo debe contener números.");
                    Console.ResetColor();
                    continue;
                }

                // Validar que no exista
                bool codigoExiste = false;
                for (int i = 0; i < contadorProductos; i++)
                {
                    if (codigosProductos[i] == codigo)
                    {
                        codigoExiste = true;
                        break;
                    }
                }

                if (codigoExiste)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El código ya existe. Ingrese uno diferente.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            string nombre;
            while (true)
            {
                Console.Write("Nombre del producto: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre no puede estar vacío.");
                    Console.ResetColor();
                    continue;
                }

                // Validar que solo contenga letras
                bool soloLetras = true;
                for (int i = 0; i < nombre.Length; i++)
                {
                    if (!char.IsLetter(nombre[i]) && nombre[i] != ' ')
                    {
                        soloLetras = false;
                        break;
                    }
                }

                if (!soloLetras)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre solo debe contener letras.");
                    Console.ResetColor();
                    continue;
                }

                // Validar que no exista
                bool nombreExiste = false;
                for (int i = 0; i < contadorProductos; i++)
                {
                    if (nombresProductos[i] == nombre)
                    {
                        nombreExiste = true;
                        break;
                    }
                }

                if (nombreExiste)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre ya existe. Ingrese uno diferente.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            string categoria;
            while (true)
            {
                Console.Write("Categoría: ");
                categoria = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(categoria))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! La categoría no puede estar vacía.");
                    Console.ResetColor();
                    continue;
                }

                // Validar que solo contenga letras
                bool soloLetras = true;
                for (int i = 0; i < categoria.Length; i++)
                {
                    if (!char.IsLetter(categoria[i]) && categoria[i] != ' ')
                    {
                        soloLetras = false;
                        break;
                    }
                }

                if (!soloLetras)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! La categoría solo debe contener letras.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            int stock;
            while (true)
            {
                Console.Write("Stock: ");
                string stockInput = Console.ReadLine();

                if (int.TryParse(stockInput, out stock) && stock >= 0)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! Ingrese un número válido mayor o igual a 0.");
                    Console.ResetColor();
                }
            }

            decimal precio;
            while (true)
            {
                Console.Write("Precio unitario: ");
                string precioInput = Console.ReadLine();

                if (decimal.TryParse(precioInput, out precio) && precio > 0)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! Ingrese un precio válido mayor a 0.");
                    Console.ResetColor();
                }
            }

            codigosProductos[contadorProductos] = codigo;
            nombresProductos[contadorProductos] = nombre;
            categoriasProductos[contadorProductos] = categoria;
            stockProductos[contadorProductos] = stock;
            preciosProductos[contadorProductos] = precio;
            contadorProductos++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✓ Producto registrado exitosamente!");
            Console.ResetColor();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
