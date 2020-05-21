using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using SpaceLauncher.model;
using Ubiety.Dns.Core.Records;
using Microsoft.VisualBasic.ApplicationServices;
using Infragistics.Win.DataVisualization;

namespace SpaceLauncher
{
    public partial class FormPrincipal : Form
    {
        //Importem els DLL per poder moure el programa com nosaltres volguem.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        conexion con = new conexion();

        public FormPrincipal()
        {
            InitializeComponent();
            labelhoras();



        }
        public FormPrincipal(String user)
        {
            InitializeComponent();
            usuario.Text = user;
            labelhoras();



        }
        //Definim les accions al clicar el boto de tancar.
        private void btncerrar_Click(object sender, EventArgs e)
        {
            //Tancar aplicacio.
            Application.Exit();
        }
        //Definim les accions al clicar el boto de minimitzar.
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            //Minimitzem pantalla
            this.WindowState = FormWindowState.Minimized;

        }
        //Definimos las cosas que se tienen que cargar al iniciar este formulario.
        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        //Definim que si es pulsa a la part superior de la finestra es pugui moure.
        private void top_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        //Accio al clicar al boto ....., fa que el tab canvi per a  que es vegi el desitjat.
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = news;
        }
        //Accio al clicar al boto ....., fa que el tab canvi per a  que es vegi el desitjat.
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game1;

        }
        //Accio al clicar al boto ....., fa que el tab canvi per a  que es vegi el desitjat.
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game2;
          

        }



        //Accio al clicar el boto de tencar sessio.
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            form.Show();
            this.Hide();
        }


        public void jugar(string game)
        {
            //Creem un string on indiqui el directori actual.

            string path = Directory.GetCurrentDirectory();
            int idproc = 0;

            // Creem el process per iniciar el joc.

            Process p = new Process();

            // Creem la informacio per iniciar el process.

            ProcessStartInfo PSI = new System.Diagnostics.ProcessStartInfo();

            //Declarem el executable que volem que s'executi.

            PSI.FileName = game + ".exe";

            //Declarem el  Directori on es troba el executable.

            PSI.WorkingDirectory = path + "\\" + game + "\\";

            //Amaguem el launcher.
            this.WindowState = FormWindowState.Minimized;

            //Declarem al proces que la informacio que te que tractar es la declarada anteriorment.

            p.StartInfo = PSI;

            //executem el process.

            p.Start();

            //Esperem 5 segons per poder donar temps a que el joc s'inici.

            System.Threading.Thread.Sleep(5000);

            //Creem un array amb tots el processos que hi hagi actius en aquell moment.

            Process[] procesos;
            procesos = Process.GetProcesses();

            //Fem recorrem l'array y quant trobem el process que en interesa guardem el seu pid.

            foreach (Process pro in procesos)
            {
                //Console.WriteLine(pro.ProcessName);
                if (pro.ProcessName == "javaw")
                {
                    Console.WriteLine(pro.ProcessName + " id :" + pro.Id);
                    //Process p2 = Process.GetProcessById(pro.Id);
                    idproc = pro.Id;
                }
            }

            //Declarem un altre process on li diem que el seu pid es el que anteriorment hem guardat.
            Process p2 = new Process();
            p2 = Process.GetProcessById(idproc);

            //Creem un while que no surti fins que el joc es tanqui.

            while (p2.HasExited == false)
            {
                //Console.WriteLine(p2.HasExited);
            }

            // Agafem la diferencia entre quant s'ha creat el process fins que el joc s'ha tancat amb un timespan.
            //Pasem el timespan a segons i ho pasem a int per poder pasar-ho a calcularTiempo().

            TimeSpan ts = p2.StartTime - DateTime.Now;
            Console.WriteLine(CalcularTiempo((int)ts.TotalSeconds));

            tiempoJugado tempsJugat = new tiempoJugado(game, usuario.Text, CalcularTiempo((int)ts.TotalSeconds), DateTime.Now);
            conexion con = new conexion();

            con.mysqlJuego(tempsJugat);
            labelhoras();
            Form.ActiveForm.Show();


        }




        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                jugar("JuegoBeta");
            }
            catch (Exception ex) {
                logs.Save(this, ex);
            }
        }
        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                jugar("wegi");
            }
            catch (Exception ex)
            {
                logs.Save(this, ex);
            }
        }
        //Cargar las horas jugadas a cada juego
        private void labelhoras(){
            tiempoJugado wegi = new tiempoJugado("wegi", usuario.Text);
            tiempoJugado JuegoBeta = new tiempoJugado("JuegoBeta", usuario.Text);
            tiempoJugadoWegi.Text = "Tiempo Jugado: " + CalcularTiempo(con.tiempoJugado(wegi));
            tiempoJugadoJuegoBeta.Text = "Tiempo Jugado: " + CalcularTiempo(con.tiempoJugado(JuegoBeta));
        }
        //Creu una clase per poder saber quant temps he estat jugant.
        private String CalcularTiempo(Int32 tsegundos)
        {
            Int32 horas = Math.Abs((tsegundos / 3600));
            Int32 minutos = Math.Abs(((tsegundos - horas * 3600) / 60));
            Int32 segundos = Math.Abs(tsegundos - (horas * 3600 + minutos * 60));
            return horas.ToString() + ":" + minutos.ToString() + ":" + segundos.ToString();
        }

    }
}