using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpaceLauncher.model
{
    class usuari
    {
        String usuario;
        String email;
        String clave;
        String fechaNacimiento;
        String sexo;

        //constructor registre
        public usuari(string usuario, string email, string clave, string fechaNacimiento, string sexo) 
        {
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
            this.Usuario = usuario;
            this.Email = email;
            this.Clave = clave;
        }

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
        public string Sexo { get => sexo; set => sexo = value; }
        public string FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

        public Boolean contraseñaValida(String contraseña) {

            try
            {
                if (contraseña.Length >= 6)
                {
                    return true;
                }
                else {
                    return false;
                }
                
            
            }

            catch {
                return false;
            }

        }
        //comprovar si esta en format email.
        public  bool ComprobarFormatoEmail(string seMailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(seMailAComprobar, sFormato))
            {
                if (Regex.Replace(seMailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
