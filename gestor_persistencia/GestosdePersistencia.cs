using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace Persistencia_Sistema
{
    public class GestorPersistencia
    {
        public bool GuardarDatos<T>(List<T> lista, string nombreArchivo)
        {
            try
            {
                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string jsonTexto = JsonSerializer.Serialize(lista, opciones);
                File.WriteAllText(nombreArchivo, jsonTexto);
                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[Error de Disco] No se pudo guardar en {nombreArchivo}: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Fallo Inesperado al Guardar]: {ex.Message}");
                return false;
            }
        }

        public List<T> CargarDatos<T>(string nombreArchivo)
        {
            if (!File.Exists(nombreArchivo))
            {
                Console.WriteLine($"[Aviso] El archivo {nombreArchivo} no existe. Se iniciará una lista vacía.");
                return new List<T>();
            }

            try
            {
                string jsonTexto = File.ReadAllText(nombreArchivo);
                var listaCargada = JsonSerializer.Deserialize<List<T>>(jsonTexto);
                return listaCargada ?? new List<T>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[Error de Formato] El archivo {nombreArchivo} está dañado: {ex.Message}");
                return new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Fallo Inesperado al Cargar]: {ex.Message}");
                return new List<T>();
            }
        }
    }
}