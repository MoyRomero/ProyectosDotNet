namespace SistemaReservaCine
{
    partial class FpUpFunc
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmBxSala = new System.Windows.Forms.ComboBox();
            this.cmBxCine = new System.Windows.Forms.ComboBox();
            this.cmBxPelicula = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtFechaFuncion = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmBxTipoEntrada = new System.Windows.Forms.ComboBox();
            this.dgvPrecios = new System.Windows.Forms.DataGridView();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPrecio = new System.Windows.Forms.Button();
            this.grpMantenimiento.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(246, 560);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 34);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // grpMantenimiento
            // 
            this.grpMantenimiento.Controls.Add(this.label2);
            this.grpMantenimiento.Controls.Add(this.cmBxSala);
            this.grpMantenimiento.Controls.Add(this.cmBxCine);
            this.grpMantenimiento.Controls.Add(this.cmBxPelicula);
            this.grpMantenimiento.Controls.Add(this.lblID);
            this.grpMantenimiento.Controls.Add(this.txtFechaFuncion);
            this.grpMantenimiento.Controls.Add(this.label8);
            this.grpMantenimiento.Controls.Add(this.label7);
            this.grpMantenimiento.Controls.Add(this.label6);
            this.grpMantenimiento.Controls.Add(this.label1);
            this.grpMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMantenimiento.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpMantenimiento.Location = new System.Drawing.Point(28, 12);
            this.grpMantenimiento.Name = "grpMantenimiento";
            this.grpMantenimiento.Size = new System.Drawing.Size(376, 225);
            this.grpMantenimiento.TabIndex = 31;
            this.grpMantenimiento.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(124, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "SALA:";
            // 
            // cmBxSala
            // 
            this.cmBxSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxSala.FormattingEnabled = true;
            this.cmBxSala.Location = new System.Drawing.Point(182, 185);
            this.cmBxSala.Name = "cmBxSala";
            this.cmBxSala.Size = new System.Drawing.Size(177, 23);
            this.cmBxSala.TabIndex = 28;
            // 
            // cmBxCine
            // 
            this.cmBxCine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxCine.FormattingEnabled = true;
            this.cmBxCine.Location = new System.Drawing.Point(182, 143);
            this.cmBxCine.Name = "cmBxCine";
            this.cmBxCine.Size = new System.Drawing.Size(177, 23);
            this.cmBxCine.TabIndex = 27;
            this.cmBxCine.SelectedIndexChanged += new System.EventHandler(this.CmBxSala);
            // 
            // cmBxPelicula
            // 
            this.cmBxPelicula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxPelicula.FormattingEnabled = true;
            this.cmBxPelicula.Location = new System.Drawing.Point(182, 104);
            this.cmBxPelicula.Name = "cmBxPelicula";
            this.cmBxPelicula.Size = new System.Drawing.Size(177, 23);
            this.cmBxPelicula.TabIndex = 26;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblID.Location = new System.Drawing.Point(190, 40);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 17);
            this.lblID.TabIndex = 25;
            // 
            // txtFechaFuncion
            // 
            this.txtFechaFuncion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaFuncion.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.txtFechaFuncion.Location = new System.Drawing.Point(182, 70);
            this.txtFechaFuncion.Name = "txtFechaFuncion";
            this.txtFechaFuncion.Size = new System.Drawing.Size(177, 20);
            this.txtFechaFuncion.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(128, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "CINE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(90, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "PELICULA:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(14, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "FECHA DE FUNCIÓN:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID FUNCIÓN:";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(62, 560);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(123, 34);
            this.btnOk.TabIndex = 32;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrecio);
            this.groupBox1.Controls.Add(this.cmBxTipoEntrada);
            this.groupBox1.Controls.Add(this.dgvPrecios);
            this.groupBox1.Controls.Add(this.numPrecio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(28, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 311);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // cmBxTipoEntrada
            // 
            this.cmBxTipoEntrada.FormattingEnabled = true;
            this.cmBxTipoEntrada.Location = new System.Drawing.Point(171, 15);
            this.cmBxTipoEntrada.Name = "cmBxTipoEntrada";
            this.cmBxTipoEntrada.Size = new System.Drawing.Size(177, 23);
            this.cmBxTipoEntrada.TabIndex = 31;
            // 
            // dgvPrecios
            // 
            this.dgvPrecios.AllowUserToAddRows = false;
            this.dgvPrecios.AllowUserToDeleteRows = false;
            this.dgvPrecios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrecios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPrecios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrecios.Location = new System.Drawing.Point(6, 117);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrecios.Size = new System.Drawing.Size(364, 188);
            this.dgvPrecios.TabIndex = 30;
            // 
            // numPrecio
            // 
            this.numPrecio.Location = new System.Drawing.Point(171, 44);
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(177, 21);
            this.numPrecio.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(173, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(89, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "PRECIO:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(32, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "TIPO ENTRADA:";
            // 
            // btnPrecio
            // 
            this.btnPrecio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrecio.Location = new System.Drawing.Point(127, 77);
            this.btnPrecio.Name = "btnPrecio";
            this.btnPrecio.Size = new System.Drawing.Size(123, 34);
            this.btnPrecio.TabIndex = 34;
            this.btnPrecio.Text = "AGREGAR PRECIO";
            this.btnPrecio.UseVisualStyleBackColor = true;
            this.btnPrecio.Click += new System.EventHandler(this.btnPrecio_Click);
            // 
            // FpUpFunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(433, 608);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpMantenimiento);
            this.Controls.Add(this.btnOk);
            this.Name = "FpUpFunc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FpUpFunc_Load);
            this.grpMantenimiento.ResumeLayout(false);
            this.grpMantenimiento.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpMantenimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmBxSala;
        private System.Windows.Forms.ComboBox cmBxCine;
        private System.Windows.Forms.ComboBox cmBxPelicula;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker txtFechaFuncion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.ComboBox cmBxTipoEntrada;
        private System.Windows.Forms.Button btnPrecio;
    }
}