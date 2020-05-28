using SpaceLauncher.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceLauncher.vista
{
    public partial class formLogs : Form
    {
        logs loge = new logs();
        public formLogs()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
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


    }
}
