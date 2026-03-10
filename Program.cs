using System;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
    }

    static void ShowMainMenu()
    {
        Console.WriteLine("===== SISTEMA BIBLIOTECA =====");
        Console.WriteLine("1. Libros");
        Console.WriteLine("2. Usuarios");
        Console.WriteLine("3. Préstamos");
        Console.WriteLine("4. Búsquedas y reportes");
        Console.WriteLine("5. Guardar / Cargar datos");
        Console.WriteLine("6. Salir");
    }

    static void ShowBooksMenu() {}
    static void ShowUsersMenu() {}
    static void ShowLoansMenu() {}
    static void ShowSearchReportsMenu() {}
    static void ShowPersistenceMenu() {}
    static void ConfirmExitAndSave() {}
}