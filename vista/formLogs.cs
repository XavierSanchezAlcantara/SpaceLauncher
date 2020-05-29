using SpaceLauncher.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceLauncher.vista
{
    public partial class formLogs : Form
    {
        logs loge = new logs();

        /// <summary>
        /// Carregar pantalla logs!
        /// </summary>
        public formLogs()
        {
            InitializeComponent();
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

            try
            {
                dataGridView1.Rows.Clear();
                foreach (logs log in loge.leer())
                {
                    dataGridView1.Rows.Add(new object[] { log.Fecha, log.Hora, log.Code, log.Error });
                }
            }
            catch
            {

            }
            fechaError.CustomFormat = "dd/MM/yyyy";
        }
        /// <summary>
        /// Accio per filtrar logs per text!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (logs log in loge.leer())
                {
                    Console.WriteLine(fechaError.Value.Date);


                    if (fechaError.Value.ToString().Contains(log.Fecha))
                    {
                        dataGridView1.Rows.Add(new object[] { log.Fecha, log.Hora, log.Code, log.Error });

                    }
                }
            }
            catch
            {
                logs.Save("Error al cargar logs!", 50);
            }
        }
        /// <summary>
        /// Accion boton filtrar codigo error!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (logs log in loge.leer())
                {
                    bool checkError = false;
                    //comprovar si el numero del error esta checked.
                    switch (log.Code)
                    {
                        case 10:
                            checkError = check10.Checked;
                            break;
                        case 20:
                            checkError = check20.Checked;
                            break;
                        case 30:
                            checkError = check30.Checked;
                            break;
                        case 40:
                            checkError = check40.Checked;
                            break;
                        case 60:
                            checkError = check60.Checked;
                            break;
                        case 70:
                            checkError = check70.Checked;
                            break;
                        case 80:
                            checkError = check80.Checked;
                            break;
                        case 90:
                            checkError = check90.Checked;
                            break;
                        case 100:
                            checkError = check100.Checked;
                            break;
                        case 110:
                            checkError = check110.Checked;
                            break;
                        case 120:
                            checkError = check120.Checked;
                            break;
                        case 130:
                            checkError = check130.Checked;
                            break;
                        case 140:
                            checkError = check140.Checked;
                            break;
                        case 150:
                            checkError = check150.Checked;
                            break;
                        case 160:
                            checkError = check160.Checked;
                            break;
                        case 170:
                            checkError = check170.Checked;
                            break;
                        case 180:
                            checkError = check180.Checked;
                            break;
                    }


                    //si esta checked afegir-ho a la taula.
                    if (checkError)
                    {
                        dataGridView1.Rows.Add(new object[] { log.Fecha, log.Hora, log.Code, log.Error });

                    }
                }
            }
            catch
            {
                logs.Save("Error al cargar logs!", 50);
            }
        }


        /// <summary>
        /// Cargar todos los logs!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (logs log in loge.leer())
                {
                    dataGridView1.Rows.Add(new object[] { log.Fecha, log.Hora, log.Code, log.Error });
                }
            }
            catch
            {
                logs.Save("Error al cargar logs!", 50);
            }
        }
        /// <summary>
        /// Cargar logs a partir de una string!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (logs log in loge.leerConString(ErrorBuscartxt.Text))
                {
                    dataGridView1.Rows.Add(new object[] { log.Fecha, log.Hora, log.Code, log.Error });
                }
            }
            catch
            {
                logs.Save("Error al cargar logs!", 50);
            }
        }
    }
}
