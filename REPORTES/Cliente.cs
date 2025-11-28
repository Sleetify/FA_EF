using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REPORTES
{
    public class Cliente
    {
        // Arreglos para almacenar clientes (hasta 50)
        public static string[] dniClientes = new string[50];
        public static string[] nombresClientes = new string[50];
        public static string[] apellidosClientes = new string[50];
        public static string[] telefonosClientes = new string[50];
        public static string[] emailsClientes = new string[50];
        public static string[] direccionesClientes = new string[50];
        public static int contadorClientes = 0;
        public static void RegistrarCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("═══════════════ REGISTRAR CLIENTE ═══════════════");
            Console.ResetColor();
            Console.WriteLine();

            if (contadorClientes >= 50)
            {
                Console.WriteLine("No se pueden registrar más clientes. Límite alcanzado.");
                Console.ReadKey();
                return;
            }

            string dni;
            while (true)
            {
                Console.Write("DNI del cliente (8 dígitos): ");
                dni = Console.ReadLine();

                // Validar que tenga 8 dígitos y solo números
                if (dni.Length != 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El DNI debe tener exactamente 8 dígitos.");
                    Console.ResetColor();
                    continue;
                }

                bool soloNumeros = true;
                for (int i = 0; i < dni.Length; i++)
                {
                    if (dni[i] < '0' || dni[i] > '9')
                    {
                        soloNumeros = false;
                        break;
                    }
                }

                if (!soloNumeros)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El DNI solo debe contener números.");
                    Console.ResetColor();
                    continue;
                }

                bool dniExiste = false;
                for (int i = 0; i < contadorClientes; i++)
                {
                    if (dniClientes[i] == dni)
                    {
                        dniExiste = true;
                        break;
                    }
                }

                if (dniExiste)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El DNI ya existe. Ingrese uno diferente.");
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

            string email;
            while (true)
            {
                Console.Write("Email: ");
                email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El email no puede estar vacío.");
                    Console.ResetColor();
                    continue;
                }

                // Validar formato de email usando Regex
                string patronEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                if (!Regex.IsMatch(email, patronEmail))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El formato del email no es válido.");
                    Console.WriteLine("Ejemplo de formato correcto: usuario@ejemplo.com");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            dniClientes[contadorClientes] = dni;
            nombresClientes[contadorClientes] = nombres;
            apellidosClientes[contadorClientes] = apellidos;
            telefonosClientes[contadorClientes] = telefono;
            emailsClientes[contadorClientes] = email;
            direccionesClientes[contadorClientes] = direccion;
            contadorClientes++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✓ Cliente registrado exitosamente!");
            Console.ResetColor();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
