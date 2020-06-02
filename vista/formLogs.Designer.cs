namespace SpaceLauncher.vista
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBuscarLogs = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoerror = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaError = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.check10 = new System.Windows.Forms.CheckBox();
            this.check20 = new System.Windows.Forms.CheckBox();
            this.check30 = new System.Windows.Forms.CheckBox();
            this.check60 = new System.Windows.Forms.CheckBox();
            this.check40 = new System.Windows.Forms.CheckBox();
            this.check90 = new System.Windows.Forms.CheckBox();
            this.check80 = new System.Windows.Forms.CheckBox();
            this.check70 = new System.Windows.Forms.CheckBox();
            this.check120 = new System.Windows.Forms.CheckBox();
            this.check110 = new System.Windows.Forms.CheckBox();
            this.check100 = new System.Windows.Forms.CheckBox();
            this.check170 = new System.Windows.Forms.CheckBox();
            this.check160 = new System.Windows.Forms.CheckBox();
            this.check150 = new System.Windows.Forms.CheckBox();
            this.check140 = new System.Windows.Forms.CheckBox();
            this.check130 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.check180 = new System.Windows.Forms.CheckBox();
            this.ErrorBuscartxt = new System.Windows.Forms.TextBox();
            this.ErrorBusca = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBuscarLogs
            // 
            this.buttonBuscarLogs.Location = new System.Drawing.Point(359, 363);
            this.buttonBuscarLogs.Name = "buttonBuscarLogs";
            this.buttonBuscarLogs.Size = new System.Drawing.Size(137, 23);
            this.buttonBuscarLogs.TabIndex = 0;
            this.buttonBuscarLogs.Text = "Aplicar Filtro Fecha";
            this.buttonBuscarLogs.UseVisualStyleBackColor = true;
            this.buttonBuscarLogs.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecha,
            this.hora,
            this.codigoerror,
            this.Descripcion});
            this.dataGridView1.Location = new System.Drawing.Point(28, 44);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(743, 240);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.TabStop = false;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // hora
            // 
            this.hora.HeaderText = "hora";
            this.hora.Name = "hora";
            this.hora.ReadOnly = true;
            // 
            // codigoerror
            // 
            this.codigoerror.HeaderText = "Codigo error";
            this.codigoerror.Name = "codigoerror";
            this.codigoerror.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.FillWeight = 450F;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Descripcion.Width = 450;
            // 
            // fechaError
            // 
            this.fechaError.Checked = false;
            this.fechaError.CustomFormat = "dd/MM/yyyy";
            this.fechaError.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechaError.Location = new System.Drawing.Point(135, 366);
            this.fechaError.Name = "fechaError";
            this.fechaError.Size = new System.Drawing.Size(200, 20);
            this.fechaError.TabIndex = 2;
            this.fechaError.Value = new System.DateTime(2020, 5, 28, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha error:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Codigo Error:";
            // 
            // check10
            // 
            this.check10.AutoSize = true;
            this.check10.Location = new System.Drawing.Point(150, 299);
            this.check10.Name = "check10";
            this.check10.Size = new System.Drawing.Size(38, 17);
            this.check10.TabIndex = 5;
            this.check10.Text = "10";
            this.check10.UseVisualStyleBackColor = true;
            // 
            // check20
            // 
            this.check20.AutoSize = true;
            this.check20.Location = new System.Drawing.Point(194, 299);
            this.check20.Name = "check20";
            this.check20.Size = new System.Drawing.Size(38, 17);
            this.check20.TabIndex = 6;
            this.check20.Text = "20";
            this.check20.UseVisualStyleBackColor = true;
            // 
            // check30
            // 
            this.check30.AutoSize = true;
            this.check30.Location = new System.Drawing.Point(238, 299);
            this.check30.Name = "check30";
            this.check30.Size = new System.Drawing.Size(38, 17);
            this.check30.TabIndex = 7;
            this.check30.Text = "30";
            this.check30.UseVisualStyleBackColor = true;
            // 
            // check60
            // 
            this.check60.AutoSize = true;
            this.check60.Location = new System.Drawing.Point(326, 299);
            this.check60.Name = "check60";
            this.check60.Size = new System.Drawing.Size(38, 17);
            this.check60.TabIndex = 60;
            this.check60.Text = "60";
            this.check60.UseVisualStyleBackColor = true;
            // 
            // check40
            // 
            this.check40.AutoSize = true;
            this.check40.Location = new System.Drawing.Point(282, 300);
            this.check40.Name = "check40";
            this.check40.Size = new System.Drawing.Size(38, 17);
            this.check40.TabIndex = 8;
            this.check40.Text = "40";
            this.check40.UseVisualStyleBackColor = true;
            // 
            // check90
            // 
            this.check90.AutoSize = true;
            this.check90.Location = new System.Drawing.Point(458, 296);
            this.check90.Name = "check90";
            this.check90.Size = new System.Drawing.Size(38, 17);
            this.check90.TabIndex = 13;
            this.check90.Text = "90";
            this.check90.UseVisualStyleBackColor = true;
            // 
            // check80
            // 
            this.check80.AutoSize = true;
            this.check80.Location = new System.Drawing.Point(414, 299);
            this.check80.Name = "check80";
            this.check80.Size = new System.Drawing.Size(38, 17);
            this.check80.TabIndex = 12;
            this.check80.Text = "80";
            this.check80.UseVisualStyleBackColor = true;
            // 
            // check70
            // 
            this.check70.AutoSize = true;
            this.check70.Location = new System.Drawing.Point(370, 299);
            this.check70.Name = "check70";
            this.check70.Size = new System.Drawing.Size(38, 17);
            this.check70.TabIndex = 11;
            this.check70.Text = "70";
            this.check70.UseVisualStyleBackColor = true;
            // 
            // check120
            // 
            this.check120.AutoSize = true;
            this.check120.Location = new System.Drawing.Point(602, 296);
            this.check120.Name = "check120";
            this.check120.Size = new System.Drawing.Size(44, 17);
            this.check120.TabIndex = 16;
            this.check120.Text = "120";
            this.check120.UseVisualStyleBackColor = true;
            // 
            // check110
            // 
            this.check110.AutoSize = true;
            this.check110.Location = new System.Drawing.Point(552, 296);
            this.check110.Name = "check110";
            this.check110.Size = new System.Drawing.Size(44, 17);
            this.check110.TabIndex = 15;
            this.check110.Text = "110";
            this.check110.UseVisualStyleBackColor = true;
            // 
            // check100
            // 
            this.check100.AutoSize = true;
            this.check100.Location = new System.Drawing.Point(502, 296);
            this.check100.Name = "check100";
            this.check100.Size = new System.Drawing.Size(44, 17);
            this.check100.TabIndex = 14;
            this.check100.Text = "100";
            this.check100.UseVisualStyleBackColor = true;
            // 
            // check170
            // 
            this.check170.AutoSize = true;
            this.check170.Location = new System.Drawing.Point(414, 323);
            this.check170.Name = "check170";
            this.check170.Size = new System.Drawing.Size(44, 17);
            this.check170.TabIndex = 65;
            this.check170.Text = "170";
            this.check170.UseVisualStyleBackColor = true;
            // 
            // check160
            // 
            this.check160.AutoSize = true;
            this.check160.Location = new System.Drawing.Point(370, 323);
            this.check160.Name = "check160";
            this.check160.Size = new System.Drawing.Size(44, 17);
            this.check160.TabIndex = 64;
            this.check160.Text = "160";
            this.check160.UseVisualStyleBackColor = true;
            // 
            // check150
            // 
            this.check150.AutoSize = true;
            this.check150.Location = new System.Drawing.Point(326, 324);
            this.check150.Name = "check150";
            this.check150.Size = new System.Drawing.Size(44, 17);
            this.check150.TabIndex = 63;
            this.check150.Text = "150";
            this.check150.UseVisualStyleBackColor = true;
            // 
            // check140
            // 
            this.check140.AutoSize = true;
            this.check140.Location = new System.Drawing.Point(282, 324);
            this.check140.Name = "check140";
            this.check140.Size = new System.Drawing.Size(44, 17);
            this.check140.TabIndex = 62;
            this.check140.Text = "140";
            this.check140.UseVisualStyleBackColor = true;
            // 
            // check130
            // 
            this.check130.AutoSize = true;
            this.check130.Location = new System.Drawing.Point(647, 296);
            this.check130.Name = "check130";
            this.check130.Size = new System.Drawing.Size(44, 17);
            this.check130.TabIndex = 61;
            this.check130.Text = "130";
            this.check130.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 66;
            this.button1.Text = "Aplicar Filtro Codigo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(554, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 23);
            this.button2.TabIndex = 67;
            this.button2.Text = "Mostrar todos los logs";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // check180
            // 
            this.check180.AutoSize = true;
            this.check180.Location = new System.Drawing.Point(464, 323);
            this.check180.Name = "check180";
            this.check180.Size = new System.Drawing.Size(44, 17);
            this.check180.TabIndex = 68;
            this.check180.Text = "180";
            this.check180.UseVisualStyleBackColor = true;
            // 
            // ErrorBuscartxt
            // 
            this.ErrorBuscartxt.Location = new System.Drawing.Point(146, 13);
            this.ErrorBuscartxt.Name = "ErrorBuscartxt";
            this.ErrorBuscartxt.Size = new System.Drawing.Size(174, 20);
            this.ErrorBuscartxt.TabIndex = 69;
            // 
            // ErrorBusca
            // 
            this.ErrorBusca.AutoSize = true;
            this.ErrorBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorBusca.Location = new System.Drawing.Point(44, 13);
            this.ErrorBusca.Name = "ErrorBusca";
            this.ErrorBusca.Size = new System.Drawing.Size(100, 20);
            this.ErrorBusca.TabIndex = 70;
            this.ErrorBusca.Text = "Buscar error:";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(337, 12);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(94, 21);
            this.buttonBuscar.TabIndex = 71;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // formLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.ErrorBusca);
            this.Controls.Add(this.ErrorBuscartxt);
            this.Controls.Add(this.check180);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.check170);
            this.Controls.Add(this.check160);
            this.Controls.Add(this.check150);
            this.Controls.Add(this.check140);
            this.Controls.Add(this.check130);
            this.Controls.Add(this.check120);
            this.Controls.Add(this.check110);
            this.Controls.Add(this.check100);
            this.Controls.Add(this.check90);
            this.Controls.Add(this.check80);
            this.Controls.Add(this.check70);
            this.Controls.Add(this.check60);
            this.Controls.Add(this.check40);
            this.Controls.Add(this.check30);
            this.Controls.Add(this.check20);
            this.Controls.Add(this.check10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaError);
            this.Controls.Add(this.buttonBuscarLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formLogs";
            this.Text = "Logs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuscarLogs;
        private System.Windows.Forms.DateTimePicker fechaError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox check10;
        private System.Windows.Forms.CheckBox check20;
        private System.Windows.Forms.CheckBox check30;
        private System.Windows.Forms.CheckBox check60;
        private System.Windows.Forms.CheckBox check40;
        private System.Windows.Forms.CheckBox check90;
        private System.Windows.Forms.CheckBox check80;
        private System.Windows.Forms.CheckBox check70;
        private System.Windows.Forms.CheckBox check120;
        private System.Windows.Forms.CheckBox check110;
        private System.Windows.Forms.CheckBox check100;
        private System.Windows.Forms.CheckBox check170;
        private System.Windows.Forms.CheckBox check160;
        private System.Windows.Forms.CheckBox check150;
        private System.Windows.Forms.CheckBox check140;
        private System.Windows.Forms.CheckBox check130;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoerror;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox check180;
        private System.Windows.Forms.TextBox ErrorBuscartxt;
        private System.Windows.Forms.Label ErrorBusca;
        private System.Windows.Forms.Button buttonBuscar;
    }
}