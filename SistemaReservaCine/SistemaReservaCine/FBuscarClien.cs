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
    public partial class FBuscarClien : Form
    {
        public string nombreCliente { get; set; }
        public string ID_CLIENTE { get; set; }
        public FBuscarClien()
        {
            InitializeComponent();
        }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        private void FBuscarClien_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvClientes.DataSource = null;

            if (tabla == null)
            {
                tabla = from clien in BD.CLIENTE
                        where clien.BHABILITADO.Equals(true)
                        select new
                        {
                            ID_CLIENTE = clien.IDCLIENTE,
                            DNI = clien.DNICLIENTE,
                            NOMBRE_COMPLETO = $"{clien.NOMBRE} {clien.APPATERNO} {clien.APMATERNO}"                            
                        };
            }

            else if (tabla != null)
            {
                tabla = from clien in BD.CLIENTE
                        where clien.BHABILITADO.Equals(true)
                        && (clien.APMATERNO.Contains(txtApellidos.Text)
                        || clien.APPATERNO.Contains(txtApellidos.Text))
                        select new
                        {
                            ID_CLIENTE = clien.IDCLIENTE,
                            DNI = clien.DNICLIENTE,
                            NOMBRE_COMPLETO = $"{clien.NOMBRE} {clien.APPATERNO} {clien.APMATERNO}"
                        };
            }
            dgvClientes.DataSource = tabla;
        }
        private void FiltrarApellidos(object sender, EventArgs e)
        {
            RellenarTabla(tabla:txtApellidos.Text);
        }
        private void CapturarDatosCliente(object sender, EventArgs e)
        {
            ID_CLIENTE = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            nombreCliente = dgvClientes.CurrentRow.Cells[2].Value.ToString();

            this.DialogResult = DialogResult.OK;
        }
    }
}
