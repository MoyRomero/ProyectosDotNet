namespace SistemaReservaCine
{
    partial class FpUpEMPL
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpMantenimiento = new System.Windows.Forms.GroupBox();
            this.chRev = new System.Windows.Forms.CheckBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.cmBxTipoEmpleado = new System.Windows.Forms.ComboBox();
            this.cmBxModalidad = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtApellidoM = new System.Windows.Forms.TextBox();
            this.txtApellidoP = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblContra = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpMantenimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(253, 432);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 34);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpMantenimiento
            // 
            this.grpMantenimiento.Controls.Add(this.chRev);
            this.grpMantenimiento.Controls.Add(this.txtContraseña);
            this.grpMantenimiento.Controls.Add(this.cmBxTipoEmpleado);
            this.grpMantenimiento.Controls.Add(this.cmBxModalidad);
            this.grpMantenimiento.Controls.Add(this.lblID);
            this.grpMantenimiento.Controls.Add(this.txtFechaInicio);
            this.grpMantenimiento.Controls.Add(this.txtSueldo);
            this.grpMantenimiento.Controls.Add(this.label2);
            this.grpMantenimiento.Controls.Add(this.txtUsuario);
            this.grpMantenimiento.Controls.Add(this.txtApellidoM);
            this.grpMantenimiento.Controls.Add(this.txtApellidoP);
            this.grpMantenimiento.Controls.Add(this.txtNombre);
            this.grpMantenimiento.Controls.Add(this.lblContra);
            this.grpMantenimiento.Controls.Add(this.label9);
            this.grpMantenimiento.Controls.Add(this.label8);
            this.grpMantenimiento.Controls.Add(this.label7);
            this.grpMantenimiento.Controls.Add(this.label6);
            this.grpMantenimiento.Controls.Add(this.label5);
            this.grpMantenimiento.Controls.Add(this.label4);
            this.grpMantenimiento.Controls.Add(this.label3);
            this.grpMantenimiento.Controls.Add(this.label1);
            this.grpMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMantenimiento.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpMantenimiento.Location = new System.Drawing.Point(35, 23);
            this.grpMantenimiento.Name = "grpMantenimiento";
            this.grpMantenimiento.Size = new System.Drawing.Size(376, 403);
            this.grpMantenimiento.TabIndex = 28;
            this.grpMantenimiento.TabStop = false;
            // 
            // chRev
            // 
            this.chRev.AutoSize = true;
            this.chRev.Location = new System.Drawing.Point(302, 366);
            this.chRev.Name = "chRev";
            this.chRev.Size = new System.Drawing.Size(68, 19);
            this.chRev.TabIndex = 31;
            this.chRev.Text = "Revelar";
            this.chRev.UseVisualStyleBackColor = true;
            this.chRev.CheckedChanged += new System.EventHandler(this.OcultarRevelar);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(127, 366);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(169, 21);
            this.txtContraseña.TabIndex = 28;
            // 
            // cmBxTipoEmpleado
            // 
            this.cmBxTipoEmpleado.FormattingEnabled = true;
            this.cmBxTipoEmpleado.Location = new System.Drawing.Point(175, 295);
            this.cmBxTipoEmpleado.Name = "cmBxTipoEmpleado";
            this.cmBxTipoEmpleado.Size = new System.Drawing.Size(177, 23);
            this.cmBxTipoEmpleado.TabIndex = 27;
            // 
            // cmBxModalidad
            // 
            this.cmBxModalidad.FormattingEnabled = true;
            this.cmBxModalidad.Location = new System.Drawing.Point(175, 256);
            this.cmBxModalidad.Name = "cmBxModalidad";
            this.cmBxModalidad.Size = new System.Drawing.Size(177, 23);
            this.cmBxModalidad.TabIndex = 26;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblID.Location = new System.Drawing.Point(162, 40);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(160, 17);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "ID AUTOINCREMENT";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaInicio.Location = new System.Drawing.Point(175, 222);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(177, 20);
            this.txtFechaInicio.TabIndex = 23;
            // 
            // txtSueldo
            // 
            this.txtSueldo.Location = new System.Drawing.Point(175, 185);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Size = new System.Drawing.Size(177, 21);
            this.txtSueldo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(74, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "SUELDO:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(175, 329);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(177, 21);
            this.txtUsuario.TabIndex = 21;
            // 
            // txtApellidoM
            // 
            this.txtApellidoM.Location = new System.Drawing.Point(175, 149);
            this.txtApellidoM.Name = "txtApellidoM";
            this.txtApellidoM.Size = new System.Drawing.Size(177, 21);
            this.txtApellidoM.TabIndex = 17;
            // 
            // txtApellidoP
            // 
            this.txtApellidoP.Location = new System.Drawing.Point(175, 112);
            this.txtApellidoP.Name = "txtApellidoP";
            this.txtApellidoP.Size = new System.Drawing.Size(177, 21);
            this.txtApellidoP.TabIndex = 16;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(175, 74);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 21);
            this.txtNombre.TabIndex = 15;
            // 
            // lblContra
            // 
            this.lblContra.AutoSize = true;
            this.lblContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContra.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblContra.Location = new System.Drawing.Point(3, 366);
            this.lblContra.Name = "lblContra";
            this.lblContra.Size = new System.Drawing.Size(118, 17);
            this.lblContra.TabIndex = 12;
            this.lblContra.Text = "CONTRASEÑA:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(68, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "USUARIO:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(12, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "TIPO EMPLEADO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(47, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "MODALIDAD:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(37, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "FECHA INICIO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(45, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "APELLIDO M:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(47, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "APELLIDO P:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(71, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "NOMBRE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(39, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID EMPLEADO:";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(69, 432);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(123, 34);
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "ACEPTAR";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FpUpEMPL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(448, 489);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpMantenimiento);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.Name = "FpUpEMPL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FpUpEMPL_Load);
            this.grpMantenimiento.ResumeLayout(false);
            this.grpMantenimiento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpMantenimiento;
        private System.Windows.Forms.ComboBox cmBxTipoEmpleado;
        private System.Windows.Forms.ComboBox cmBxModalidad;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker txtFechaInicio;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtApellidoM;
        private System.Windows.Forms.TextBox txtApellidoP;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.TextBox txtContraseña;
        public System.Windows.Forms.Label lblContra;
        public System.Windows.Forms.CheckBox chRev;
    }
}