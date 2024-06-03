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
    public partial class FMantCine : Form
    {
        public FMantCine()
        {
            InitializeComponent();
        }

        ReservaCineDataContext BD = new ReservaCineDataContext();
        string ID;
        string nombre;
        private void FMantCine_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvCines.DataSource = null;

            if (tabla == null)
            {
                tabla = from cine in BD.CINE
                        where cine.BHABILITADO.Equals(1)
                        select new 
                        {
                            ID = cine.IDCINE,
                            NOMBRE = cine.NOMBRE,
                            DIRECCIÓN = cine.DIRECCION,
                            FECHA_APERTURA = cine.FECHAAPERTURA
                        };
                dgvCines.DataSource = tabla;
            }
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FpUpCine formulario = new FpUpCine();
            formulario.accion = "AGREGAR";
            formulario.ShowDialog();
            
            if(formulario.DialogResult == DialogResult.OK)
            {
                RellenarTabla(tabla: null);
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            FpUpCine formulario = new FpUpCine();
            formulario.id = ID;
            formulario.accion = "EDITAR";
            formulario.ShowDialog();

            if(formulario.DialogResult == DialogResult.OK)
            {
                RellenarTabla(tabla: null);
            }
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"¿Realmente desea eliminar el CINE: {nombre} de la lista?","AVISO IMPORTANTE",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var consulta = from cine in BD.CINE
                               where cine.IDCINE.Equals(ID)
                               select cine;
                foreach (var c in consulta) c.BHABILITADO = 0;

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha eliminado el CINE: {nombre} de forma correcta.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }
            RellenarTabla(tabla: null);
        }
        private void CapturaID(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgvCines.CurrentRow.Cells[0].Value.ToString();
            nombre = dgvCines.CurrentRow.Cells[1].Value.ToString();
        }

        
    }
}
