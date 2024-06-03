namespace SistemaReservaCine
{
    partial class FpUpSalas
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
            this.lblID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmBxIdCine = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numAsientos = new System.Windows.Forms.NumericUpDown();
            this.numFilas = new System.Windows.Forms.NumericUpDown();
            this.numColumnas = new System.Windows.Forms.NumericUpDown();
            this.grpMantenimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAsientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumnas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(254, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 34);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpMantenimiento
            // 
            this.grpMantenimiento.Controls.Add(this.numColumnas);
            this.grpMantenimiento.Controls.Add(this.numFilas);
            this.grpMantenimiento.Controls.Add(this.numAsientos);
            this.grpMantenimiento.Controls.Add(this.label5);
            this.grpMantenimiento.Controls.Add(this.cmBxIdCine);
            this.grpMantenimiento.Controls.Add(this.lblID);
            this.grpMantenimiento.Controls.Add(this.label4);
            this.grpMantenimiento.Controls.Add(this.label3);
            this.grpMantenimiento.Controls.Add(this.label2);
            this.grpMantenimiento.Controls.Add(this.label1);
            this.grpMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMantenimiento.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpMantenimiento.Location = new System.Drawing.Point(22, 12);
            this.grpMantenimiento.Name = "grpMantenimiento";
            this.grpMantenimiento.Size = new System.Drawing.Size(408, 210);
            this.grpMantenimiento.TabIndex = 28;
            this.grpMantenimiento.TabStop = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblID.Location = new System.Drawing.Point(219, 20);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(72, 17);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "ID SALA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(13, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "NÚMERO DE COLUMNAS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(56, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "NÚMERO DE FILAS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(21, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "NÚMERO DE ASIENTOS:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(137, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID SALA:";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(70, 234);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(123, 34);
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "ACEPTAR";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmBxIdCine
            // 
            this.cmBxIdCine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxIdCine.FormattingEnabled = true;
            this.cmBxIdCine.Location = new System.Drawing.Point(221, 50);
            this.cmBxIdCine.Name = "cmBxIdCine";
            this.cmBxIdCine.Size = new System.Drawing.Size(156, 23);
            this.cmBxIdCine.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(161, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "CINE:";
            // 
            // numAsientos
            // 
            this.numAsientos.Location = new System.Drawing.Point(221, 92);
            this.numAsientos.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numAsientos.Name = "numAsientos";
            this.numAsientos.Size = new System.Drawing.Size(156, 21);
            this.numAsientos.TabIndex = 31;
            // 
            // numFilas
            // 
            this.numFilas.Location = new System.Drawing.Point(221, 131);
            this.numFilas.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numFilas.Name = "numFilas";
            this.numFilas.Size = new System.Drawing.Size(156, 21);
            this.numFilas.TabIndex = 32;
            // 
            // numColumnas
            // 
            this.numColumnas.Location = new System.Drawing.Point(221, 167);
            this.numColumnas.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numColumnas.Name = "numColumnas";
            this.numColumnas.Size = new System.Drawing.Size(156, 21);
            this.numColumnas.TabIndex = 33;
            // 
            // FpUpSalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(452, 280);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpMantenimiento);
            this.Controls.Add(this.btnOk);
            this.Name = "FpUpSalas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FpUpSalas_Load);
            this.grpMantenimiento.ResumeLayout(false);
            this.grpMantenimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAsientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumnas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpMantenimiento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmBxIdCine;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown numColumnas;
        private System.Windows.Forms.NumericUpDown numFilas;
        private System.Windows.Forms.NumericUpDown numAsientos;
    }
}