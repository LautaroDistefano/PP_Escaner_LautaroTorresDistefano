using Entidades;
namespace Test
{
    internal class Program
    {
        static void Main()
        {
            // Crear algunos libros y mapas
            Libro libro1 = new Libro(2020, "Autor A", "12345", "ISBN123", "Libro A", 100);
            Libro libro2 = new Libro(2021, "Autor B", "67890", "ISBN456", "Libro B", 200);
            Mapa mapa1 = new Mapa("Mapa A", "Cartógrafo A", 2019, "54321", 50, 40);
            Mapa mapa2 = new Mapa("Mapa B", "Cartógrafo B", 2022, "09876", 60, 50);

            // Crear un escáner y agregar los documentos
            Escaner escaner = new Escaner("Marca X", Escaner.TipoDoc.libro);
            escaner += libro1;
            escaner += libro2;
            escaner += mapa1;
            escaner += mapa2;

            // Cambiar el estado de los documentos
            libro1.AvanzarEstado(); // Distribuido
            libro2.AvanzarEstado(); // Distribuido
            mapa1.AvanzarEstado(); // Distribuido
            mapa1.AvanzarEstado(); // EnEscaner
            mapa2.AvanzarEstado(); // Distribuido
            mapa2.AvanzarEstado(); // EnEscaner
            mapa2.AvanzarEstado(); // EnRevision
            mapa2.AvanzarEstado(); // Terminado

            // Mostrar informes
            Informes.MostrarDistribuidos(escaner, out int extensionDistribuidos, out int cantidadDistribuidos, out string resumenDistribuidos);
            Console.WriteLine("Informes Distribuidos:");
            Console.WriteLine($"Extensión total: {extensionDistribuidos}");
            Console.WriteLine($"Cantidad total de ítems únicos: {cantidadDistribuidos}");
            Console.WriteLine($"Resumen:\n{resumenDistribuidos}\n");

            Informes.MostrarEnEscaner(escaner, out int extensionEnEscaner, out int cantidadEnEscaner, out string resumenEnEscaner);
            Console.WriteLine("Informes EnEscaner:");
            Console.WriteLine($"Extensión total: {extensionEnEscaner}");
            Console.WriteLine($"Cantidad total de ítems únicos: {cantidadEnEscaner}");
            Console.WriteLine($"Resumen:\n{resumenEnEscaner}\n");

            Informes.MostrarEnRevisión(escaner, out int extensionEnRevision, out int cantidadEnRevision, out string resumenEnRevision);
            Console.WriteLine("Informes EnRevisión:");
            Console.WriteLine($"Extensión total: {extensionEnRevision}");
            Console.WriteLine($"Cantidad total de ítems únicos: {cantidadEnRevision}");
            Console.WriteLine($"Resumen:\n{resumenEnRevision}\n");

            Informes.MostrarTerminados(escaner, out int extensionTerminados, out int cantidadTerminados, out string resumenTerminados);
            Console.WriteLine("Informes Terminados:");
            Console.WriteLine($"Extensión total: {extensionTerminados}");
            Console.WriteLine($"Cantidad total de ítems únicos: {cantidadTerminados}");
            Console.WriteLine($"Resumen:\n{resumenTerminados}\n");
        }
    }
}