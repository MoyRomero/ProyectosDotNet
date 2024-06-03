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
    public partial class FMantSala : Form
    {
        public FMantSala()
        {
            InitializeComponent();
        }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        string ID;
        private void FMantSala_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvSalas.DataSource = null;
            if (tabla == null)
            {
                tabla = from sala in BD.SALA
                        join cine in BD.CINE
                        on sala.IDCINE equals cine.IDCINE
                        where sala.BHABILITADO.Equals(1)
                        select new
                        {
                            ID = sala.IDSALA,
                            CINE = cine.NOMBRE,
                            ASIENTOS = sala.NUMBUTACAS,
                            FILAS = sala.NUMEROFILAS,
                            COLUMNAS = sala.NUMEROCOLUMNAS
                        };
            }
            dgvSalas.DataSource = tabla;
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FpUpSalas formulario = new FpUpSalas();
            formulario.accion = "AGREGAR";
            formulario.ShowDialog();

            if(formulario.DialogResult == DialogResult.OK)
            {
                RellenarTabla(tabla: null);
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            FpUpSalas formulario = new FpUpSalas();
            formulario.accion = "EDITAR";
            formulario.id = ID;
            formulario.ShowDialog();

            if(formulario.DialogResult == DialogResult.OK)
            {
                RellenarTabla(tabla:null);
            }
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Realmente desea eliminar la SALA de ID: {ID} de la lista?","AVISO IMPORTANTE",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                var sala = from id in BD.SALA
                               where id.IDSALA.Equals(ID)
                               select id;
                foreach (var EH in sala) EH.BHABILITADO = false;

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha removido la SALA: {ID} de forma correcta.");
                    RellenarTabla(tabla: null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }
        }
        private void CapturaID(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgvSalas.CurrentRow.Cells[0].Value.ToString();
        }        
    }
}
