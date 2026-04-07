using System;
using BiblioSystem.Models;
using BiblioSystem.Services;
using System.Linq;

class Program
{
    // ── Datos en memoria compartidos por todos los menús ──────────────────────
    static LibroService    libroService    = new LibroService();
    static UsuarioService  usuarioService  = new UsuarioService();
    static PrestamoService prestamoService = new PrestamoService();

    // ── Contador de IDs ───────────────────────────────────────────────────────
    static int nextLibroId    = 1;
    static int nextUsuarioId  = 1;
    static int nextPrestamoId = 1;

    static void Main(string[] args)
    {
<<<<<<< HEAD
=======
        LoadData();
>>>>>>> develop
        ShowMainMenu();
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  MENÚ PRINCIPAL
    // ═══════════════════════════════════════════════════════════════════════════
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
            Console.WriteLine("6. Prueba Services");
            Console.WriteLine("7. Comparar Array vs List");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ShowBooksMenu();          break;
                case 2: ShowUsersMenu();           break;
                case 3: ShowLoansMenu();           break;
                case 4: ShowSearchReportsMenu();   break;
                case 5: ShowPersistenceMenu();     break;
                case 6: TestServices();            break;
                case 7: CompararArrayVsList();     break;
                case 8: ConfirmExitAndSave();      break;
                default:
                    Console.WriteLine("Opción inválida");
                    Console.ReadKey();
                    break;
            }
        } while (option != 8);
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  MENÚ LIBROS
    // ═══════════════════════════════════════════════════════════════════════════
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

            switch (option)
            {
                case 1: RegisterBook();      break;
                case 2: ListBooksMenu();     break;
                case 3: ViewBookDetail();    break;
                case 4: UpdateBookMenu();    break;
                case 5: DeleteBook();        break;
            }
        } while (option != 0);
    }

    static void RegisterBook()
    {
        Console.Clear();
        Console.WriteLine("===== REGISTRAR LIBRO =====");

        Console.Write("Ingrese el título: ");
        string titulo = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(titulo))
        {
            Console.WriteLine("El título no puede estar vacío.");
            Console.ReadKey(); return;
        }

        Console.Write("Ingrese el autor: ");
        string autor = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(autor))
        {
            Console.WriteLine("El autor no puede estar vacío.");
            Console.ReadKey(); return;
        }

        var libro = new Libro(nextLibroId++, titulo, autor, true);
        libroService.AgregarLibro(libro);

        Console.WriteLine($"\n✔ Libro registrado correctamente.");
        Console.WriteLine(libro.DetalleCompleto());
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

            switch (option)
            {
                case 1: ListBooksAll();       break;
                case 2: ListBooksAvailable(); break;
                case 3: ListBooksBorrowed();  break;
            }
        } while (option != 0);
    }

    static void ListBooksAll()
    {
        Console.Clear();
        Console.WriteLine("===== LISTA DE LIBROS =====");
        var libros = libroService.ObtenerTodos();
        if (libros.Count == 0) { Console.WriteLine("No hay libros registrados."); }
        else foreach (var l in libros) { Console.WriteLine(l.DetalleCompleto()); Console.WriteLine("---------------------------"); }
        Console.ReadKey();
    }

    static void ListBooksAvailable()
    {
        Console.Clear();
        Console.WriteLine("===== LIBROS DISPONIBLES =====");
        var libros = libroService.ObtenerTodos().Where(l => l.Disponible).ToList();
        if (libros.Count == 0) { Console.WriteLine("No hay libros disponibles."); }
        else foreach (var l in libros) { Console.WriteLine(l.DetalleCompleto()); Console.WriteLine("---------------------------"); }
        Console.ReadKey();
    }

    static void ListBooksBorrowed()
    {
        Console.Clear();
        Console.WriteLine("===== LIBROS PRESTADOS =====");
        var libros = libroService.ObtenerTodos().Where(l => !l.Disponible).ToList();
        if (libros.Count == 0) { Console.WriteLine("No hay libros prestados."); }
        else foreach (var l in libros) { Console.WriteLine(l.DetalleCompleto()); Console.WriteLine("---------------------------"); }
        Console.ReadKey();
    }

    static void ViewBookDetail()
    {
        Console.Clear();
        Console.WriteLine("===== DETALLE DEL LIBRO =====");
        Console.Write("Ingrese el ID del libro: ");
        int.TryParse(Console.ReadLine(), out int id);
        var libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == id);
        if (libro == null) Console.WriteLine("Libro no encontrado.");
        else Console.WriteLine(libro.DetalleCompleto());
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
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1: EditBookTitle();  break;
                case 2: EditBookAuthor(); break;
            }
        } while (option != 0);
    }

    static void EditBookTitle()
    {
        Console.Clear();
        Console.WriteLine("===== EDITAR TÍTULO =====");
        Console.Write("Ingrese el ID del libro: ");
        int.TryParse(Console.ReadLine(), out int id);
        var libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == id);
        if (libro == null) { Console.WriteLine("Libro no encontrado."); Console.ReadKey(); return; }
        Console.Write("Nuevo título: ");
        string nuevoTitulo = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(nuevoTitulo))
        {
            libro.Titulo = nuevoTitulo;
            Console.WriteLine("✔ Título actualizado.");
        }
        else Console.WriteLine("El título no puede estar vacío.");
        Console.ReadKey();
    }

    static void EditBookAuthor()
    {
        Console.Clear();
        Console.WriteLine("===== EDITAR AUTOR =====");
        Console.Write("Ingrese el ID del libro: ");
        int.TryParse(Console.ReadLine(), out int id);
        var libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == id);
        if (libro == null) { Console.WriteLine("Libro no encontrado."); Console.ReadKey(); return; }
        Console.Write("Nuevo autor: ");
        string nuevoAutor = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(nuevoAutor))
        {
            libro.Autor = nuevoAutor;
            Console.WriteLine("✔ Autor actualizado.");
        }
        else Console.WriteLine("El autor no puede estar vacío.");
        Console.ReadKey();
    }

    static void DeleteBook()
    {
        Console.Clear();
        Console.WriteLine("===== ELIMINAR LIBRO =====");
        var libros = libroService.ObtenerTodos();
        if (libros.Count == 0) { Console.WriteLine("No hay libros para eliminar."); Console.ReadKey(); return; }

        Console.Write("Ingrese el ID del libro a eliminar: ");
        int.TryParse(Console.ReadLine(), out int id);
        var libro = libros.FirstOrDefault(l => l.Id == id);
        if (libro == null) { Console.WriteLine("Libro no encontrado."); Console.ReadKey(); return; }

        // No permitir eliminar si tiene préstamos activos
        bool tienePrestamoActivo = prestamoService.ObtenerTodos()
            .Any(p => p.LibroId == id && p.Activo);
        if (tienePrestamoActivo)
        {
            Console.WriteLine("✖ No se puede eliminar: el libro tiene un préstamo activo.");
            Console.ReadKey(); return;
        }

        libroService.EliminarLibro(id);
        Console.WriteLine("✔ Libro eliminado correctamente.");
        Console.ReadKey();
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  MENÚ USUARIOS
    // ═══════════════════════════════════════════════════════════════════════════
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

            switch (option)
            {
                case 1: RegisterUser();    break;
                case 2: ListUsers();       break;
                case 3: ViewUserDetail();  break;
                case 4: UpdateUserMenu();  break;
                case 5: DeleteUser();      break;
            }
        } while (option != 0);
    }

    static void RegisterUser()
    {
        Console.Clear();
        Console.WriteLine("===== REGISTRAR USUARIO =====");
        Console.Write("Ingrese nombre: ");
        string nombre = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(nombre)) { Console.WriteLine("El nombre no puede estar vacío."); Console.ReadKey(); return; }

        Console.Write("Ingrese correo: ");
        string correo = Console.ReadLine() ?? "";

        var usuario = new Usuario(nextUsuarioId++, nombre, correo, true);
        usuarioService.AgregarUsuario(usuario);

        Console.WriteLine("\n✔ Usuario registrado correctamente:");
        Console.WriteLine(usuario.DetalleCompleto());
        Console.ReadKey();
    }

    static void ListUsers()
    {
        Console.Clear();
        Console.WriteLine("===== LISTAR USUARIOS =====");
        var usuarios = usuarioService.ObtenerTodos();
        if (usuarios.Count == 0) Console.WriteLine("No hay usuarios registrados.");
        else foreach (var u in usuarios) { Console.WriteLine(u.DetalleCompleto()); Console.WriteLine("---------------------------"); }
        Console.ReadKey();
    }

    static void ViewUserDetail()
    {
        Console.Clear();
        Console.WriteLine("===== DETALLE DEL USUARIO =====");
        Console.Write("Ingrese el ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);
        if (usuario == null) Console.WriteLine("Usuario no encontrado.");
        else Console.WriteLine(usuario.DetalleCompleto());
        Console.ReadKey();
    }

    static void UpdateUserMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("===== ACTUALIZAR USUARIO =====");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar correo");
            Console.WriteLine("3. Activar / Desactivar usuario");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1: EditUserName();            break;
                case 2: EditUserContact();         break;
                case 3: ToggleUserActiveStatus();  break;
            }
        } while (option != 0);
    }

    static void EditUserName()
    {
        Console.Clear();
        Console.WriteLine("===== EDITAR NOMBRE =====");
        Console.Write("Ingrese el ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);
        if (usuario == null) { Console.WriteLine("Usuario no encontrado."); Console.ReadKey(); return; }
        Console.Write("Nuevo nombre: ");
        string nuevoNombre = Console.ReadLine() ?? "";
        if (!string.IsNullOrWhiteSpace(nuevoNombre)) { usuario.Nombre = nuevoNombre; Console.WriteLine("✔ Nombre actualizado."); }
        else Console.WriteLine("El nombre no puede estar vacío.");
        Console.ReadKey();
    }

    static void EditUserContact()
    {
        Console.Clear();
        Console.WriteLine("===== EDITAR CORREO =====");
        Console.Write("Ingrese el ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);
        if (usuario == null) { Console.WriteLine("Usuario no encontrado."); Console.ReadKey(); return; }
        Console.Write("Nuevo correo: ");
        string nuevoCorreo = Console.ReadLine() ?? "";
        usuario.Correo = nuevoCorreo;
        Console.WriteLine("✔ Correo actualizado.");
        Console.ReadKey();
    }

    static void ToggleUserActiveStatus()
    {
        Console.Clear();
        Console.WriteLine("===== ACTIVAR / DESACTIVAR USUARIO =====");
        Console.Write("Ingrese el ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);
        if (usuario == null) { Console.WriteLine("Usuario no encontrado."); Console.ReadKey(); return; }
        usuario.Activo = !usuario.Activo;
        Console.WriteLine($"✔ Usuario ahora está: {(usuario.Activo ? "Activo" : "Inactivo")}");
        Console.ReadKey();
    }

    static void DeleteUser()
    {
        Console.Clear();
        Console.WriteLine("===== ELIMINAR USUARIO =====");
        Console.Write("Ingrese el ID del usuario a eliminar: ");
        int.TryParse(Console.ReadLine(), out int id);
        var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);
        if (usuario == null) { Console.WriteLine("Usuario no encontrado."); Console.ReadKey(); return; }

        bool tienePrestamoActivo = prestamoService.ObtenerTodos()
            .Any(p => p.UsuarioId == id && p.Activo);
        if (tienePrestamoActivo)
        {
            Console.WriteLine("✖ No se puede eliminar: el usuario tiene préstamos activos.");
            Console.ReadKey(); return;
        }

        usuarioService.EliminarUsuario(id);
        Console.WriteLine("✔ Usuario eliminado correctamente.");
        Console.ReadKey();
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  MENÚ PRÉSTAMOS
    // ═══════════════════════════════════════════════════════════════════════════
    static void ShowLoansMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("===== MENÚ PRÉSTAMOS =====");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle del préstamo");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1: CreateLoan();       break;
                case 2: ListLoansMenu();    break;
                case 3: ViewLoanDetail();   break;
                case 4: RegisterReturn();   break;
                case 5: DeleteLoan();       break;
            }
        } while (option != 0);
    }

    static void CreateLoan()
    {
        Console.Clear();
        Console.WriteLine("===== CREAR PRÉSTAMO =====");

        // Pedir ID de usuario
        Console.Write("Ingrese el ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int usuarioId);
        var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == usuarioId);
        if (usuario == null)     { Console.WriteLine("✖ Usuario no encontrado.");  Console.ReadKey(); return; }
        if (!usuario.Activo)     { Console.WriteLine("✖ El usuario no está activo."); Console.ReadKey(); return; }

        // Pedir ID de libro
        Console.Write("Ingrese el ID del libro: ");
        int.TryParse(Console.ReadLine(), out int libroId);
        var libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == libroId);
        if (libro == null)       { Console.WriteLine("✖ Libro no encontrado.");    Console.ReadKey(); return; }
        if (!libro.Disponible)   { Console.WriteLine("✖ El libro no está disponible."); Console.ReadKey(); return; }

        // Crear préstamo
        var prestamo = new Prestamo(nextPrestamoId++, libroId, usuarioId);
        prestamoService.AgregarPrestamo(prestamo);
        libro.Disponible = false; // marcar como prestado

        Console.WriteLine($"\n✔ Préstamo creado:");
        Console.WriteLine($"  Usuario : {usuario.Nombre}");
        Console.WriteLine($"  Libro   : {libro.Titulo}");
        Console.WriteLine($"  Fecha   : {prestamo.FechaPrestamo:dd/MM/yyyy HH:mm}");
        Console.ReadKey();
    }

    static void ListLoansMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("===== LISTAR PRÉSTAMOS =====");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Activos");
            Console.WriteLine("3. Cerrados");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1: ListLoansAll();    break;
                case 2: ListLoansActive(); break;
                case 3: ListLoansClosed(); break;
            }
        } while (option != 0);
    }

    static void PrintLoan(Prestamo p)
    {
        var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == p.UsuarioId);
        var libro   = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == p.LibroId);
        Console.WriteLine($"Préstamo #{p.Id}");
        Console.WriteLine($"  Usuario : {usuario?.Nombre ?? "?"} (ID {p.UsuarioId})");
        Console.WriteLine($"  Libro   : {libro?.Titulo ?? "?"} (ID {p.LibroId})");
        Console.WriteLine($"  Fecha   : {p.FechaPrestamo:dd/MM/yyyy HH:mm}");
        Console.WriteLine($"  Estado  : {(p.Activo ? "Activo" : "Cerrado")}");
        if (p.FechaDevolucion.HasValue)
            Console.WriteLine($"  Devol.  : {p.FechaDevolucion.Value:dd/MM/yyyy HH:mm}");
        Console.WriteLine("---------------------------");
    }

    static void ListLoansAll()
    {
        Console.Clear();
        Console.WriteLine("===== TODOS LOS PRÉSTAMOS =====");
        var lista = prestamoService.ObtenerTodos();
        if (lista.Count == 0) Console.WriteLine("No hay préstamos registrados.");
        else foreach (var p in lista) PrintLoan(p);
        Console.ReadKey();
    }

    static void ListLoansActive()
    {
        Console.Clear();
        Console.WriteLine("===== PRÉSTAMOS ACTIVOS =====");
        var lista = prestamoService.ObtenerTodos().Where(p => p.Activo).ToList();
        if (lista.Count == 0) Console.WriteLine("No hay préstamos activos.");
        else foreach (var p in lista) PrintLoan(p);
        Console.ReadKey();
    }

    static void ListLoansClosed()
    {
        Console.Clear();
        Console.WriteLine("===== PRÉSTAMOS CERRADOS =====");
        var lista = prestamoService.ObtenerTodos().Where(p => !p.Activo).ToList();
        if (lista.Count == 0) Console.WriteLine("No hay préstamos cerrados.");
        else foreach (var p in lista) PrintLoan(p);
        Console.ReadKey();
    }

    static void ViewLoanDetail()
    {
        Console.Clear();
        Console.WriteLine("===== DETALLE DEL PRÉSTAMO =====");
        Console.Write("Ingrese el ID del préstamo: ");
        int.TryParse(Console.ReadLine(), out int id);
        var prestamo = prestamoService.ObtenerTodos().FirstOrDefault(p => p.Id == id);
        if (prestamo == null) Console.WriteLine("Préstamo no encontrado.");
        else PrintLoan(prestamo);
        Console.ReadKey();
    }

    static void RegisterReturn()
    {
        Console.Clear();
        Console.WriteLine("===== REGISTRAR DEVOLUCIÓN =====");
        Console.Write("Ingrese el ID del préstamo: ");
        int.TryParse(Console.ReadLine(), out int id);
        var prestamo = prestamoService.ObtenerTodos().FirstOrDefault(p => p.Id == id);
        if (prestamo == null) { Console.WriteLine("Préstamo no encontrado."); Console.ReadKey(); return; }
        if (!prestamo.Activo) { Console.WriteLine("Este préstamo ya fue cerrado."); Console.ReadKey(); return; }

        prestamo.RegistrarDevolucion();

        // Devolver el libro
        var libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == prestamo.LibroId);
        if (libro != null) libro.Disponible = true;

        Console.WriteLine($"✔ Devolución registrada. Libro '{libro?.Titulo}' disponible nuevamente.");
        Console.ReadKey();
    }

    static void DeleteLoan()
    {
        Console.Clear();
        Console.WriteLine("===== ELIMINAR PRÉSTAMO =====");
        Console.Write("Ingrese el ID del préstamo a eliminar: ");
        int.TryParse(Console.ReadLine(), out int id);
        var prestamo = prestamoService.ObtenerTodos().FirstOrDefault(p => p.Id == id);
        if (prestamo == null) { Console.WriteLine("Préstamo no encontrado."); Console.ReadKey(); return; }
        if (prestamo.Activo)  { Console.WriteLine("✖ Solo se pueden eliminar préstamos cerrados."); Console.ReadKey(); return; }
        prestamoService.EliminarPrestamo(id);
        Console.WriteLine("✔ Préstamo eliminado correctamente.");
        Console.ReadKey();
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  BÚSQUEDAS Y REPORTES
    // ═══════════════════════════════════════════════════════════════════════════
    static void ShowSearchReportsMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("===== BÚSQUEDAS Y REPORTES =====");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1: SearchBook();        break;
                case 2: SearchUser();        break;
                case 3: ShowReportsMenu();   break;
            }
        } while (option != 0);
    }

    static void SearchBook()
    {
        Console.Clear();
        Console.WriteLine("===== BUSCAR LIBRO =====");
        Console.Write("Ingrese título o autor a buscar: ");
        string texto = Console.ReadLine() ?? "";
        var resultados = libroService.ObtenerTodos()
            .Where(l => l.Titulo.ToLower().Contains(texto.ToLower())
                     || l.Autor.ToLower().Contains(texto.ToLower()))
            .ToList();
        if (resultados.Count == 0) Console.WriteLine("No se encontraron libros.");
        else foreach (var l in resultados) { Console.WriteLine(l.DetalleCompleto()); Console.WriteLine("---------------------------"); }
        Console.ReadKey();
    }

    static void SearchUser()
    {
        Console.Clear();
        Console.WriteLine("===== BUSCAR USUARIO =====");
        Console.Write("Ingrese nombre o correo a buscar: ");
        string texto = Console.ReadLine() ?? "";
        var resultados = usuarioService.ObtenerTodos()
            .Where(u => u.Nombre.ToLower().Contains(texto.ToLower())
                     || u.Correo.ToLower().Contains(texto.ToLower()))
            .ToList();
        if (resultados.Count == 0) Console.WriteLine("No se encontraron usuarios.");
        else foreach (var u in resultados) { Console.WriteLine(u.DetalleCompleto()); Console.WriteLine("---------------------------"); }
        Console.ReadKey();
    }

    static void ShowReportsMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("===== REPORTES =====");
            Console.WriteLine("1. Préstamos por usuario");
            Console.WriteLine("2. Préstamos por libro");
            Console.WriteLine("3. Préstamos vencidos (> 15 días)");
            Console.WriteLine("4. Resumen general");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1: ReportByUser();    break;
                case 2: ReportByBook();    break;
                case 3: ReportOverdue();   break;
                case 4: ReportSummary();   break;
            }
        } while (option != 0);
    }

    static void ReportByUser()
    {
        Console.Clear();
        Console.WriteLine("===== PRÉSTAMOS POR USUARIO =====");
        Console.Write("Ingrese el ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        var prestamos = prestamoService.BuscarPorUsuario(id);
        var usuario = usuarioService.ObtenerTodos().FirstOrDefault(u => u.Id == id);
        if (usuario == null) { Console.WriteLine("Usuario no encontrado."); Console.ReadKey(); return; }
        Console.WriteLine($"\nUsuario: {usuario.Nombre} — Total préstamos: {prestamos.Count}");
        foreach (var p in prestamos) PrintLoan(p);
        Console.ReadKey();
    }

    static void ReportByBook()
    {
        Console.Clear();
        Console.WriteLine("===== PRÉSTAMOS POR LIBRO =====");
        Console.Write("Ingrese el ID del libro: ");
        int.TryParse(Console.ReadLine(), out int id);
        var prestamos = prestamoService.BuscarPorLibro(id);
        var libro = libroService.ObtenerTodos().FirstOrDefault(l => l.Id == id);
        if (libro == null) { Console.WriteLine("Libro no encontrado."); Console.ReadKey(); return; }
        Console.WriteLine($"\nLibro: {libro.Titulo} — Total préstamos: {prestamos.Count}");
        foreach (var p in prestamos) PrintLoan(p);
        Console.ReadKey();
    }

    static void ReportOverdue()
    {
        Console.Clear();
        Console.WriteLine("===== PRÉSTAMOS VENCIDOS (> 15 días) =====");
        var vencidos = prestamoService.ObtenerTodos()
            .Where(p => p.Activo && (DateTime.Now - p.FechaPrestamo).TotalDays > 15)
            .ToList();
        if (vencidos.Count == 0) Console.WriteLine("No hay préstamos vencidos.");
        else foreach (var p in vencidos)
        {
            PrintLoan(p);
            Console.WriteLine($"  ⚠ Días vencido: {(int)(DateTime.Now - p.FechaPrestamo).TotalDays}");
        }
        Console.ReadKey();
    }

    static void ReportSummary()
    {
        Console.Clear();
        Console.WriteLine("===== RESUMEN GENERAL DEL SISTEMA =====");
        Console.WriteLine($"Libros registrados  : {libroService.TotalLibros()}");
        Console.WriteLine($"  - Disponibles     : {libroService.LibrosDisponibles()}");
        Console.WriteLine($"  - Prestados       : {libroService.LibrosPrestados()}");
        Console.WriteLine();
        Console.WriteLine($"Usuarios registrados: {usuarioService.TotalUsuarios()}");
        Console.WriteLine($"  - Activos         : {usuarioService.UsuariosActivos()}");
        Console.WriteLine($"  - Inactivos       : {usuarioService.UsuariosInactivos()}");
        Console.WriteLine();
        Console.WriteLine($"Préstamos totales   : {prestamoService.TotalPrestamos()}");
        Console.WriteLine($"  - Activos         : {prestamoService.PrestamosActivos()}");
        Console.WriteLine($"  - Cerrados        : {prestamoService.PrestamosInactivos()}");
        Console.ReadKey();
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  GUARDAR / CARGAR DATOS
    // ═══════════════════════════════════════════════════════════════════════════
    static void ShowPersistenceMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("===== GUARDAR / CARGAR DATOS =====");
            Console.WriteLine("1. Guardar datos");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione una opción: ");
            int.TryParse(Console.ReadLine(), out option);
            switch (option)
            {
                case 1: SaveData();         break;
                case 2: LoadData();         break;
                case 3: ConfirmResetData(); break;
            }
        } while (option != 0);
    }

    static void SaveData()
    {
        Console.Clear();
        Console.WriteLine("===== GUARDAR DATOS =====");
        // Persistencia simple en CSV
        try
        {
            var lines = libroService.ObtenerTodos()
                .Select(l => $"{l.Id}|{l.Titulo}|{l.Autor}|{l.Disponible}");
            File.WriteAllLines("libros.csv", lines);

            var linesU = usuarioService.ObtenerTodos()
                .Select(u => $"{u.Id}|{u.Nombre}|{u.Correo}|{u.Activo}");
            File.WriteAllLines("usuarios.csv", linesU);

            var linesP = prestamoService.ObtenerTodos()
                .Select(p => $"{p.Id}|{p.LibroId}|{p.UsuarioId}|{p.FechaPrestamo:O}|{p.FechaDevolucion?.ToString("O") ?? ""}|{p.Activo}");
            File.WriteAllLines("prestamos.csv", linesP);

            Console.WriteLine("✔ Datos guardados en libros.csv, usuarios.csv, prestamos.csv");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✖ Error al guardar: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void LoadData()
    {
        Console.Clear();
        Console.WriteLine("===== CARGAR DATOS =====");
        try
        {
            if (File.Exists("libros.csv"))
            {
                foreach (var line in File.ReadAllLines("libros.csv"))
                {
                    var p = line.Split('|');
                    var l = new Libro(int.Parse(p[0]), p[1], p[2], bool.Parse(p[3]));
                    libroService.AgregarLibro(l);
                    if (l.Id >= nextLibroId) nextLibroId = l.Id + 1;
                }
                Console.WriteLine("✔ Libros cargados.");
            }
            if (File.Exists("usuarios.csv"))
            {
                foreach (var line in File.ReadAllLines("usuarios.csv"))
                {
                    var p = line.Split('|');
                    var u = new Usuario(int.Parse(p[0]), p[1], p[2], bool.Parse(p[3]));
                    usuarioService.AgregarUsuario(u);
                    if (u.Id >= nextUsuarioId) nextUsuarioId = u.Id + 1;
                }
                Console.WriteLine("✔ Usuarios cargados.");
            }
            if (File.Exists("prestamos.csv"))
            {
                foreach (var line in File.ReadAllLines("prestamos.csv"))
                {
                    var p = line.Split('|');
                    var pr = new Prestamo
                    {
                        Id              = int.Parse(p[0]),
                        LibroId         = int.Parse(p[1]),
                        UsuarioId       = int.Parse(p[2]),
                        FechaPrestamo   = DateTime.Parse(p[3]),
                        FechaDevolucion = string.IsNullOrEmpty(p[4]) ? null : DateTime.Parse(p[4]),
                        Activo          = bool.Parse(p[5])
                    };
                    prestamoService.AgregarPrestamo(pr);
                    if (pr.Id >= nextPrestamoId) nextPrestamoId = pr.Id + 1;
                }
                Console.WriteLine("✔ Préstamos cargados.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✖ Error al cargar: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void ResetData()
    {
        libroService    = new LibroService();
        usuarioService  = new UsuarioService();
        prestamoService = new PrestamoService();
        nextLibroId = nextUsuarioId = nextPrestamoId = 1;
        Console.WriteLine("✔ Datos reiniciados.");
        Console.ReadKey();
    }

    static void ConfirmResetData()
    {
        Console.Clear();
        Console.Write("¿Está seguro que desea reiniciar todos los datos? (S/N): ");
        string response = Console.ReadLine() ?? "";
        if (response.ToUpper() == "S") ResetData();
    }

    static void ConfirmExitAndSave()
    {
        Console.Clear();
        Console.WriteLine("===== SALIR DEL SISTEMA =====");
        Console.Write("¿Desea guardar antes de salir? (S/N): ");
        string response = Console.ReadLine() ?? "";
        if (response.ToUpper() == "S") SaveData();
        Console.WriteLine("Saliendo del sistema... ¡Hasta pronto!");
        Console.ReadKey();
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  PRUEBA SERVICES
    // ═══════════════════════════════════════════════════════════════════════════
    static void TestServices()
    {
        Console.Clear();
        Console.WriteLine("===== PRUEBA SERVICES =====");

        var tmpLS = new LibroService();
        tmpLS.AgregarLibro(new Libro(1, "Libro prueba",  "Autor"));
        tmpLS.AgregarLibro(new Libro(2, "Otro libro",    "Autor 2"));

        Console.WriteLine("--- LibroService ---");
        Console.WriteLine("Total     : " + tmpLS.TotalLibros());
        Console.WriteLine("Disponibles: " + tmpLS.LibrosDisponibles());
        Console.WriteLine("Prestados : " + tmpLS.LibrosPrestados());

        var tmpUS = new UsuarioService();
        tmpUS.AgregarUsuario(new Usuario(1, "Juan", "juan@mail.com", true));
        tmpUS.AgregarUsuario(new Usuario(2, "Ana",  "ana@mail.com",  false));

        Console.WriteLine("\n--- UsuarioService ---");
        Console.WriteLine("Total    : " + tmpUS.TotalUsuarios());
        Console.WriteLine("Activos  : " + tmpUS.UsuariosActivos());
        Console.WriteLine("Inactivos: " + tmpUS.UsuariosInactivos());

        var tmpPS = new PrestamoService();
        var pr1 = new Prestamo(1, 1, 1);
        var pr2 = new Prestamo(2, 2, 2);
        pr2.RegistrarDevolucion();
        tmpPS.AgregarPrestamo(pr1);
        tmpPS.AgregarPrestamo(pr2);

        Console.WriteLine("\n--- PrestamoService ---");
        Console.WriteLine("Total   : " + tmpPS.TotalPrestamos());
        Console.WriteLine("Activos : " + tmpPS.PrestamosActivos());
        Console.WriteLine("Cerrados: " + tmpPS.PrestamosInactivos());

        Console.ReadKey();
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  ARRAY VS LIST
    // ═══════════════════════════════════════════════════════════════════════════
    static void CompararArrayVsList()
    {
        Console.Clear();
        Console.WriteLine("===== ARRAY VS LIST =====");

        int[] numerosArray = new int[3] { 10, 20, 30 };
        Console.WriteLine("Array (tamaño fijo):");
        foreach (var n in numerosArray) Console.WriteLine("  " + n);

        List<int> numerosList = new List<int> { 10, 20, 30 };
        numerosList.Add(40); // Puedes agregar más elementos
        Console.WriteLine("\nList (tamaño dinámico):");
        foreach (var n in numerosList) Console.WriteLine("  " + n);

        Console.WriteLine("\nArray : tamaño fijo, acceso por índice rápido.");
        Console.WriteLine("List  : tamaño dinámico, permite Add/Remove fácilmente.");
        Console.ReadKey();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> develop
