using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using CryptSharp;
using SpaceLauncher.model;
using System.Windows.Forms.VisualStyles;

namespace SpaceLauncher
{
    class conexion
    {
        //Creem la variable nom i la contrasenya.
        string nombre, contrasena;
        //creem el setters
        public void p_nombre_set(string valor)
        {
            nombre = valor;
        }
        public void p_clave_set(string valor)
        {
            contrasena = valor;
        }
        MySqlConnection conectar = new MySqlConnection("server=spacelauncher.sytes.net;database=prova_db;Uid=xavi;pwd=Admin1234");


        public Boolean mysqlLogin()
        {
            //Creem la conexio a la base de dades
            //Obrim la conexio
            try
            {
                conectar.Open();
                //Executem la comanda per agafar la contrasenya del usuaari introduit.
                MySqlCommand comandom = new MySqlCommand("Select clave from usuarios where usuario='" + nombre + "'", conectar);
                //Convertim el objecte MySqlCommand a String.
                string contrasenaEncriptada = comandom.ExecuteScalar().ToString();
                //Comprova si la contrasenya es correcte.
                bool matches = Crypter.CheckPassword(contrasena, contrasenaEncriptada);

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
            catch {
                return false;
            }
        }
        public Boolean mysqlJuego(tiempoJugado juego) {
            conectar.Open();
            MySqlCommand comandom = new MySqlCommand("INSERT INTO tiempoJugado (idUsuario , idJuego , tiempoJugado , fecha ) VALUES (" + '"' + juego.NombreUsuario + '"'+ ", " + '"' + juego.NombreJuego + '"' + ", " + '"' + juego.Tiempo + '"' + "," + '"' + juego.Fecha + '"' + ")", conectar);
            comandom.ExecuteNonQuery();
            if (true)
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

        // Consultar a la BBDD registres d'hores Jugades.
        public int tiempoJugado(tiempoJugado juego) {
            int temps=0;
            String[] tot;
            conectar.Open();
            MySqlCommand comandom = new MySqlCommand("Select tiempoJugado from tiempoJugado where idUsuario=" + '"' + juego.NombreUsuario +'"'+" and idJuego = "+'"'+juego.NombreJuego+'"' , conectar);
            MySqlDataReader read = comandom.ExecuteReader();
            string h="", m="", s="";

            while (read.Read()) {
                String total= (String.Format("{0}",read[0]));
                int i= 0;
                tot=total.Split(':');
                foreach(String tota in tot){
                    Console.WriteLine("{0}:{1}", i,tota);
                    switch(i)
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
                temps += Int32.Parse(calcularTiempo2(h, m, s));
                

            }
    
            conectar.Close();
            return temps;
            

        }

        //Funcio per a convertir hores minuts segons a nomes segons.
        private String calcularTiempo2(String h,String m,String s)

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
    }
}
