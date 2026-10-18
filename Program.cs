using System;
using System.Collections.Generic;
using System.IO;

class Documento
{
    public string Codigo { get; set; }
    public string DNI { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public string Asunto { get; set; }
    public string Area { get; set; }
}

class Program
{
    static List<Documento> documentos = new List<Documento>();
    static string archivo = "documentos.csv";

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- MESA DE PARTES DIGITAL ---");
            Console.WriteLine("I.E. FRANCISCO LIZARZABURU");
            Console.WriteLine("1. Registrar documento");
            Console.WriteLine("2. Buscar documento");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Ingrese un número.");
                continue;
            }

            switch (opcion)
            {
                case 1: RegistrarDocumento(); break;
                case 2: BuscarDocumento(); break;
                case 3: Console.WriteLine("Saliendo del sistema..."); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        } while (opcion != 3);
    }

    static void RegistrarDocumento() { }
    static void BuscarDocumento() { }
}