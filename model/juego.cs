using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLauncher.model
{
    class juego
    {
        int idJuego;
        string nombreJuego;

        public juego(int idJuego, string nombreJuego)
        {
            this.idJuego = idJuego;
            this.nombreJuego = nombreJuego;
        }

        public int IdJuego { get => idJuego; set => idJuego = value; }
        public string NombreJuego { get => nombreJuego; set => nombreJuego = value; }
    }
}
