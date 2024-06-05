using Entidades;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using static Entidades.Documento;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libro l1 = new Libro("Yerma", "García Lorca, Federico", 1995, "11111", "22222", 100);
            Libro l2 = new Libro("Bodas de sangre", "García Lorca, Federico", 1997, "11112", "22223", 200);
            Libro l3 = new Libro("Codebar repetido", "García Lorca, Federico", 2003, "11113", "22222", 3);
            Libro l4 = new Libro("ISBN repetido", "García Lorca, Federico", 2003, "11112", "22224", 2);
            Libro l5 = new Libro("Yerma", "García Lorca, Federico", 2003, "55555", "66666", 1);

            Mapa m1 = new Mapa("Buenos Aires", "Instituto Geográfico de Buenos Aires", 2005, "", "99999", 30, 15);
            Mapa m2 = new Mapa("Mendoza", "Instituto Geográfico de Mendoza", 2008, "", "99990", 100, 30);
            Mapa m3 = new Mapa("Santa Fe", "Instituto Geográfico de Santa Fe", 2010, "", "99991", 80, 30);
            Mapa m4 = new Mapa("Corrientes", "Instituto Geográfico de Corrientes", 2013, "", "99992", 50, 25);
            Mapa m5 = new Mapa("Barcode repetido", "Instituto Geográfico", 2015, "", "99999", 40, 15);
            Mapa m6 = new Mapa("Buenos Aires", "Instituto Geográfico de Buenos Aires", 2005, "", "99993", 30, 15);

            // Creación de escáneres
            Escaner l = new Escaner("HP", Escaner.TipoDoc.libro);
            Escaner m = new Escaner("HP", Escaner.TipoDoc.mapa);

            // Manejo de excepciones
            try
            {
                bool pudo = l + m1;
            }
            catch (TipoIncorrectoException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                bool pudo = m + l1;
            }
            catch (TipoIncorrectoException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //try
            //{
            //    bool pudo2 = l + l1;
            //    Console.WriteLine($"True: {l + l2}");
            //    Console.WriteLine($"True: {l + l3}");
            //    Console.WriteLine($"True: {m + m1}");
            //    Console.WriteLine($"True: {m + m2}");
            //    Console.WriteLine($"False: {l + m3}");
            //    Console.WriteLine($"False: {m + l3}");
            //}
            //catch (TipoIncorrectoException ex){Console.WriteLine(ex.ToString()); }
        }
    }
}
