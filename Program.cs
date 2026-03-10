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
    Console.Clear();
    Console.WriteLine("Entrando al módulo de Libros...");
    Console.ReadKey();
}

static void ShowUsersMenu()
{
    Console.Clear();
    Console.WriteLine("Entrando al módulo de Usuarios...");
    Console.ReadKey();
}

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
    static void ConfirmExitAndSave() {}
}