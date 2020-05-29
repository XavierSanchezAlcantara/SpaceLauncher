using CryptSharp;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using SpaceLauncher.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text;
using System.Windows.Forms;

namespace SpaceLauncher
{
    public partial class FormLogin : Form
    {
        //Importem els DLL per poder moure el programa com nosaltres volguem.


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormLogin()
        {
            try
            {
                string path = Directory.GetCurrentDirectory() + "\\" + "icon" + "\\" + "icon.ico";
                Icon icon = new Icon(path);
                this.Icon = icon;
            }
            catch
            {
                logs.Save("Error al importar icono aplicacion!", 180);
            }
            InitializeComponent();
        }
        //Definim que a l'entrar a usuario es buidi

        /// <summary>
        /// Vaciar textBox cuando el usuario entre en ella!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }
        //Definim que si sortim del Usuario i està buit, es torni a veure Usuario.

        /// <summary>
        /// Llenar textbox si el usuario sale sin hacer nada dentro!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        //Definim que a l'entrar a contrasenya es buidi, també definim que es vegi en forma de password

        /// <summary>
        /// Vaciar textBox cuando el usuario entre en ella!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtpass_Enter(object sender,
            EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        //Definim que si sortim del Contraseña i està buit, es torni a veure Contraseña.
        /// <summary>
        /// Llenar textbox si el usuario sale sin hacer nada dentro!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;

            }
        }
        //Boto Clicar.

        /// <summary>
        /// Boton cerrar Programa!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Boto minimitzar.

        /// <summary>
        /// Boton minimizar Programa!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Codi per poder moure la finestra com nosaltres volguem.
        
        /// <summary>
        /// Accion para poder mover la ventana!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Codi per poder moure la finestra com nosaltres volguem.

        /// <summary>
        /// Accion para poder mover la ventana!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Accions al clicar el boto login.

        /// <summary>
        /// Accion al pulsar boton login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                usuari user = new usuari(txtuser.Text, txtpass.Text);
                conexion obj_conectar = new conexion();
                Boolean prova = obj_conectar.mysqlLogin(user);
                if (prova)
                {
                    FormPrincipal form = new FormPrincipal(user.Usuario);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    loginError.Text = "Usuario o contraseña incorrectos.";
                }
            }
            catch (Exception ex)
            {
                logs.Save("Error al consultar dades de login a la BBDD.", 120);
            }


        }

        /// <summary>
        /// Accion al decir que no estas registrado!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkpass_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister form = new FormRegister();
            form.Show();
            this.Hide();
        }
    }




}