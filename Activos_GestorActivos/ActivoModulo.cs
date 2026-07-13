using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Activos_GestorActivos
{
    public abstract class ActivoFinanciero
    {
        public string Identificador { get; set; }
        public string NombreActivo { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public decimal PrecioActual { get; set; }
    }

    public class Divisa : ActivoFinanciero
    {
        public string FuenteTasaCambiaria { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
    }
    public class Accion : ActivoFinanciero
    {
        public decimal PrecioApertura { get; set; }
        public decimal VariacionPorcentual { get; set; }
        public long VolumenTransacciones { get; set; }
    }
    public class Criptomoneda : ActivoFinanciero
    {
        public string RedBlockchain { get; set; }
        public string SimboloRed { get; set; }
        public decimal Volumen24H { get; set; }
    }

}
