using System;
using System.Text.RegularExpressions;

class SistemaVentas
{
    // Arreglos para almacenar boletas (hasta 100)
    static string[] numerosBoleta = new string[100];
    static string[] fechasBoleta = new string[100];
    static string[] dniClientesBoleta = new string[100];
    static string[] nombresClientesBoleta = new string[100];
    static string[,] productosVendidos = new string[100, 10]; // 100 boletas, hasta 10 productos por boleta
    static int[,] cantidadesVendidas = new int[100, 10];
    static decimal[,] preciosVendidos = new decimal[100, 10];
    static int[] cantidadProductosPorBoleta = new int[100];
    static decimal[] subtotalesBoleta = new decimal[100];
    static decimal[] igvBoleta = new decimal[100];
    static decimal[] totalesBoleta = new decimal[100];
    static int contadorBoletas = 0;
    //VENTA ^

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

        //-------------------------------------------------------------------------------------------------------------
        //------------------------------------------------- VENTAS ----------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------
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
                        GenerarBoleta();
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

    static void GenerarBoleta()
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

        if (contadorClientes == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("¡Error! No hay clientes registrados. Debe registrar clientes primero.");
            Console.ResetColor();
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        if (contadorProductos == 0)
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
            for (int i = 0; i < contadorClientes; i++)
            {
                if (dniClientes[i] == dniCliente)
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
        nombresClientesBoleta[contadorBoletas] = nombresClientes[indiceCliente] + " " + apellidosClientes[indiceCliente];

        Console.WriteLine($"\nCliente: {nombresClientesBoleta[contadorBoletas]}");
        Console.WriteLine($"Dirección: {direccionesClientes[indiceCliente]}");
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
                for (int i = 0; i < contadorProductos; i++)
                {
                    if (codigosProductos[i] == codigoProducto)
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

            Console.WriteLine($"Producto: {nombresProductos[indiceProducto]}");
            Console.WriteLine($"Precio unitario: S/ {preciosProductos[indiceProducto]:F2}");
            Console.WriteLine($"Stock disponible: {stockProductos[indiceProducto]}");

            // Solicitar cantidad
            int cantidad;
            while (true)
            {
                Console.Write("Cantidad: ");
                string cantidadInput = Console.ReadLine();

                if (int.TryParse(cantidadInput, out cantidad) && cantidad > 0)
                {
                    if (cantidad <= stockProductos[indiceProducto])
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"¡Error! Stock insuficiente. Disponible: {stockProductos[indiceProducto]}");
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
            productosVendidos[contadorBoletas, cantidadProductosEnBoleta] = nombresProductos[indiceProducto];
            cantidadesVendidas[contadorBoletas, cantidadProductosEnBoleta] = cantidad;
            preciosVendidos[contadorBoletas, cantidadProductosEnBoleta] = preciosProductos[indiceProducto];

            // Actualizar stock
            stockProductos[indiceProducto] -= cantidad;

            decimal totalProducto = cantidad * preciosProductos[indiceProducto];
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

    static void MostrarBoleta(int indiceBoleta)
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
                        ReporteClientes();
                        break;
                    case 1:
                        ReporteProductos();
                        break;
                    case 2:
                        ReporteVendedores();
                        break;
                    case 3:
                        ReporteProveedores();
                        break;
                    case 4:
                        ReporteBoletas();
                        break;
                }
            }
            else if (tecla.Key == ConsoleKey.Escape)
            {
                return;
            }
        }
    }

