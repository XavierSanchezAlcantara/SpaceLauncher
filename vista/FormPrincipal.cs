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
using System.Text.RegularExpressions;
using SpaceLauncher.vista;

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
        private tiempoJugado tJugat= new tiempoJugado();


        public FormPrincipal(String user)
        {
            InitializeComponent();
            usuario.Text = user;
            dateNeixament.CustomFormat = "yyyy-M-dd";
            labelhoras();



        }

        //////////////////////////////////////////
        ///               textBox
        //////////////////////////////////////////


        //text Box buidar 

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA(*)")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = true;

            }
        }

        // Accio al sortir del text box sortir.

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA(*)";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;

            }
        }

        //text Box buidar 

        private void txtNewEmail_Enter(object sender, EventArgs e)
        {
            if (txtNewEmail.Text == "EMAIL")
            {
                txtNewEmail.Text = "";
                txtNewEmail.ForeColor = Color.DimGray;
                txtNewEmail.UseSystemPasswordChar = false;

            }

        }

        // Accio al sortir del text box sortir.

        private void txtNewEmail_Leave(object sender, EventArgs e)
        {
            if (txtNewEmail.Text == "")
            {
                txtNewEmail.Text = "EMAIL";
                txtNewEmail.ForeColor = Color.DimGray;
                txtNewEmail.UseSystemPasswordChar = false;

            }
        }

        //text Box buidar 

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "CONTRASEÑA(*)")
            {
                txtNewPass.Text = "";
                txtNewPass.ForeColor = Color.DimGray;
                txtNewPass.UseSystemPasswordChar = true;
            }
        }

        // Accio al sortir del text box sortir.

        private void txtNewPass_Leave(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "")
            {
                txtNewPass.Text = "CONTRASEÑA(*)";
                txtNewPass.ForeColor = Color.DimGray;
                txtNewPass.UseSystemPasswordChar = false;
            }
        }


        //////////////////////////////////////////
        ///               Carregar Dades
        //////////////////////////////////////////

        //Carregar les hores jugades de cada joc!!!
        private void labelhoras()
        {
            //carregar taula buscadorjoc!!!
            try
            {
                buscadortabla.Rows.Clear();
                foreach (juego juegos in con.guardarEnTabla("juegos"))
                {
                    buscadortabla.Rows.Add(new object[] { juegos.NombreJuego, juegos.IdJuego });
                }

                tiempoJugado JuegoBeta = new tiempoJugado("JuegoBeta", usuario.Text);
                tiempoJugado jocPDE = new tiempoJugado("joc_pde", usuario.Text);
                tiempoJugado arquer = new tiempoJugado("arquer", usuario.Text);
                tiempoJugado wegi = new tiempoJugado("wegi", usuario.Text);

                int tiempoWegi = con.tiempoJugado(wegi);
                int tiempoJuegoBeta = con.tiempoJugado(JuegoBeta);
                int tiempoJuegoPDE = con.tiempoJugado(jocPDE);
                int tiempoArquer = con.tiempoJugado(arquer);

                tiempoJugadoJuegoBeta.Text = "Tiempo Jugado: " + tJugat.CalcularTiempo(tiempoJuegoBeta);
                tiempoJugadoJocPDE.Text = "Tiempo Jugado: " + tJugat.CalcularTiempo(tiempoJuegoPDE);
                tiempoJugadoArquer.Text = "Tiempo Jugado: " + tJugat.CalcularTiempo(tiempoArquer);
                tiempoJugadoWegi.Text = "Tiempo Jugado: " + tJugat.CalcularTiempo(tiempoWegi);


                lblTotalJugado.Text = tJugat.CalcularTiempo(con.tiempoJugadototal(usuario.Text));
                lblUser.Text = usuario.Text;
                txtEmail.Text = con.mysqlEmail(usuario.Text);
                sexe.Text = con.mysqlSexe(usuario.Text);
                dateNeixament.Text = con.mysqlFechaNacimiento(usuario.Text);

            }
            catch
            {
                logs.Save("Error en cargar labels!!",130);
            }
        }

        //////////////////////////////////////////
        ///  Accions per a poder moure la pantalla
        //////////////////////////////////////////

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


        //////////////////////////////////////////
        ///               Botons
        //////////////////////////////////////////
       

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
        //boto pagina principal
        private void buttonNews_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = principal;

        }
        //boto pestaña buscador
        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = buscador;
        }

        //boto pestaña game1
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game1;

        }
        //boto pestaña game2
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game2;

        }
        //boto pestaña game3

        private void bunifuFlatButton3_Click_1(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game3;
        }

        //boto pestaña game4

        private void bunifuFlatButton2_Click_2(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game4;
        }

        //boto pestaña perfil

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = news;
        }

        //Accio al clicar imatge joc1

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game1;

        }
        //Accio al clicar imatge joc2

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game2;

        }

        //Accio al clicar imatge joc3

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game3;

        }

        //Accio al clicar imatge joc4

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.tabControl.SelectedTab = game4;
        }


        //Accio al clicar el boto de tencar sessio.
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            form.Show();
            this.Hide();
        }


        //Boto per iniciar joc

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                jugar("wegi");


            }
            catch (Exception ex)
            {
                logs.Save("Error al intentar Jugar!!", 120);
            }
        }

        //botons iniciar joc 

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                jugar("JuegoBeta");

            }
            catch (Exception ex)
            {
                logs.Save("Error al intentar Jugar!!", 120);
            }
        }

        //Boto per iniciar joc

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            try
            {
                jugar("joc_pde");

            }
            catch (Exception ex)
            {
                logs.Save("Error al intentar Jugar!!", 120);
            }
        }

        //Boto per iniciar joc

        private void bunifuFlatButton3_Click_2(object sender, EventArgs e)
        {
            try
            {
                jugar("arquer");

            }
            catch (Exception ex)
            {
                logs.Save("Error al intentar Jugar!!", 120);
            }
        }

        // Accions al buscar Joc

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                buscadortabla.Rows.Clear();
                foreach (juego juegos in con.guardarEnTablaBuscar(buscadortxt.Text))
                {
                    buscadortabla.Rows.Add(new object[] { juegos.NombreJuego, juegos.IdJuego });
                }
            }
            catch
            {
                logs.Save("Error al cargar datos a dataGridView!", 160);
            }
        }

        //Accions al donar doble click al resultat de buscar jocs

        private void buscadortabla_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string posicionIdJuego;
            int numero;
            if (buscadortabla.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && e.RowIndex >= 0)
            {
                buscadortabla.CurrentCell.Selected = true;
                posicionIdJuego = buscadortabla.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                numero = int.Parse(posicionIdJuego);
                if (numero == 1)
                {
                    this.tabControl.SelectedTab = game1;

                }
                else if (numero == 2)
                {
                    this.tabControl.SelectedTab = game2;

                }
                else if (numero == 3)
                {
                    this.tabControl.SelectedTab = game3;

                }
                else if (numero == 4)
                {
                    this.tabControl.SelectedTab = game4;

                }
                else
                {
                    logs.Save("Error Juego no encontrado!!", 170);
                }
            }

        }

        //Entrar al form logs

        private void button2_Click(object sender, EventArgs e)
        {
            formLogs form = new formLogs();
            form.Show();
        }

        //Accions al clicar al boto editar perfil

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexion con = new conexion();
                usuari user = new usuari(usuario.Text,  txtEmail.Text , txtpass.Text, dateNeixament.Text,sexe.Text);
                Boolean prova = con.mysqlLogin(user);
                Boolean updated;
                if (prova)
                {
                        if (txtNewPass.Text!= "CONTRASEÑA(*)" &&user.contraseñaValida(txtNewPass.Text))
                        {
                            user.Clave = txtNewPass.Text;
                            if (txtNewEmail.Text != "EMAIL")
                            {
                                user.Email = txtNewEmail.Text;
                                if (user.ComprobarFormatoEmail(user.Email))
                                {
                                    updated = con.mysqlUpdateUser(user);
                                    if (updated)
                                    {
                                        txtErrorUpdate.Text = "Datos Actualizados!!";
                                        System.Threading.Thread.Sleep(2000);
                                        this.Hide();
                                        FormPrincipal form = new FormPrincipal(user.Usuario);
                                        form.Show();

                                    }
                                    else
                                    {
                                        txtErrorUpdate.Text = "Error al modificar los datos. Intentelo mas tarde!!";
                                        logs.Save("Error al modificar Datos. Imposible conectar con la BBDD!!", 140);
                                    }
                                }
                                else
                                {
                                    txtErrorUpdate.Text = "Introduce una direccion electronica Valida!!";
                                }
                            }
                            else
                            {

                                updated = con.mysqlUpdateUser(user);
                                if (updated)
                                {
                                    txtErrorUpdate.Text = "Datos Actualizados!!";
                                    System.Threading.Thread.Sleep(2000);
                                    this.Hide();
                                    FormPrincipal form = new FormPrincipal(user.Usuario);
                                    form.Show();

                                }
                                else
                                {
                                    txtErrorUpdate.Text = "Error al modificar los datos. Intentelo mas tarde!!";
                                    logs.Save("Error al modificar Datos. Imposible conectar con la BBDD!!", 500);
                                }
                            }
                        }
                        else
                        {
                            txtErrorUpdate.Text = "Contraseña introducida no valida.!";
                        }
   
                }
                else
                {
                    txtErrorUpdate.Text = "Contraseña actual incorrecta!!";
                }
            }
            catch
            {
                logs.Save("Error al modificar usuario!", 100);
            }

        }





        //clase jugar
        
        public void jugar(string game)
        {
            try
            {
                
                //Creem un string on indiqui el directori actual on esta colocat el executable..
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
                this.Hide();

                //Esperem 2 segons per poder donar temps a que el joc s'inici.

                System.Threading.Thread.Sleep(2000);

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
                DateTime inici = DateTime.Now;
                //Creem un while que no surti fins que el joc es tanqui.

                while (p2.HasExited == false)
                {
                    //Console.WriteLine(p2.HasExited);

                }

                // Agafem la diferencia entre quant s'ha creat el process fins que el joc s'ha tancat amb un timespan.
                //Pasem el timespan a segons i ho pasem a int per poder pasar-ho a calcularTiempo().
                TimeSpan ts = inici - DateTime.Now;


                tiempoJugado tempsJugat = new tiempoJugado(game, usuario.Text, tJugat.CalcularTiempo((int)ts.TotalSeconds), DateTime.Now);
                conexion con = new conexion();


                // Enviem el objecte tempsJugat per a que s'insereixi a la BBDD
                con.mysqlJuego(tempsJugat);
                FormPrincipal form = new FormPrincipal(usuario.Text);
                form.Show();



            }
            catch
            {
                logs.Save("Error en la clase jugar!",150);
            }

        }
    }
}
