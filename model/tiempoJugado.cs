using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLauncher.model
{
    public class tiempoJugado
    {
        String nombreJuego;
        String nombreUsuario;
        String tiempo;
        DateTime fecha;
        /// <summary>
        /// Constructor tiempoJugado!
        /// </summary>
        /// <param name="nombreJuego"></param>
        /// <param name="idUsuario"></param>
        /// <param name="tiempo"></param>
        /// <param name="fecha"></param>
        public tiempoJugado(String nombreJuego, string idUsuario, String tiempo, DateTime fecha)
        {
            this.nombreJuego = nombreJuego;
            this.nombreUsuario = idUsuario;
            this.tiempo = tiempo;
            this.fecha = DateTime.Now;
        }
        /// <summary>
        /// Constructor tiempoJugado
        /// </summary>
        public tiempoJugado()
        {
        }

        /// <summary>
        /// Constructor tiempoJugado
        /// </summary>
        /// <param name="nombreJuego"></param>
        /// <param name="idUsuario"></param>
        public tiempoJugado(String nombreJuego, string idUsuario)
        {
            this.nombreJuego = nombreJuego;
            this.nombreUsuario = idUsuario;
        }

        //Getters && Setters
        public String NombreJuego { get => nombreJuego; set => nombreJuego = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Tiempo { get => tiempo; set => tiempo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }

        //Funcio per a convertir hores minuts segons a nomes segons.

        /// <summary>
        /// Metodo para calcular tiempo en segundos!
        /// </summary>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public String calcularTiempo2(String h, String m, String s)
        {
            int hh, mm, t;
            int h2, m2, s2;
            h2 = Int32.Parse(h);
            m2 = Int32.Parse(m);
            s2 = Int32.Parse(s);
            hh = h2 * 3600;
            mm = m2 * 60;
            t = hh + mm + s2;
            Console.WriteLine(t.ToString());
            return t.ToString();
        }

        //Creem una clase per poder saber quant temps he estat jugant.

        /// <summary>
        /// Metodo para calcular de segundos a horas, minutos y segundos!
        /// </summary>
        /// <param name="tsegundos"></param>
        /// <returns></returns>
        public String CalcularTiempo(Int32 tsegundos)
        {
            Int32 horas = Math.Abs((tsegundos / 3600));
            Int32 minutos = Math.Abs(((tsegundos - horas * 3600) / 60));
            Int32 segundos = Math.Abs(tsegundos - (horas * 3600 + minutos * 60));
            return horas.ToString() + ":" + minutos.ToString() + ":" + segundos.ToString();
        }
    }
}
