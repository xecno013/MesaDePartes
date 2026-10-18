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
    
    static void Main() { }
}