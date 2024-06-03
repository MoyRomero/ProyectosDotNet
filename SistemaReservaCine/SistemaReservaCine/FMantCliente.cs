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
    public partial class FMantCliente : Form
    {
        public FMantCliente()
        {
            InitializeComponent();
        }

        ReservaCineDataContext BD = new ReservaCineDataContext();
        string ID;
        string nombre;

        private void FMantCliente_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla (object tabla)
        {
            dgvClientes.DataSource = null;

            if (tabla == null)
            {
                tabla = (from c in BD.CLIENTE
                         join s in BD.SEXO
                         on c.IDSEXO equals s.IDSEXO
                         where c.BHABILITADO.Equals(1)
                         select new
                         {
                             ID = c.IDCLIENTE,
                             DNI= c.DNICLIENTE,
                             NOMBRE = c.NOMBRE,
                             APELLIDOS = $"{c.APPATERNO} {c.APMATERNO}",
                             F_NACIMIENTO = c.FECHANAC,
                             DIRECCION = c.DIRECCION,
                             TEL_FIJO = c.TELEFONOFIJO,
                             TEL_CEL = c.TELEFONOCELULAR,
                             SEXO = s.NOMBRE
                         }).ToList();
            }

            dgvClientes.DataSource = tabla;
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FPopUp Formulario = new FPopUp();
            Formulario.accion = "AGREGAR";
            Formulario.ShowDialog();

            if(Formulario.DialogResult == DialogResult.OK)
            {
                RellenarTabla(tabla : null);
            }
            
        }        
        private void CapturaDatos(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            nombre = dgvClientes.CurrentRow.Cells[2].Value.ToString();
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if(ID == null || ID == "" || ID == "0")
            {
                MessageBox.Show("Seleccione un cliente dando click sobre alguna fila en la tabla de clientes, para proceder a editar sus datos.");
                return;
            }

            FPopUp formulario = new FPopUp();
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
            if(MessageBox.Show($"¿Realmente desea eliminar al cliente: {nombre}?","AVISO: ELIMINANDO",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {            
                var consulta = from clien in BD.CLIENTE
                               where clien.IDCLIENTE.Equals(ID)
                               select clien;
                foreach( var clien in consulta )
                {                
                    clien.BHABILITADO = false;
                }

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha eliminado el cliente {nombre}");
                    RellenarTabla(tabla:null);
                }
                catch( Exception ex )
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }
        }
    }
}
