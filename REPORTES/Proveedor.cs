using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPORTES
{
    public class Proveedor
    {
        // Arreglos para almacenar proveedores (hasta 50)
        public static string[] codigosProveedores = new string[50];
        public static string[] empresasProveedores = new string[50];
        public static string[] rucProveedores = new string[50];
        public static string[] representantesProveedores = new string[50];
        public static string[] telefonosProveedores = new string[50];
        public static string[] direccionesProveedores = new string[50];
        public static string[] ciudadesProveedores = new string[50];
        public static int contadorProveedores = 0;
        public static void RegistrarProveedor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("═══════════════ REGISTRAR PROVEEDOR ═══════════════");
            Console.ResetColor();
            Console.WriteLine();

            if (contadorProveedores >= 50)
            {
                Console.WriteLine("No se pueden registrar más proveedores. Límite alcanzado.");
                Console.ReadKey();
                return;
            }

            string codigo;
            while (true)
            {
                Console.Write("Código del proveedor (8 dígitos): ");
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
                for (int i = 0; i < contadorProveedores; i++)
                {
                    if (codigosProveedores[i] == codigo)
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

            string empresa;
            while (true)
            {
                Console.Write("Empresa proveedora: ");
                empresa = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(empresa))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre de la empresa no puede estar vacío.");
                    Console.ResetColor();
                    continue;
                }

                bool soloLetras = true;
                for (int i = 0; i < empresa.Length; i++)
                {
                    if (!char.IsLetter(empresa[i]) && empresa[i] != ' ')
                    {
                        soloLetras = false;
                        break;
                    }
                }

                if (!soloLetras)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre de la empresa solo debe contener letras.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            string ruc;
            while (true)
            {
                Console.Write("Número de RUC (11 dígitos): ");
                ruc = Console.ReadLine();

                // Validar que tenga 11 dígitos
                if (ruc.Length != 11)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El RUC debe tener exactamente 11 dígitos.");
                    Console.ResetColor();
                    continue;
                }

                // Validar que solo contenga números
                bool soloNumeros = true;
                for (int i = 0; i < ruc.Length; i++)
                {
                    if (ruc[i] < '0' || ruc[i] > '9')
                    {
                        soloNumeros = false;
                        break;
                    }
                }

                if (!soloNumeros)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El RUC solo debe contener números.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            string representante;
            while (true)
            {
                Console.Write("Representante: ");
                representante = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(representante))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre del representante no puede estar vacío.");
                    Console.ResetColor();
                    continue;
                }

                bool soloLetras = true;
                for (int i = 0; i < representante.Length; i++)
                {
                    if (!char.IsLetter(representante[i]) && representante[i] != ' ')
                    {
                        soloLetras = false;
                        break;
                    }
                }

                if (!soloLetras)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre del representante solo debe contener letras.");
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

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            string ciudad;
            while (true)
            {
                Console.Write("Ciudad: ");
                ciudad = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(ciudad))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre de la ciudad no puede estar vacío.");
                    Console.ResetColor();
                    continue;
                }

                bool soloLetras = true;
                for (int i = 0; i < ciudad.Length; i++)
                {
                    if (!char.IsLetter(ciudad[i]) && ciudad[i] != ' ')
                    {
                        soloLetras = false;
                        break;
                    }
                }

                if (!soloLetras)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Error! El nombre de la ciudad solo debe contener letras.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            codigosProveedores[contadorProveedores] = codigo;
            empresasProveedores[contadorProveedores] = empresa;
            rucProveedores[contadorProveedores] = ruc;
            representantesProveedores[contadorProveedores] = representante;
            telefonosProveedores[contadorProveedores] = telefono;
            direccionesProveedores[contadorProveedores] = direccion;
            ciudadesProveedores[contadorProveedores] = ciudad;
            contadorProveedores++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✓ Proveedor registrado exitosamente!");
            Console.ResetColor();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
