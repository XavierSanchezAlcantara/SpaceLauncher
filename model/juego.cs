using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLauncher.model
{
    public class juego
    {
        int idJuego;
        string nombreJuego;
        /// <summary>
        /// Constructor juego!
        /// </summary>
        /// <param name="idJuego"></param>
        /// <param name="nombreJuego"></param>
        public juego(int idJuego, string nombreJuego)
        {
            this.idJuego = idJuego;
            this.nombreJuego = nombreJuego;
        }

        public int IdJuego { get => idJuego; set => idJuego = value; }
        public string NombreJuego { get => nombreJuego; set => nombreJuego = value; }
    }
}
