using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Twilio.Rest.Video.V1.Room.Participant;

namespace SpaceLauncher.model
{
    class logs
    {
        string hora;
        string error;
        string fecha;
        int code;

        public string Hora { get => hora; set => hora = value; }
        public string Error { get => error; set => error = value; }
        public int Code { get => code; set => code = value; }
        public string Fecha { get => fecha; set => fecha = value; }

        /// <summary>
        /// Constructor logs!
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <param name="error"></param>
        /// <param name="code"></param>
        public logs(string fecha, string hora, string error, int code)
        {
            this.fecha = fecha;
            this.hora = hora;
            this.error = error;
            this.code = code;
        }
        public logs()
        {

        }
        /// <summary>
        /// Metodo para crear y editar el archivo logs!
        /// </summary>
        /// <param name="error"></param>
        /// <param name="codeError"></param>
        public static void Save(string error, int codeError)
        {
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string fecha = System.DateTime.Now.ToString("dd/MM/yyyy");
            string path = Directory.GetCurrentDirectory() + "\\" + "logs" + "\\" + "logs.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(fecha + " - " + hora + " - " + codeError + " - " + error);
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(fecha + " - " + hora + " - " + codeError + " - " + error);
                    sw.Close();

                }

            }

            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        /// <summary>
        /// Funcion para leer todos los logs!
        /// </summary>
        /// <returns></returns>
        public List<logs> leer()
        {
            List<logs> logErrors = new List<logs>();
            logs log;
            string path = Directory.GetCurrentDirectory() + "\\" + "logs" + "\\" + "logs.txt";
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string s;
            using (StreamReader sr = File.OpenText(path))
            {
                int i = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] parts = s.Split('-');
                    log = new logs(parts[0], parts[1], parts[3], int.Parse(parts[2]));
                    logErrors.Add(log);



                }
                file.Close();

            }
            return logErrors;

        }
        /// <summary>
        /// Funcion para guardar errores segun string
        /// </summary>
        /// <param name="logBuscador"></param>
        /// <returns></returns>
        public List<logs> leerConString(string logBuscador)
        {
            List<logs> logErrors = new List<logs>();
            logs log;
            string path = Directory.GetCurrentDirectory() + "\\" + "logs" + "\\" + "logs.txt";
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string s;
            using (StreamReader sr = File.OpenText(path))
            {
                int i = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] parts = s.Split('-');
                    log = new logs(parts[0], parts[1], parts[3], int.Parse(parts[2]));

                    if (parts[3].ToString().Contains(logBuscador))
                    {
                        logErrors.Add(log);
                    }


                }
                file.Close();

            }
            return logErrors;

        }

    }

}



