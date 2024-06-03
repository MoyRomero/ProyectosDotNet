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
    public partial class FMantEmple : Form
    {
        public FMantEmple()
        {
            InitializeComponent();
        }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        string ID;
        private void FMantEmple_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvEmpleados.DataSource = null;

            if (tabla == null)
            {
                tabla = (from e in BD.EMPLEADO
                         join te in BD.TIPOEMPLEADO
                         on e.IDTIPOEMPLEADO equals te.IDTIPOEMPLEADO
                         join tm in BD.TIPOMODALIDAD
                         on e.IDTIPOMODALIDAD equals tm.IDTIPOMODALIDAD
                         where e.BHABILITADO.Equals(1)
                         select new
                         {
                             ID= e.IDEMPLEADO,
                             NOMBRE = $"{e.NOMBREEMPLEADO} {e.APPATERNO} {e.APMATERNO}",
                             SUELDO = e.SUELDO,
                             FECHA_INICIO = e.FECHAINICIO,
                             MODALIDAD = tm.NOMBRE,
                             TIPO_EMPL = te.NOMBRE,
                             USUARIO = e.USUARIO,
                             BLOQUEADO = e.BBLOQUEADO
                         }).ToList();
            }
            dgvEmpleados.DataSource = tabla;
        }
        private void CapturaID(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FpUpEMPL formulario = new FpUpEMPL();
            formulario.accion = "AGREGAR";
            formulario.ShowDialog();
            if(formulario.DialogResult == DialogResult.OK)
            {
                RellenarTabla(tabla:null);
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if(ID == null || ID == "")
            {
                MessageBox.Show("Debe seleccionar un empleado, dando click sobre alguna fila en la tabla de Empleados.");
                return;
            }

            FpUpEMPL formulario = new FpUpEMPL();
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
            string[] Nmbr =
            {
                dgvEmpleados.CurrentRow.Cells[1].Value.ToString()

            };

            if (MessageBox.Show($"¿Realmente desea eliminar al empleado {Nmbr[0]}", "AVISO IMPORTANTE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var consulta = (from empl in BD.EMPLEADO
                                where empl.IDEMPLEADO.Equals(ID)
                                select empl).ToList();
                foreach (var c in consulta) c.BHABILITADO = false;

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha eliminado al empleado: {Nmbr[0]} de forma correcta.");
                    RellenarTabla(tabla: null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }
        }       
    }
}
