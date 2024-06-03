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
    public partial class FPopUp : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        public FPopUp()
        {
            InitializeComponent();
        }
        ReservaCineDataContext  BD = new ReservaCineDataContext();
        private void FPopUp_Load(object sender, EventArgs e)
        {
            ComboBoxSx();

            if (accion == "AGREGAR")
            {
                grpMantenimiento.Text = "AGREGANDO NUEVO CLIENTE";               
                btnOk.Text = "AGREGAR";
                this.Text = "AGREGAR CLIENTE";
                lblID.Text = $"{ConteoID()} (NO EDITABLE).";                               
            }

            if (accion == "EDITAR")
            {                
                btnOk.Text = "ACTUALIZAR";
                this.Text = "EDITAR CLIENTE";               

                var consulta = (from idcl in BD.CLIENTE
                                where idcl.IDCLIENTE.Equals(id)
                               select idcl).ToList();

                foreach(var c in consulta)
                {
                    grpMantenimiento.Text = $"EDITANDO CLIENTE: {c.NOMBRE} {c.APPATERNO} {c.APMATERNO}";
                    lblID.Text = $"{ c.IDCLIENTE.ToString()} (NO EDITABLE).";
                    txtDNICliente.Text = c.DNICLIENTE;
                    txtNombre.Text = c.NOMBRE;
                    txtApellidoP.Text = c.APPATERNO;
                    txtApellidoM.Text = c.APMATERNO;
                    txtFechaNac.Text = c.FECHANAC.ToString();
                    txtDireccion.Text = c.DIRECCION;
                    txtTelFijo.Text = c.TELEFONOFIJO;
                    txtTelCel.Text = c.TELEFONOCELULAR;
                    cmBxSexo.SelectedValue = c.IDSEXO;
                }
            }
        }
        private string ConteoID()
        {
            var conteo = (from idcl in BD.CLIENTE select idcl.IDCLIENTE).ToList();
            string c = (conteo.Count() + 1).ToString();
            return c;
        }
        private void ComboBoxSx()
        {
            cmBxSexo.DataSource = BD.SEXO;
            cmBxSexo.ValueMember = "IDSEXO";
            cmBxSexo.DisplayMember = "NOMBRE";
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            string DNIClie = txtDNICliente.Text;
            string Nombre = txtNombre.Text;
            string Appaterno = txtApellidoP.Text;
            string Apmaterno = txtApellidoM.Text;
            string fnacimien = txtFechaNac.Text;
            string direccion = txtDireccion.Text;
            string telfijo = txtTelFijo.Text;
            string telcel = txtTelCel.Text;
            string sexo = cmBxSexo.SelectedValue.ToString();

            if (accion == "AGREGAR")
            {          
                if (DNIClie == "" || Nombre == "" || Appaterno == "" || Apmaterno == "" || fnacimien == "" || direccion == "" || telfijo == "" || telcel == "" || sexo == "")
                {
                    MessageBox.Show("Debe llenar todos los campos.", "AVISO");
                    return;
                }
                else
                {
                    CLIENTE clien = new CLIENTE
                    {
                        DNICLIENTE = DNIClie,
                        NOMBRE = Nombre,
                        APPATERNO = Appaterno,
                        APMATERNO = Apmaterno,
                        FECHANAC = DateTime.Parse(fnacimien),
                        DIRECCION = direccion,
                        TELEFONOFIJO = telfijo,
                        TELEFONOCELULAR = telcel,
                        IDSEXO = int.Parse(sexo),
                        BHABILITADO = true
                    };

                    BD.CLIENTE.InsertOnSubmit(clien);

                    try
                    {
                        BD.SubmitChanges();
                        MessageBox.Show("Se añadieron los datos, de forma correcta.");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex}");
                    }
                }
            }

            if (accion == "EDITAR")
            { 
                var consulta = (from c in BD.CLIENTE
                                where c.IDCLIENTE.Equals(id)
                                select c).ToList();

                foreach(var c in consulta)
                {
                    c.DNICLIENTE = DNIClie;
                    c.NOMBRE = Nombre;
                    c.APPATERNO = Appaterno;
                    c.APMATERNO = Apmaterno;
                    c.FECHANAC = DateTime.Parse(fnacimien);
                    c.DIRECCION = direccion;
                    c.TELEFONOFIJO = telfijo;
                    c.TELEFONOCELULAR = telcel;
                    c.IDSEXO = int.Parse(sexo);
                }

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se han realizado los cambios del cliente: {Nombre} {Appaterno} {Apmaterno}, de forma correcta.");
                }
                catch( Exception ex )
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }
        }
    }
}