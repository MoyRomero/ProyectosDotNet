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
    public partial class FMantFunc : Form
    {
        public FMantFunc()
        {
            InitializeComponent();
        }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        string ID;
        private void FMantFunc_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvFunciones.DataSource = null;
            if(tabla == null)
            {
                tabla = from fun in BD.FUNCION
                        join pel in BD.PELICULA
                        on fun.IDPELICULA equals pel.IDPELICULA
                        join cine in BD.CINE
                        on fun.IDCINE equals cine.IDCINE
                        join sala in BD.SALA
                        on fun.IDSALA equals sala.IDSALA
                        where fun.BHABILITADO.Equals(1)
                        orderby cine.IDCINE
                        select new
                        {
                            ID = fun.IDFUNCION,
                            FECHA_FUNCION = fun.FECHAFUNCION,
                            PELICULA = pel.TITULO,
                            CINE = cine.NOMBRE,
                            NOMBRE = sala.NOMBRE
                        };
            }
            dgvFunciones.DataSource = tabla;
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FpUpFunc formulario = new FpUpFunc();
            formulario.accion = "AGREGAR";
            formulario.ShowDialog();

            if(formulario.DialogResult == DialogResult.OK )
            {
                RellenarTabla(tabla:null);
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            FpUpFunc formulario = new FpUpFunc();
            formulario.accion = "EDITAR";
            formulario.id = ID;
            formulario.ShowDialog();

            if (formulario.DialogResult == DialogResult.OK)
            {
                RellenarTabla(tabla: null);
            }
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Desea eliminar la función {ID} de la lista de funciones?", "AVISO IMPORTANTE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var consulta = from fun in BD.FUNCION
                               where fun.IDFUNCION.Equals(ID)
                               select fun;

                foreach (var c in consulta) c.BHABILITADO = false;

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show("Se han removido la función de la lista, de forma correcta.");
                    RellenarTabla(tabla: null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void CapturarID(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgvFunciones.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
