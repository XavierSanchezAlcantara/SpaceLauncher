using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using CryptSharp;
using SpaceLauncher.model;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.ApplicationServices;

namespace SpaceLauncher
{
    public partial class FormRegister : Form
    {
        //Importem els DLL per poder moure el programa com nosaltres volguem.


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public FormRegister()
        {
            InitializeComponent();
            dateNeixament.CustomFormat = "yyyy-M-dd";
        }
        //Definim que a l'entrar a usuario es buidi
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }




        //Definim que si sortim del Usuario i està buit, es torni a veure Usuario.
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        //Definim que a l'entrar a contrasenya es buidi, també definim que es vegi en forma de password

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

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;

            }
        }
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "EMAIL")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.LightGray;
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "EMAIL";
                txtEmail.ForeColor = Color.DimGray;
            }
        }
        //Boto Clicar.
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Boto minimitzar.
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Codi per poder moure la finestra com nosaltres volguem.

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Codi per poder moure la finestra com nosaltres volguem.


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Accions al clicar el boto Register.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conexion obj_conectar = new conexion();
                usuari user = new usuari(txtuser.Text,txtEmail.Text,txtpass.Text,dateNeixament.Text,sexe.Text);
               
                if (user.contraseñaValida(user.Clave))
                {
                    
                    if (user.ComprobarFormatoEmail(user.Email))
                    {

                        Boolean prova = obj_conectar.mysqlRegister(user);
                        if (prova)
                        {
                            FormLogin form = new FormLogin();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            loginError.Text = "Usuario ya esta registrado!!";

                        }
                    }
                    else {
                        loginError.Text = "Introduce una direccion electronica valida!!";
                    }
                }
                else
                {
                    loginError.Text = "Contraseña introducida no valida.";
                }
            }
            catch (Exception ex)
            {

                logs.Save("Error al Insertar nuevoUsuario.",20);
            }


        }


        private void linkpass_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister form = new FormRegister();
            form.Show();
            this.Hide();
        }
        }

  
    }