    static void ReporteClientes()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                    REPORTE DE CLIENTES                                         ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        if (contadorClientes == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No hay clientes registrados.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Total de clientes registrados: {contadorClientes}\n");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("{0,-10} {1,-25} {2,-25} {3,-12} {4,-30}", "DNI", "NOMBRES", "APELLIDOS", "TELÉFONO", "EMAIL");
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");

            for (int i = 0; i < contadorClientes; i++)
            {
                Console.WriteLine("{0,-10} {1,-25} {2,-25} {3,-12} {4,-30}",
                    dniClientes[i],
                    nombresClientes[i],
                    apellidosClientes[i],
                    telefonosClientes[i],
                    emailsClientes[i]);
                Console.WriteLine($"           Dirección: {direccionesClientes[i]}");
                Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");
            }
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ReporteProductos()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                   REPORTE DE PRODUCTOS                                         ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        if (contadorProductos == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No hay productos registrados.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Total de productos registrados: {contadorProductos}\n");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("{0,-12} {1,-30} {2,-20} {3,-10} {4,-12}", "CÓDIGO", "NOMBRE", "CATEGORÍA", "STOCK", "PRECIO");
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════");

            for (int i = 0; i < contadorProductos; i++)
            {
                Console.WriteLine("{0,-12} {1,-30} {2,-20} {3,-10} S/ {4,-10:F2}",
                    codigosProductos[i],
                    nombresProductos[i],
                    categoriasProductos[i],
                    stockProductos[i],
                    preciosProductos[i]);
            }
            Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ReporteVendedores()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                  REPORTE DE VENDEDORES                                         ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        if (contadorVendedores == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No hay vendedores registrados.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Total de vendedores registrados: {contadorVendedores}\n");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════");
            Console.WriteLine("{0,-12} {1,-25} {2,-25} {3,-12} {4,-12}", "CÓDIGO", "NOMBRES", "APELLIDOS", "TELÉFONO", "SUELDO");
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════");

            decimal totalSueldos = 0;
            for (int i = 0; i < contadorVendedores; i++)
            {
                Console.WriteLine("{0,-12} {1,-25} {2,-25} {3,-12} S/ {4,-10:F2}",
                    codigosVendedores[i],
                    nombresVendedores[i],
                    apellidosVendedores[i],
                    telefonosVendedores[i],
                    sueldosVendedores[i]);
                totalSueldos += sueldosVendedores[i];
            }
            Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"",78}Total en sueldos: S/ {totalSueldos:F2}");
            Console.ResetColor();
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ReporteProveedores()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                  REPORTE DE PROVEEDORES                                        ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        if (contadorProveedores == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No hay proveedores registrados.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Total de proveedores registrados: {contadorProveedores}\n");

            for (int i = 0; i < contadorProveedores; i++)
            {
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"PROVEEDOR #{i + 1}");
                Console.ResetColor();
                Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine($"Código:        {codigosProveedores[i]}");
                Console.WriteLine($"Empresa:       {empresasProveedores[i]}");
                Console.WriteLine($"RUC:           {rucProveedores[i]}");
                Console.WriteLine($"Representante: {representantesProveedores[i]}");
                Console.WriteLine($"Teléfono:      {telefonosProveedores[i]}");
                Console.WriteLine($"Dirección:     {direccionesProveedores[i]}");
                Console.WriteLine($"Ciudad:        {ciudadesProveedores[i]}");
            }
            Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void ReporteBoletas()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                    REPORTE DE BOLETAS                                          ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();

        if (contadorBoletas == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No hay boletas registradas.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine($"Total de boletas emitidas: {contadorBoletas}\n");

            decimal totalVentas = 0;
            for (int i = 0; i < contadorBoletas; i++)
            {
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"BOLETA: {numerosBoleta[i]}");
                Console.ResetColor();
                Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine($"Fecha:    {fechasBoleta[i]}");
                Console.WriteLine($"Cliente:  {nombresClientesBoleta[i]}");
                Console.WriteLine($"DNI:      {dniClientesBoleta[i]}");
                Console.WriteLine();
                Console.WriteLine("{0,-30} {1,-10} {2,-15} {3,-15}", "PRODUCTO", "CANT.", "P.UNITARIO", "SUBTOTAL");
                Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");

                for (int j = 0; j < cantidadProductosPorBoleta[i]; j++)
                {
                    decimal subtotalLinea = cantidadesVendidas[i, j] * preciosVendidos[i, j];
                    Console.WriteLine("{0,-30} {1,-10} S/ {2,-13:F2} S/ {3,-13:F2}",
                        productosVendidos[i, j],
                        cantidadesVendidas[i, j],
                        preciosVendidos[i, j],
                        subtotalLinea);
                }

                Console.WriteLine("───────────────────────────────────────────────────────────────────────────────────────────────────");
                Console.WriteLine($"{"",55}Subtotal:  S/ {subtotalesBoleta[i],10:F2}");
                Console.WriteLine($"{"",55}IGV (18%): S/ {igvBoleta[i],10:F2}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{"",55}TOTAL:     S/ {totalesBoleta[i],10:F2}");
                Console.ResetColor();
                Console.WriteLine();

                totalVentas += totalesBoleta[i];
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