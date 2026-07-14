using System;

namespace InventarioIT
{
    public abstract class ActivoIT
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Ip { get; set; }
        public string SistemaOperativo { get; set; }
        public bool EstadoOk { get; set; }

        public ActivoIT()
        {
        }

        public ActivoIT(string id, string nombre, string ip, string sistemaOperativo)
        {
            Id = id;
            Nombre = nombre;
            Ip = ip;
            SistemaOperativo = sistemaOperativo;
            EstadoOk = true;
        }

        public virtual string HacerDiagnostico()
        {
            return $"[Diagnóstico] Revisando el estado general de: {Nombre}";
        }
    }

    public class ServidorProduccion : ActivoIT
    {
        public int Nucleos { get; set; }
        public int Ram { get; set; }

        public ServidorProduccion() : base()
        {
        }

        public ServidorProduccion(string id, string nombre, string ip, string sistemaOperativo, int nucleos, int ram)
            : base(id, nombre, ip, sistemaOperativo)
        {
            Nucleos = nucleos;
            Ram = ram;
        }

        public override string HacerDiagnostico()
        {
            if (Nucleos >= 8 && Ram >= 16)
            {
                EstadoOk = true;
                return $"[SERVIDOR PROD - OK] {Nombre} ({Ip}) corriendo estable con {Nucleos} vCPUs y {Ram}GB de RAM.";
            }
            else
            {
                EstadoOk = false;
                return $"[ALERTA PROD] El servidor {Nombre} tiene recursos muy bajos para soportar la carga.";
            }
        }
    }

    public class ServidorBaseDatos : ActivoIT
    {
        public string Motor { get; set; }
        public int Puerto { get; set; }

        public ServidorBaseDatos() : base()
        {
        }

        public ServidorBaseDatos(string id, string nombre, string ip, string sistemaOperativo, string motor, int puerto)
            : base(id, nombre, ip, sistemaOperativo)
        {
            Motor = motor;
            Puerto = puerto;
        }

        public override string HacerDiagnostico()
        {
            if (Puerto == 5432)
            {
                EstadoOk = true;
                return $"[BD - STABLE] {Nombre} running {Motor} en el puerto {Puerto}. Conexiones activas.";
            }
            else
            {
                EstadoOk = false;
                return $"[ERROR CRÍTICO BD] Puerto {Puerto} incorrecto o cerrado en {Nombre}. Posible caída.";
            }
        }
    }

    public class EstacionTrabajo : ActivoIT
    {
        public string Programador { get; set; }
        public bool UsaWsl2 { get; set; }

        public EstacionTrabajo() : base()
        {
        }

        public EstacionTrabajo(string id, string nombre, string ip, string sistemaOperativo, string programador, bool usaWsl2)
            : base(id, nombre, ip, sistemaOperativo)
        {
            Programador = programador;
            UsaWsl2 = usaWsl2;
        }

        public override string HacerDiagnostico()
        {
            string entorno = UsaWsl2 ? "Entorno WSL2/Ubuntu activo" : "Sin entorno Linux local";
            EstadoOk = true;
            return $"[ENDPOINT - OK] Laptop de {Programador} ({SistemaOperativo}). IP: {Ip}. {entorno}.";
        }
    }
}