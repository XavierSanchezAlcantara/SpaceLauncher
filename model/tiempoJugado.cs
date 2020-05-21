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
    }
}
