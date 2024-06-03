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
    public partial class FpUpCine : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        public FpUpCine()
        {
            InitializeComponent();
        }
        private void FpUpCine_Load(object sender, EventArgs e)
        {
            ComboBoxTipoCine();

            if (accion == "AGREGAR")
            {
                this.Text = "AGREGAR NUEVO CINE";
                btnOk.Text = "AGREGAR";
                grpPopUp.Text = "AGREGANDO NUEVO CINE";
                lblID.Text = $"{ConteoID()} (NO EDITABLE).";
            }

            if (accion == "EDITAR")
            {
                this.Text = "ACTUALIZANDO CINE";
                btnOk.Text = "ACTUALIZAR";
                CapturaDatos();
            }
        }
        private void CapturaDatos()
        {
            var consulta = from cine in BD.CINE
                           where cine.IDCINE.Equals(id)
                           select cine;
            foreach (var c in consulta)
            {
                grpPopUp.Text = $"ACTUALIZANDO CINE: {c.NOMBRE}";
                lblID.Text = $"{c.IDCINE.ToString()} (NO EDITABLE).";
                txtNombre.Text = c.NOMBRE.ToString();
                txtDireccion.Text = c.DIRECCION.ToString();
                txtFechaApertura.Text = c.FECHAAPERTURA.ToString();
                cmBxTipoCine.SelectedValue = c.IDTIPOCINE;
            }
        }
        private void ComboBoxTipoCine()
        {
            cmBxTipoCine.DataSource = BD.TIPOCINE;
            cmBxTipoCine.ValueMember = "IDTIPOCINE";
            cmBxTipoCine.DisplayMember = "NOMBRE";
        }
        private string ConteoID()
        {
            var conteo = (from cin in BD.CINE select cin.IDCINE).ToList();
            string c = (conteo.Count() + 1).ToString();
            return c;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string fecha = txtFechaApertura.Text;

            if (accion == "AGREGAR")
            {
               if(nombre != "" && direccion != "" && fecha != "")
                {
                    CINE cine = new CINE
                    {
                        NOMBRE = nombre,
                        DIRECCION = direccion,
                        FECHAAPERTURA = DateTime.Parse(fecha),
                        IDTIPOCINE = int.Parse(cmBxTipoCine.SelectedValue.ToString()),
                        BHABILITADO = 1
                    };

                    BD.CINE.InsertOnSubmit(cine);

                    try
                    {
                        BD.SubmitChanges();
                        MessageBox.Show($"Se ha agregado el nuevo CINE: {nombre} de forma correcta a la base de datos.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex}");
                    }
                }

                else
                {
                    MessageBox.Show("Debe rellenar todos los campos para proceder a agregar un nuevo CINE.");
                    DialogResult = DialogResult.None;
                    return;
                }
            }
            
            if (accion == "EDITAR")
            {
                var consulta = from cine in BD.CINE
                               where cine.IDCINE.Equals(id)
                               select cine;

                foreach (var c in consulta)
                {
                    c.NOMBRE = txtNombre.Text;
                    c.DIRECCION = txtDireccion.Text;
                    c.FECHAAPERTURA = DateTime.Parse(txtFechaApertura.Text);
                    c.IDTIPOCINE = int.Parse(cmBxTipoCine.SelectedValue.ToString());
                }

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se han actualizado los datos del CINE: {nombre} de forma correcta.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }
        }
    }
}
