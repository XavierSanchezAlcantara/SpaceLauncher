using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLauncher.model
{
    class tiempoJugado
    {
        String nombreJuego;
        String nombreUsuario;
        String tiempo;
        DateTime fecha;

        public tiempoJugado(String nombreJuego, string idUsuario, String tiempo, DateTime fecha)
        {
            this.nombreJuego = nombreJuego;
            this.nombreUsuario = idUsuario;
            this.tiempo = tiempo;
            this.fecha = DateTime.Now;
        }
        public tiempoJugado()
        {
        }
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
        public String CalcularTiempo(Int32 tsegundos)
        {
            Int32 horas = Math.Abs((tsegundos / 3600));
            Int32 minutos = Math.Abs(((tsegundos - horas * 3600) / 60));
            Int32 segundos = Math.Abs(tsegundos - (horas * 3600 + minutos * 60));
            return horas.ToString() + ":" + minutos.ToString() + ":" + segundos.ToString();
        }
    }
}
