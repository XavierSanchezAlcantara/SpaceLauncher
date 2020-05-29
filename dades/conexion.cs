using CryptSharp;
using Magnum.Extensions;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using SpaceLauncher.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SpaceLauncher
{
    class conexion
    {
        //Creem la variable nom i la contrasenya.
        //creem el setters
        tiempoJugado tiempoJugados = new tiempoJugado();
        MySqlConnection conectar = new MySqlConnection("server=spacelauncher.sytes.net;database=prova_db;Uid=xavi;pwd=Admin1234");

        /// <summary>
        /// Registrar usuario!
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Boolean mysqlRegister(usuari user)
        {
            try
            {
                conectar.Open();
                string passEncriptado = Crypter.Phpass.Crypt(user.Clave);
                MySqlCommand comandom = new MySqlCommand("INSERT INTO usuarios (usuario , email, clave,sexo,fechaNacimiento) VALUES (" + '"' + user.Usuario + '"' + ", " + '"' +
                    user.Email + '"' + ", " + '"' + passEncriptado + '"' + ", " + '"' + user.Sexo + '"' + ", " + '"' + user.FechaNacimiento + '"' + ")", conectar);
                comandom.ExecuteNonQuery();
                if (true)
                {
                    //Si s'inserta correctament
                    conectar.Close();
                    //tanquem conexio a la bbdd
                    return true;

                }

            }
            catch (Exception ex)
            {
                conectar.Close();

                logs.Save("Error al Insertar nuevoUsuario!", 20);
                return false;
            }
        }

        /// <summary>
        /// Consultar Email de usuario!
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public String mysqlEmail(string usuario)
        {
            try
            {
                conectar.Open();
                //Executem la comanda per agafar la contrasenya del usuaari introduit.
                MySqlCommand comandom = new MySqlCommand("Select email from usuarios where usuario='" + usuario + "'", conectar);
                //Convertim el objecte MySqlCommand a String.
                string resultado = comandom.ExecuteScalar().ToString();
                conectar.Close();

                return resultado;
            }
            catch
            {
                conectar.Close();

                logs.Save("Error al consultar el email en la BBDD!", 30);

                return "";
            }


        }
        /// <summary>
        /// Consultar sexo Usuario!
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public String mysqlSexe(string usuario)
        {
            try
            {
                conectar.Open();
                //Executem la comanda per agafar la contrasenya del usuaari introduit.
                MySqlCommand comandom = new MySqlCommand("Select sexo from usuarios where usuario='" + usuario + "'", conectar);
                //Convertim el objecte MySqlCommand a String.
                string resultado = comandom.ExecuteScalar().ToString();
                conectar.Close();

                return resultado;
            }
            catch
            {
                conectar.Close();

                logs.Save("Error al consultar el sexo en la BBDD!", 60);

                return "";
            }


        }

        /// <summary>
        /// Consultar FechaNacimiento de un usuario!
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public String mysqlFechaNacimiento(string usuario)
        {
            try
            {
                conectar.Open();
                //Executem la comanda per agafar la contrasenya del usuaari introduit.
                MySqlCommand comandom = new MySqlCommand("Select fechaNacimiento from usuarios where usuario='" + usuario + "'", conectar);
                //Convertim el objecte MySqlCommand a String.
                string resultado = comandom.ExecuteScalar().ToString();
                conectar.Close();

                return resultado;
            }
            catch
            {
                conectar.Close();

                logs.Save("Error al consultar el fechaNacimiento en la BBDD!", 40);

                return "";
            }


        }

        /// <summary>
        /// Comprovar si las credenciales del usuario son correctas!
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Boolean mysqlLogin(usuari user)
        {
            //Creem la conexio a la base de dades
            //Obrim la conexio
            try
            {
                conectar.Open();
                //Executem la comanda per agafar la contrasenya del usuari introduit.
                MySqlCommand comandom = new MySqlCommand("Select clave from usuarios where usuario='" + user.Usuario + "'", conectar);
                //Convertim el objecte MySqlCommand a String.
                string contrasenaEncriptada = comandom.ExecuteScalar().ToString();
                //Comprova si la contrasenya es correcte.
                bool matches = Crypter.CheckPassword(user.Clave, contrasenaEncriptada);

                if (matches)
                {
                    //Si la contrasenya es correcte.
                    conectar.Close();
                    //tanquem conexio a la bbdd
                    return true;

                }
                else
                {
                    //Si la contrasenya es incorrecte.
                    conectar.Close();
                    //tanquem conexio a la bbdd
                    return false;
                }
            }
            catch
            {
                conectar.Close();

                logs.Save("Error al consultar datos login en la BBDD!", 10);
                return false;
            }
        }
        /// <summary>
        /// Insertar tiempo jugado a un juego!
        /// </summary>
        /// <param name="juego"></param>
        /// <returns></returns>
        public Boolean mysqlJuego(tiempoJugado juego)
        {
            try
            {
                conectar.Open();
                MySqlCommand comandom = new MySqlCommand("INSERT INTO tiempoJugado (idUsuario , idJuego , tiempoJugado , fecha ) VALUES (" + '"' + juego.NombreUsuario + '"' + ", " + '"' + juego.NombreJuego + '"' + ", " + '"' + juego.Tiempo + '"' + "," + '"' + juego.Fecha + '"' + ")", conectar);
                int comando = comandom.ExecuteNonQuery();
                if (comando != 0)
                {
                    //Si s'inserta correctament
                    conectar.Close();
                    //tanquem conexio a la bbdd
                    return true;

                }
                else
                {
                    //Si no s'inserta correctament.
                    conectar.Close();
                    //tanquem conexio a la bbdd
                    return false;
                }
            }
            catch
            {
                conectar.Close();
                logs.Save("Error al insertar tiempoJugado!!", 70);
                return false;
            }
        }


        // Consultar a la BBDD registres d'hores Jugades.

        /// <summary>
        /// Consultar timepoJugado!
        /// </summary>
        /// <param name="juego"></param>
        /// <returns></returns>
        public int tiempoJugado(tiempoJugado juego)
        {
            int temps = 0;
            try
            {

                String[] tot;
                conectar.Open();
                MySqlCommand comandom = new MySqlCommand("Select tiempoJugado from tiempoJugado where idUsuario=" + '"' + juego.NombreUsuario + '"' + " and idJuego = " + '"' + juego.NombreJuego + '"', conectar);
                MySqlDataReader read = comandom.ExecuteReader();
                string h = "", m = "", s = "";

                while (read.Read())
                {
                    String total = (String.Format("{0}", read[0]));
                    int i = 0;
                    tot = total.Split(':');
                    foreach (String tota in tot)
                    {
                        Console.WriteLine("{0}:{1}", i, tota);
                        switch (i)
                        {
                            case 0:
                                h = tota;
                                break;
                            case 1:
                                m = tota;
                                break;
                            case 2:
                                s = tota;
                                break;
                            default:
                                Console.WriteLine("Error");
                                break;
                        }
                        i++;

                    }
                    temps += Int32.Parse(tiempoJugados.calcularTiempo2(h, m, s));


                }

                conectar.Close();
                return temps;
            }
            catch
            {
                conectar.Close();
                logs.Save("Error al consultar tiempoJugado!", 80);
                return temps;


            }

        }
        /// <summary>
        /// Consultar tiempoJugadoTotal!
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public int tiempoJugadototal(string usuario)
        {
            try
            {
                int temps = 0;
                String[] tot;
                conectar.Open();
                MySqlCommand comandom = new MySqlCommand("Select tiempoJugado from tiempoJugado where idUsuario = " + '"' + usuario + '"', conectar);
                MySqlDataReader read = comandom.ExecuteReader();
                string h = "", m = "", s = "";

                while (read.Read())
                {
                    String total = (String.Format("{0}", read[0]));
                    int i = 0;
                    tot = total.Split(':');
                    foreach (String tota in tot)
                    {
                        Console.WriteLine("{0}:{1}", i, tota);
                        switch (i)
                        {
                            case 0:
                                h = tota;
                                break;
                            case 1:
                                m = tota;
                                break;
                            case 2:
                                s = tota;
                                break;
                            default:

                                break;
                        }
                        i++;

                    }
                    temps += Int32.Parse(tiempoJugados.calcularTiempo2(h, m, s));


                }

                conectar.Close();
                return temps;
            }
            catch (Exception ex)
            {
                conectar.Close();

                logs.Save("Error al consultar tiempoJugadoTotal!", 90);

                return 0;
            }

        }
        /// <summary>
        /// Editar Usuario.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Boolean mysqlUpdateUser(usuari user)
        {
            try
            {
                conectar.Open();
                string passEncriptado = Crypter.MD5.Crypt(user.Clave);
                MySqlCommand comandom = new MySqlCommand("UPDATE usuarios SET email =" + "'" + user.Email + "'" + ", clave = " + "'" + passEncriptado + "'" + ", sexo = " + "'" + user.Sexo + "'" + ", fechaNacimiento = " + "'" + user.FechaNacimiento + "'" + " WHERE usuario = " + "'" + user.Usuario + "'", conectar);
                comandom.ExecuteNonQuery();
                if (true)
                {
                    //Si es fa l'update correctament correctament
                    conectar.Close();
                    //tanquem conexio a la bbdd
                    return true;

                }


            }
            catch (Exception ex)
            {
                conectar.Close();

                logs.Save("Error al modificar usuario!", 100);
                return false;
            }
        }


        //////////////////////////////////////////
        ///               Consultar juegos tabla
        //////////////////////////////////////////

        /// <summary>
        /// Consultar Juegos a partir de string!
        /// </summary>
        /// <param name="juego"></param>
        /// <returns></returns>

        public List<juego> guardarEnTablaBuscar(string juego)
        {
            List<juego> juegosGuardar = new List<juego>();
            juego juegos;
            try
            {
                conectar.Open();
                MySqlCommand comandom = new MySqlCommand("Select * from juegos where nombreJuego like '%" + juego + "%'", conectar);
                MySqlDataReader comando = comandom.ExecuteReader();
                while (comando.Read())
                {

                    juegos = new juego((int)comando[0], (String)comando[1]);
                    juegosGuardar.Add(juegos);
                }
                conectar.Close();

                return juegosGuardar;

            }
            catch
            {
                conectar.Close();

                logs.Save("Error Al consultar juegos!!!", 110);
            }
            conectar.Close();

            return juegosGuardar;

        }

        /// <summary>
        /// Guardar todos los juegos en la tabla!
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <returns></returns>
        public List<juego> guardarEnTabla(string nombreTabla)
        {
            List<juego> juegosGuardar = new List<juego>();
            juego juegos;
            try
            {
                conectar.Open();
                MySqlCommand comandom = new MySqlCommand("Select * from " + nombreTabla, conectar);
                MySqlDataReader comando = comandom.ExecuteReader();
                while (comando.Read())
                {
                    juegos = new juego((int)comando[0], (String)comando[1]);
                    juegosGuardar.Add(juegos);
                }
                conectar.Close();

                return juegosGuardar;

            }
            catch
            {
                logs.Save("Error Al consultar juegos!!!", 110);
                conectar.Close();

            }
            conectar.Close();

            return juegosGuardar;

        }



    }
}
