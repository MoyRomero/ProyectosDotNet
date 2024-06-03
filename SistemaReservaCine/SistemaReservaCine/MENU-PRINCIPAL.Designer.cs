namespace SistemaReservaCine
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cONSULTASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservaPorEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservaPorClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.películaPorGéneroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mANTENIMIENTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.películaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pROCESOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cONSULTASToolStripMenuItem,
            this.mANTENIMIENTOToolStripMenuItem,
            this.pROCESOSToolStripMenuItem,
            this.btnSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cONSULTASToolStripMenuItem
            // 
            this.cONSULTASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservaPorEmpleadoToolStripMenuItem,
            this.reservaPorClienteToolStripMenuItem,
            this.películaPorGéneroToolStripMenuItem});
            this.cONSULTASToolStripMenuItem.Name = "cONSULTASToolStripMenuItem";
            this.cONSULTASToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.cONSULTASToolStripMenuItem.Text = "CONSULTAS";
            // 
            // reservaPorEmpleadoToolStripMenuItem
            // 
            this.reservaPorEmpleadoToolStripMenuItem.Name = "reservaPorEmpleadoToolStripMenuItem";
            this.reservaPorEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.reservaPorEmpleadoToolStripMenuItem.Text = "Reserva por Empleado";
            this.reservaPorEmpleadoToolStripMenuItem.Click += new System.EventHandler(this.reservaPorEmpleadoToolStripMenuItem_Click);
            // 
            // reservaPorClienteToolStripMenuItem
            // 
            this.reservaPorClienteToolStripMenuItem.Name = "reservaPorClienteToolStripMenuItem";
            this.reservaPorClienteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.reservaPorClienteToolStripMenuItem.Text = "Reserva por Cliente";
            this.reservaPorClienteToolStripMenuItem.Click += new System.EventHandler(this.reservaPorClienteToolStripMenuItem_Click);
            // 
            // películaPorGéneroToolStripMenuItem
            // 
            this.películaPorGéneroToolStripMenuItem.Name = "películaPorGéneroToolStripMenuItem";
            this.películaPorGéneroToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.películaPorGéneroToolStripMenuItem.Text = "Película por Género";
            this.películaPorGéneroToolStripMenuItem.Click += new System.EventHandler(this.películaPorGéneroToolStripMenuItem_Click);
            // 
            // mANTENIMIENTOToolStripMenuItem
            // 
            this.mANTENIMIENTOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.empleadoToolStripMenuItem,
            this.cineToolStripMenuItem,
            this.salaToolStripMenuItem,
            this.películaToolStripMenuItem,
            this.funciónToolStripMenuItem});
            this.mANTENIMIENTOToolStripMenuItem.Name = "mANTENIMIENTOToolStripMenuItem";
            this.mANTENIMIENTOToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.mANTENIMIENTOToolStripMenuItem.Text = "MANTENIMIENTO";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // empleadoToolStripMenuItem
            // 
            this.empleadoToolStripMenuItem.Name = "empleadoToolStripMenuItem";
            this.empleadoToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.empleadoToolStripMenuItem.Text = "Empleado";
            this.empleadoToolStripMenuItem.Click += new System.EventHandler(this.empleadoToolStripMenuItem_Click);
            // 
            // cineToolStripMenuItem
            // 
            this.cineToolStripMenuItem.Name = "cineToolStripMenuItem";
            this.cineToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.cineToolStripMenuItem.Text = "Cine";
            this.cineToolStripMenuItem.Click += new System.EventHandler(this.cineToolStripMenuItem_Click);
            // 
            // salaToolStripMenuItem
            // 
            this.salaToolStripMenuItem.Name = "salaToolStripMenuItem";
            this.salaToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.salaToolStripMenuItem.Text = "Sala";
            this.salaToolStripMenuItem.Click += new System.EventHandler(this.salaToolStripMenuItem_Click);
            // 
            // películaToolStripMenuItem
            // 
            this.películaToolStripMenuItem.Name = "películaToolStripMenuItem";
            this.películaToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.películaToolStripMenuItem.Text = "Película";
            this.películaToolStripMenuItem.Click += new System.EventHandler(this.películaToolStripMenuItem_Click);
            // 
            // funciónToolStripMenuItem
            // 
            this.funciónToolStripMenuItem.Name = "funciónToolStripMenuItem";
            this.funciónToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.funciónToolStripMenuItem.Text = "Función";
            this.funciónToolStripMenuItem.Click += new System.EventHandler(this.funciónToolStripMenuItem_Click);
            // 
            // pROCESOSToolStripMenuItem
            // 
            this.pROCESOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservaToolStripMenuItem});
            this.pROCESOSToolStripMenuItem.Name = "pROCESOSToolStripMenuItem";
            this.pROCESOSToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.pROCESOSToolStripMenuItem.Text = "PROCESOS";
            // 
            // reservaToolStripMenuItem
            // 
            this.reservaToolStripMenuItem.Name = "reservaToolStripMenuItem";
            this.reservaToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.reservaToolStripMenuItem.Text = "Reserva";
            this.reservaToolStripMenuItem.Click += new System.EventHandler(this.reservaToolStripMenuItem_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(49, 20);
            this.btnSalir.Text = "SALIR";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(44)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(639, 396);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU PRINCIPAL: RESERVA DE CINE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cONSULTASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservaPorEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservaPorClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem películaPorGéneroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mANTENIMIENTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem películaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pROCESOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSalir;
    }
}

