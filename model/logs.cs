using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Diagnostics;
using Twilio.Rest.Video.V1.Room.Participant;
using Microsoft.VisualBasic.Logging;

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

        public logs(string fecha,string hora, string error, int code)
        {
            this.fecha = fecha;
            this.hora = hora;
            this.error = error;
            this.code = code;
        }
        public logs()
        {

        }

        public static void Save(string error, int codeError)
        {
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string fecha = System.DateTime.Now.ToString("yyyy-MM-dd");
            string path = Directory.GetCurrentDirectory() + "\\" + "logs" + "\\" + "logs.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(fecha+" - "+hora+" - "+codeError+" - "+error);
                    sw.Close();
                }
            }
            else {
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
        public List<logs> leer() {
            string fecha = System.DateTime.Now.ToString("yyyy-MM-dd");
            List<logs> logErrors= new List<logs>();
            logs log;
            string path = Directory.GetCurrentDirectory() + "\\" + "logs" + "\\" +  "logs.txt";
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            string s;
            using (StreamReader sr = File.OpenText(path))
            {
                int i= 0;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] parts = s.Split('-');
                        log = new logs(parts[0], parts[1], parts[2],int.Parse(parts[3]));
                        logErrors.Add(log);
                    

                    i++;

                }
                file.Close();

            }
            return logErrors;
            
        }

    }

}


