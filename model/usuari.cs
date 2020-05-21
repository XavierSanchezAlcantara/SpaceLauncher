using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLauncher.model
{
    class usuari
    {
        String usuario;
        String email;
        String clave;

       

        public usuari(string usuario, string email, string clave)
        {
            this.usuario = usuario;
            this.email = email;
            this.clave = clave;
        }

        public usuari(string usuario, string clave)
        {
            this.usuario = usuario;
            this.clave = clave;
        }
        //getters && setters

        public string Usuario { get => usuario; set => usuario = value; }
        public string Email { get => email; set => email = value; }
        public string Clave { get => clave; set => clave = value; }
        

        
    }
}
