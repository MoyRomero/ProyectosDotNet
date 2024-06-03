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
    public partial class FBuscarEmpl : Form
    {
        public string nombreEmpleado { get; set; }
        public string codigoEmpleado { get; set; }
        public FBuscarEmpl()
        {
            InitializeComponent();
        }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        private void FBuscarEmpl_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla:null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvEmpleados.DataSource = null;

            if (tabla == null )
            {
                tabla = from empl in BD.EMPLEADO
                        where empl.BBLOQUEADO.Equals(false)
                        && empl.BHABILITADO.Equals(true)
                        select new 
                        {            
                            CODIGO = empl.IDEMPLEADO,
                            NOMBRE_COMPLETO = $"{empl.NOMBREEMPLEADO} {empl.APPATERNO} {empl.APMATERNO}",
                            FECHA_INICIO = empl.FECHAINICIO
                        };
            }

            else if (tabla != null)
            {
                tabla = from empl in BD.EMPLEADO
                        where (empl.BBLOQUEADO.Equals(false)
                        && empl.BHABILITADO.Equals(true)) &&
                        (empl.APMATERNO.Contains(txtApellidos.Text)
                        || empl.APPATERNO.Contains(txtApellidos.Text))
                        select new
                        {
                            CODIGO = empl.IDEMPLEADO,
                            NOMBRE_COMPLETO = $"{empl.NOMBREEMPLEADO} {empl.APPATERNO} {empl.APMATERNO}",
                            FECHA_INICIO = empl.FECHAINICIO
                        };
            }
            dgvEmpleados.DataSource = tabla;
        }
        private void FiltradoApellidos(object sender, EventArgs e)
        {
            RellenarTabla(tabla: txtApellidos.Text);
        }
        private void CapturaDatosEmpleado(object sender, EventArgs e)
        {
            codigoEmpleado = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
            nombreEmpleado = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();

            this.DialogResult = DialogResult.OK;            
        }
    }
}
