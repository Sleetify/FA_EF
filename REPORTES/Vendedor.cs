using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPORTES
{
    public class Vendedor
    {
        // Arreglos para almacenar vendedores (hasta 50)
        public static string[] codigosVendedores = new string[50];
        public static string[] nombresVendedores = new string[50];
        public static string[] apellidosVendedores = new string[50];
        public static decimal[] sueldosVendedores = new decimal[50];
        public static string[] telefonosVendedores = new string[50];
        public static int contadorVendedores = 0;
        public static void RegistrarVendedor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("═══════════════ REGISTRAR VENDEDOR ═══════════════");
            Console.ResetColor();
            Console.WriteLine();

            if (contadorVendedores >= 50)
            {
                Console.WriteLine("No se pueden registrar más vendedores. Límite alcanzado.");
                Console.ReadKey();
                return;
            }

            string codigo;
            while (true)
            {
                Console.Write("Código del vendedor (8 dígitos): ");
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
                for (int i = 0; i < contadorVendedores; i++)
                {
                    if (codigosVendedores[i] == codigo)
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

            string nombres;
            while (true)
            {
                Console.Write("Nombres: ");
                nombres = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombres))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! Los nombres no pueden estar vacíos.");
                    Console.ResetColor();
                    continue;
                }

                bool soloLetras = true;
                for (int i = 0; i < nombres.Length; i++)
                {
                    if (!char.IsLetter(nombres[i]) && nombres[i] != ' ')
                    {
                        soloLetras = false;
                        break;
                    }
                }

                if (!soloLetras)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! Los nombres solo deben contener letras.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            string apellidos;
            while (true)
            {
                Console.Write("Apellidos: ");
                apellidos = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(apellidos))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! Los apellidos no pueden estar vacíos.");
                    Console.ResetColor();
                    continue;
                }

                bool soloLetras = true;
                for (int i = 0; i < apellidos.Length; i++)
                {
                    if (!char.IsLetter(apellidos[i]) && apellidos[i] != ' ')
                    {
                        soloLetras = false;
                        break;
                    }
                }

                if (!soloLetras)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! Los apellidos solo deben contener letras.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            decimal sueldo;
            while (true)
            {
                Console.Write("Sueldo: ");
                string sueldoInput = Console.ReadLine();

                if (decimal.TryParse(sueldoInput, out sueldo) && sueldo > 0)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! Ingrese un sueldo válido mayor a 0.");
                    Console.ResetColor();
                }
            }

            string telefono;
            while (true)
            {
                Console.Write("Teléfono (9 dígitos): ");
                telefono = Console.ReadLine();

                if (telefono.Length != 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El teléfono debe tener exactamente 9 dígitos.");
                    Console.ResetColor();
                    continue;
                }

                bool soloNumeros = true;
                for (int i = 0; i < telefono.Length; i++)
                {
                    if (telefono[i] < '0' || telefono[i] > '9')
                    {
                        soloNumeros = false;
                        break;
                    }
                }

                if (!soloNumeros)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El teléfono solo debe contener números.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            codigosVendedores[contadorVendedores] = codigo;
            nombresVendedores[contadorVendedores] = nombres;
            apellidosVendedores[contadorVendedores] = apellidos;
            sueldosVendedores[contadorVendedores] = sueldo;
            telefonosVendedores[contadorVendedores] = telefono;
            contadorVendedores++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✓ Vendedor registrado exitosamente!");
            Console.ResetColor();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
