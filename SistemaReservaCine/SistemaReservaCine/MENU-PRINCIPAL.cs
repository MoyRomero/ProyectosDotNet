using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaReservaCine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantCliente formulario = new FMantCliente();
            formulario.ShowDialog();
        }
        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantEmple formulario = new FMantEmple();
            formulario.ShowDialog();
        }
        private void cineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantCine formulario = new FMantCine();
            formulario.ShowDialog();
        }
        private void salaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantSala formulario = new FMantSala();
            formulario.ShowDialog();
        }
        private void películaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantPeliculas formulario = new FMantPeliculas();
            formulario.ShowDialog();
        }
        private void funciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMantFunc formulario = new FMantFunc();
            formulario.ShowDialog();
        }

        private void reservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FProceso formulario = new FProceso();
            formulario.ShowDialog();
        }
        private void reservaPorEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FReservEmpleados formulario = new FReservEmpleados();
            formulario.ShowDialog();    
        }
        private void películaPorGéneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FConsPeliculaGenero formulario = new FConsPeliculaGenero();
            formulario.ShowDialog();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void reservaPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FReservCliente formulario = new FReservCliente();
            formulario.ShowDialog();
        }
    }
}
