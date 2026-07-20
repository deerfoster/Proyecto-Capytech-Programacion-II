using System;
using System.Collections.Generic;
using System.Linq;
using CapyTech.Seguridad;
using VentanaActivos;

namespace CapyTech.Transacciones
{
    // Representa una compra individual dentro del portafolio //
    public class Transaccion
    {
        public ActivoFinanciero Activo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioAlMomento { get; set; }
        public DateTime Fecha { get; set; }
    }

    // Motor de Transacciones: une al Usuario (Miguel) con los ActivosFinancieros (Xariadna) //
    public class Portafolio
    {
        public Usuario Propietario { get; private set; }

        private List<Transaccion> _historialTransacciones;

        // Acumula la cantidad total por cada activo (clave = Identificador del activo) //
        private Dictionary<string, decimal> _tenencias;

        public Portafolio(Usuario propietario)
        {
            if (propietario == null)
                throw new ArgumentNullException(nameof(propietario), "El portafolio debe pertenecer a un Usuario válido.");

            Propietario = propietario;
            _historialTransacciones = new List<Transaccion>();
            _tenencias = new Dictionary<string, decimal>();
        }

        // Registra la compra de un ActivoFinanciero y lo suma al portafolio del Usuario //
        public bool RegistrarCompra(ActivoFinanciero activo, decimal cantidad)
        {
            if (activo == null)
            {
                Console.WriteLine("[Error] No se puede registrar la compra: el activo es nulo.");
                return false;
            }

            if (cantidad <= 0)
            {
                Console.WriteLine("[Error] La cantidad a comprar debe ser mayor a cero.");
                return false;
            }

            Transaccion nuevaTransaccion = new Transaccion
            {
                Activo = activo,
                Cantidad = cantidad,
                PrecioAlMomento = activo.PrecioActual,
                Fecha = DateTime.Now
            };

            _historialTransacciones.Add(nuevaTransaccion);

            if (_tenencias.ContainsKey(activo.Identificador))
                _tenencias[activo.Identificador] += cantidad;
            else
                _tenencias[activo.Identificador] = cantidad;

            return true;
        }

        // Cantidad acumulada de un activo específico dentro del portafolio //
        public decimal ObtenerCantidad(string identificadorActivo)
        {
            return _tenencias.TryGetValue(identificadorActivo, out decimal cantidad) ? cantidad : 0m;
        }

        // Devuelve todas las tenencias actuales del portafolio (Identificador -> Cantidad) //
        public Dictionary<string, decimal> ObtenerTenencias()
        {
            return new Dictionary<string, decimal>(_tenencias);
        }

        // Historial completo de compras realizadas //
        public List<Transaccion> ObtenerHistorial()
        {
            return new List<Transaccion>(_historialTransacciones);
        }

        // Calcula el valor total del portafolio usando los precios actuales del GestorActivos //
        public decimal CalcularValorTotal(List<ActivoFinanciero> activosActuales)
        {
            decimal valorTotal = 0m;

            foreach (var tenencia in _tenencias)
            {
                ActivoFinanciero activoActual = activosActuales
                    .FirstOrDefault(a => a.Identificador == tenencia.Key);

                if (activoActual != null)
                {
                    valorTotal += activoActual.PrecioActual * tenencia.Value;
                }
            }

            return valorTotal;
        }
    }
}
