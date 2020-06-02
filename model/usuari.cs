using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpaceLauncher.model
{
    public class usuari
    {
        String usuario;
        String email;
        String clave;
        String fechaNacimiento;
        String sexo;

        //constructor registre

        /// <summary>
        /// Constructor usuario!
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="email"></param>
        /// <param name="clave"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="sexo"></param>
        public usuari(string usuario, string email, string clave, string fechaNacimiento, string sexo)
        {
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
            this.Usuario = usuario;
            this.Email = email;
            this.Clave = clave;
        }

        /// <summary>
        /// Constructor usuario!
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
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

        /// <summary>
        /// Comprovar si la contraseña cumple todos los requisitos!
        /// </summary>
        /// <param name="contraseña"></param>
        /// <returns></returns>
        public Boolean contraseñaValida(String contraseña)
        {

            try
            {
                if (contraseña.Length >= 6)
                {
                    bool containsUpperCase = contraseña.Any(char.IsUpper);

                    if (containsUpperCase)
                    {
                        bool containsLowerCase = contraseña.Any(char.IsLower);
                        if (containsLowerCase)
                        {
                            bool containsNumber = contraseña.Any(char.IsDigit);
                            if (containsNumber)
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

            catch
            {
                return false;
            }

        }
        //comprovar si esta en format email.

        /// <summary>
        /// Funcion para comprovar si el formato es formato email.
        /// </summary>
        /// <param name="seMailAComprobar"></param>
        /// <returns></returns>
        public bool ComprobarFormatoEmail(string seMailAComprobar)
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
