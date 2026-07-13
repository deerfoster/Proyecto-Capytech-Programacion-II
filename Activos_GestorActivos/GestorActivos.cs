using System;

namespace Activos_GestorActivos
{
    internal class GestorActivos
    {
        // lista para los activos de la clase padre ActivosFinancieros, contiene : Divisa, Accion y Criptomonedas //

        private List<ActivoFinanciero> _listaDeActivos;

        public GestorActivos()
        {
            _listaDeActivos = new List<ActivoFinanciero>();

            _listaDeActivos.Add(new Divisa
            {

                Identificador = "USD",

                NombreActivo = "Dolar BCV",

                UltimaActualizacion = DateTime.Now,

                PrecioActual = 622.21m,

                FuenteTasaCambiaria = "Banco de Venezuela (BCV)",

                PrecioCompra = 800m,

                PrecioVenta = 785m
            });
            _listaDeActivos.Add(new Accion
            {

                Identificador = "BVL",

                NombreActivo = "Acciones",

                UltimaActualizacion = DateTime.Now,

                PrecioActual = 193.50m,

                PrecioApertura = 194.9m,

                VariacionPorcentual = 18371308m,

                VolumenTransacciones = 197000
            });
            _listaDeActivos.Add(new Criptomoneda
            {
                Identificador = "USDT",

                NombreActivo = "Dolar paralelo USDT ",

                UltimaActualizacion = DateTime.Now,

                PrecioActual = 783.01m,

                RedBlockchain = "BNB Smart Chain",

                SimboloRed = "BEP-20",

                Volumen24H = 27388993
            });
        }

        // METODOS PARA EL FRONTED //
        public List<ActivoFinanciero> ObtenerTodosLosActivos()
        {

            return new List<ActivoFinanciero>(_listaDeActivos);

        }
        public void ActualizarPrecios()
        {
            Random fluctuacion = new Random();

            decimal fluctuacionPrecio = (decimal)Math.Abs(fluctuacion.NextDouble() * 0.10);

            foreach (ActivoFinanciero activo in _listaDeActivos)
            {
                if (activo is Divisa divisa)
                {
                    activo.PrecioActual = divisa.PrecioActual + fluctuacionPrecio;

                    divisa.PrecioCompra = divisa.PrecioCompra + fluctuacionPrecio;

                    divisa.PrecioVenta = divisa.PrecioVenta + fluctuacionPrecio;
                }
                if (activo is Accion accion)
                {
                    activo.PrecioActual = accion.PrecioActual + fluctuacionPrecio;

                    accion.VariacionPorcentual = ((accion.PrecioActual - accion.PrecioApertura) / accion.PrecioApertura) * 100m;

                    accion.VolumenTransacciones = accion.VolumenTransacciones + ((long)(fluctuacionPrecio * 50));
                }
                if (activo is Criptomoneda cripto)
                {
                    activo.PrecioActual = cripto.PrecioActual + fluctuacionPrecio;
                }
            }
        }

    }
}
