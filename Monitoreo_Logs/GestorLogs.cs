using System;
using System.IO;

namespace Proyecto_Capytech.Monitoreo_Logs
{
    public static class GestorLogs
    {
        // Ruta del archivo de texto donde se guardará el registro de eventos
        private static readonly string RutaLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bitacora_capytech.txt");
        private static readonly object Bloqueo = new object();

        /// <summary>
        /// Método para registrar eventos y errores de los demás módulos
        /// </summary>
        public static void RegistrarEvento(string modulo, string descripcion, string nivel)
        {
            try
            {
                // Formato: [2026-07-20 14:30:00] [INFO] [SEGURIDAD] -> Inicio de sesión exitoso
                string lineaLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{nivel.ToUpper()}] [{modulo.ToUpper()}] -> {descripcion}";

                lock (Bloqueo)
                {
                    using (StreamWriter writer = new StreamWriter(RutaLog, true))
                    {
                        writer.WriteLine(lineaLog);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al escribir en la bitácora: {ex.Message}");
            }
        }
    }
}