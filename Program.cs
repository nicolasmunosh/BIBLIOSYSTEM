using System;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
    }

static void ShowMainMenu()
{
    int option;

    do
    {
        Console.Clear();

        Console.WriteLine("===== SISTEMA BIBLIOTECA =====");
        Console.WriteLine("1. Libros");
        Console.WriteLine("2. Usuarios");
        Console.WriteLine("3. Préstamos");
        Console.WriteLine("4. Búsquedas y reportes");
        Console.WriteLine("5. Guardar / Cargar datos");
        Console.WriteLine("6. Salir");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch(option)
        {
            case 1:
                ShowBooksMenu();
                break;

            case 2:
                ShowUsersMenu();
                break;

            case 3:
                ShowLoansMenu();
                break;

            case 4:
                ShowSearchReportsMenu();
                break;

            case 5:
                ShowPersistenceMenu();
                break;

            case 6:
                ConfirmExitAndSave();
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }

    } while (option != 6);
}

static void ShowBooksMenu()
{
    int option;

    do
    {
        Console.Clear();

        Console.WriteLine("===== MENÚ LIBROS =====");
        Console.WriteLine("1. Registrar libro");
        Console.WriteLine("2. Listar libros");
        Console.WriteLine("3. Ver detalle del libro");
        Console.WriteLine("4. Actualizar libro");
        Console.WriteLine("5. Eliminar libro");
        Console.WriteLine("0. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch(option)
        {
            case 1:
                RegisterBook();
                break;

            case 2:
                ListBooksMenu();
                break;

            case 3:
                ViewBookDetail();
                break;

            case 4:
                UpdateBookMenu();
                break;

            case 5:
                DeleteBook();
                break;
        }

    } while(option != 0);
}static void RegisterBook()
    {
    Console.Clear();
    Console.WriteLine("===== REGISTRAR LIBRO =====");
    Console.WriteLine("Función para registrar un nuevo libro.");
    Console.ReadKey();
    }

static void ListBooksMenu()
{
    int option;

    do
    {
        Console.Clear();

        Console.WriteLine("===== LISTAR LIBROS =====");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.WriteLine("0. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch(option)
        {
            case 1:
                ListBooksAll();
                break;

            case 2:
                ListBooksAvailable();
                break;

            case 3:
                ListBooksBorrowed();
                break;
        }

    } while(option != 0);
}
static void ListBooksAll()
{
    Console.WriteLine("Mostrando todos los libros...");
    Console.ReadKey();
}

static void ListBooksAvailable()
{
    Console.WriteLine("Mostrando libros disponibles...");
    Console.ReadKey();
}

static void ListBooksBorrowed()
{
    Console.WriteLine("Mostrando libros prestados...");
    Console.ReadKey();
}

static void ViewBookDetail()
    {
    Console.Clear();
    Console.WriteLine("===== DETALLE DEL LIBRO =====");
    Console.WriteLine("Mostrando información del libro por ID o ISBN.");
    Console.ReadKey();
    }

static void UpdateBookMenu()
    {
  int option;
    
    do
    {
        Console.Clear();
        Console.WriteLine("===== ACTUALIZAR LIBRO =====");
        Console.WriteLine("1. Editar título");
        Console.WriteLine("2. Editar autor");
        Console.WriteLine("3. Editar año / categoría");
        Console.WriteLine("0. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch(option)
        {
            case 1:
                EditBookTitle();
                break;

            case 2:
                EditBookAuthor();
                break;

            case 3:
                EditBookYearCategory();
                break;
        }

    } while(option != 0);
    }
static void EditBookTitle()
{
    Console.WriteLine("Editar título del libro...");
    Console.ReadKey();
}

static void EditBookAuthor()
{
    Console.WriteLine("Editar autor del libro...");
    Console.ReadKey();
}

static void EditBookYearCategory()
{
    Console.WriteLine("Editar año o categoría del libro...");
    Console.ReadKey();
}

static void DeleteBook()
    {
    Console.Clear();
    Console.WriteLine("Eliminar libro seleccionado.");
    Console.WriteLine("Validar no permitir si el libro está prestado.");
    Console.ReadKey();
    }

static void ShowUsersMenu()
{
        int option;

    do
    {
        Console.Clear();

        Console.WriteLine("===== MENÚ USUARIOS =====");
        Console.WriteLine("1. Registrar usuario");
        Console.WriteLine("2. Listar usuarios");
        Console.WriteLine("3. Ver detalle del usuario");
        Console.WriteLine("4. Actualizar usuario");
        Console.WriteLine("5. Eliminar usuario");
        Console.WriteLine("0. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch(option)
        {
            case 1:
                RegisterUser();
                break;

            case 2:
                ListUsers();
                break;

            case 3:
                ViewUserDetail();
                break;

            case 4:
                UpdateUserMenu();
                break;

            case 5:
                DeleteUser();
                break;
        }

    } while(option != 0);
}
static void RegisterUser()
    {
    Console.Clear();
    Console.WriteLine("===== REGISTRAR USUARIO =====");
    Console.WriteLine("Función para registrar un nuevo usuario.");
    Console.ReadKey();
    }
static void ListUsers()
    {
    Console.Clear();
    Console.WriteLine("===== LISTAR USUARIOS =====");
    Console.WriteLine("Mostrando todos los usuarios registrados.");
    Console.ReadKey();
    }
static void ViewUserDetail()
    {
    Console.Clear();
    Console.WriteLine("===== DETALLE DEL USUARIO =====");
    Console.WriteLine("Mostrando información del usuario por ID o documento.");
    Console.ReadKey();
    }
static void UpdateUserMenu() {}
static void DeleteUser() {}

static void ShowLoansMenu()
{
    Console.Clear();
    Console.WriteLine("Entrando al módulo de Préstamos...");
    Console.ReadKey();
}

static void ShowSearchReportsMenu()
{
    Console.Clear();
    Console.WriteLine("Entrando a Búsquedas y Reportes...");
    Console.ReadKey();
}

static void ShowPersistenceMenu()
{
    Console.Clear();
    Console.WriteLine("Entrando a Guardar / Cargar datos...");
    Console.ReadKey();
}
    static void ConfirmExitAndSave()
{
    Console.Clear();
    Console.WriteLine("¿Desea guardar antes de salir? (S/N)");

    string response = Console.ReadLine() ?? "";

    if(response.ToUpper() == "S")
    {
        Console.WriteLine("Guardando datos...");
    }

    Console.WriteLine("Saliendo del sistema...");
    Console.ReadKey();
}
}