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
    public partial class FReservCliente : Form
    {
        ReservaCineDataContext BD = new ReservaCineDataContext();
        public FReservCliente()
        {
            InitializeComponent();
        }
        private void FReservCliente_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(object tabla)
        {
            dgvReservas.DataSource = null;

            if (tabla == null)
            {
                tabla = (from re in BD.RESERVA
                         join cli in BD.CLIENTE
                         on re.IDCLIENTE equals cli.IDCLIENTE
                         join emp in BD.EMPLEADO
                         on re.IDEMPLEADO equals emp.IDEMPLEADO
                         where re.BHABILITADO.Equals(true)
                         select new
                         {
                             ID_RESERVA = re.IDRESERVA,
                             NOMBRE_CLIENTE = cli.NOMBRE,
                             NOMBRE_EMPLEADO = emp.NOMBREEMPLEADO,
                             TOTAL = re.TOTAL
                         }).ToList();
            }
            else if (tabla != null)
            {
                tabla = (from re in BD.RESERVA
                         join cli in BD.CLIENTE
                         on re.IDCLIENTE equals cli.IDCLIENTE
                         join emp in BD.EMPLEADO
                         on re.IDEMPLEADO equals emp.IDEMPLEADO
                         where re.BHABILITADO.Equals(true) &&
                         cli.NOMBRE.Contains(txtNombre.Text)
                         select new
                         {
                             ID_RESERVA = re.IDRESERVA,
                             NOMBRE_CLIENTE = cli.NOMBRE,
                             NOMBRE_EMPLEADO = emp.NOMBREEMPLEADO,
                             TOTAL = re.TOTAL
                         }).ToList();
            }
            dgvReservas.DataSource = tabla;
        }
        private void Filtrado(object sender, EventArgs e)
        {
            RellenarTabla(txtNombre.Text);
        }
    }
}
