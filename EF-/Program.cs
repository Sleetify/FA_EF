using System;

class SistemaVentas
{
    // Arreglos para almacenar productos (hasta 50)
    static string[] codigosProductos = new string[50];
    static string[] nombresProductos = new string[50];
    static string[] categoriasProductos = new string[50];
    static int[] stockProductos = new int[50];
    static decimal[] preciosProductos = new decimal[50];
    static int contadorProductos = 0;

    // Arreglos para almacenar clientes (hasta 50)
    static string[] dniClientes = new string[50];
    static string[] nombresClientes = new string[50];
    static string[] apellidosClientes = new string[50];
    static string[] telefonosClientes = new string[50];
    static string[] emailsClientes = new string[50];
    static string[] direccionesClientes = new string[50];
    static int contadorClientes = 0;

    // Arreglos para almacenar vendedores (hasta 50)
    static string[] codigosVendedores = new string[50];
    static string[] nombresVendedores = new string[50];
    static string[] apellidosVendedores = new string[50];
    static decimal[] sueldosVendedores = new decimal[50];
    static string[] telefonosVendedores = new string[50];
    static int contadorVendedores = 0;

    // Arreglos para almacenar proveedores (hasta 50)
    static string[] codigosProveedores = new string[50];
    static string[] empresasProveedores = new string[50];
    static string[] rucProveedores = new string[50];
    static string[] representantesProveedores = new string[50];
    static string[] telefonosProveedores = new string[50];
    static string[] direccionesProveedores = new string[50];
    static string[] ciudadesProveedores = new string[50];
    static int contadorProveedores = 0;

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
                        RegistrarProducto();
                        break;
                    case 1:
                        RegistrarCliente();
                        break;
                    case 2:
                        RegistrarVendedor();
                        break;
                    case 3:
                        RegistrarProveedor();
                        break;
                }
            }
            else if (tecla.Key == ConsoleKey.Escape)
            {
                return; // Volver al menú principal
            }
        }
    }

    static void RegistrarProducto()
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
            Console.Write("Código del producto: ");
            codigo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Error! El código no puede estar vacío.");
                Console.ResetColor();
                continue;
            }

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

        Console.Write("Categoría: ");
        string categoria = Console.ReadLine();

        Console.Write("Stock: ");
        int stock = int.Parse(Console.ReadLine());

        Console.Write("Precio unitario: ");
        decimal precio = decimal.Parse(Console.ReadLine());

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

    static void RegistrarCliente()
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

        Console.Write("Email: ");
        string email = Console.ReadLine();

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

    static void RegistrarVendedor()
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
            Console.Write("Código del vendedor: ");
            codigo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Error! El código no puede estar vacío.");
                Console.ResetColor();
                continue;
            }

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

        Console.Write("Sueldo: ");
        decimal sueldo = decimal.Parse(Console.ReadLine());

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

    static void RegistrarProveedor()
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
            Console.Write("Código del proveedor: ");
            codigo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡Error! El código no puede estar vacío.");
                Console.ResetColor();
                continue;
            }

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

        Console.Write("Empresa proveedora: ");
        string empresa = Console.ReadLine();

        Console.Write("Número de RUC: ");
        string ruc = Console.ReadLine();

        Console.Write("Representante: ");
        string representante = Console.ReadLine();

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

        Console.Write("Ciudad: ");
        string ciudad = Console.ReadLine();

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