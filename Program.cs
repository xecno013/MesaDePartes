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

    static void RegistrarDocumento()
    {
        Documento documento = new Documento();
        Console.WriteLine("\n--- NUEVO REGISTRO ---");

        bool dniValido = false;
        do
        {
            Console.Write("Ingrese DNI (8 dígitos): ");
            string inputDNI = Console.ReadLine();
            if (inputDNI.Length == 8 && long.TryParse(inputDNI, out _))
            {
                documento.DNI = inputDNI;
                dniValido = true;
            }
            else Console.WriteLine("Error: El DNI debe contener exactamente 8 números.");
        } while (!dniValido);

        bool nombreValido = false;
        do
        {
            Console.Write("Ingrese nombre del remitente: ");
            documento.Nombre = Console.ReadLine().Trim();
            if (!string.IsNullOrWhiteSpace(documento.Nombre) && documento.Nombre.Length >= 3)
                nombreValido = true;
            else Console.WriteLine("Error: El nombre no puede estar vacío o ser muy corto.");
        } while (!nombreValido);

        bool asuntoValido = false;
        do
        {
            Console.Write("Ingrese asunto del documento: ");
            documento.Asunto = Console.ReadLine().Trim();
            if (!string.IsNullOrWhiteSpace(documento.Asunto))
                asuntoValido = true;
            else Console.WriteLine("Error: El asunto es obligatorio.");
        } while (!asuntoValido);

        bool tipoValido = false;
        do
        {
            Console.Write("Ingrese tipo de documento (Academico / Conducta / Otro): ");
            string inputTipo = Console.ReadLine().Trim().ToLower();
            if (inputTipo == "academico" || inputTipo == "conducta" || inputTipo == "otro")
            {
                documento.Tipo = char.ToUpper(inputTipo[0]) + inputTipo.Substring(1); 
                tipoValido = true;
            }
            else Console.WriteLine("Error: Tipo inválido. Debe escribir 'Academico', 'Conducta' u 'Otro'.");
        } while (!tipoValido);

        documento.Codigo = "DOC-2026-" + (documentos.Count + 1);

        if (documento.Tipo.ToLower() == "academico") documento.Area = "Secretaria";
        else if (documento.Tipo.ToLower() == "conducta") documento.Area = "Tutoria";
        else documento.Area = "Direccion";

        documentos.Add(documento);

        Console.WriteLine("\nDocumento registrado correctamente.");
        Console.WriteLine("Código de seguimiento: " + documento.Codigo);
        Console.WriteLine("Área de destino: " + documento.Area);
    }

    static void BuscarDocumento()
    {
        Console.WriteLine("\n--- REGISTROS EXISTENTES ---");
        if (documentos.Count == 0)
        {
            Console.WriteLine("No hay documentos registrados aún.");
            return;
        }

        Console.WriteLine("{0,-20} | {1,-15} | {2,-15}", "REMITENTE", "TIPO", "CÓDIGO");
        Console.WriteLine(new string('-', 56));
        foreach (var doc in documentos)
        {
            Console.WriteLine("{0,-20} | {1,-15} | {2,-15}", doc.Nombre, doc.Tipo, doc.Codigo);
        }

        Console.Write("\nIngrese el código de seguimiento a buscar: ");
        string codigo = Console.ReadLine();

        foreach (Documento documento in documentos)
        {
            if (documento.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\n--- DETALLE DEL DOCUMENTO ---");
                Console.WriteLine("Código: " + documento.Codigo);
                Console.WriteLine("DNI: " + documento.DNI);
                Console.WriteLine("Remitente: " + documento.Nombre);
                Console.WriteLine("Asunto: " + documento.Asunto);
                Console.WriteLine("Área de destino: " + documento.Area);
                return;
            }
        }
        Console.WriteLine("El código ingresado no existe.");
    }
}