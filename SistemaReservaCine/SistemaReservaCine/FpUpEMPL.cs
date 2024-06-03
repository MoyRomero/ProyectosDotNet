using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaReservaCine
{
    public partial class FpUpEMPL : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        public FpUpEMPL()
        {
            InitializeComponent();
        }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        string Nombre;
        private void FpUpEMPL_Load(object sender, EventArgs e)
        {
            LlenarCmBx();

            if (accion == "AGREGAR")
            {
                this.Text = "AGREGANDO EMPLEADO";
                btnOk.Text = "AGREGAR";
                txtUsuario.ReadOnly = false;
                grpMantenimiento.Text = "AGREGANDO NUEVO EMPLEADO";                
                lblID.Text = $"{ConteoID()} (NO EDITABLE).";
            }

            if (accion == "EDITAR")
            {
                this.Text = $"EDITANDO EMPLEADO";
                txtUsuario.ReadOnly = true;
                chRev.Visible = false;
                lblContra.Visible = false;
                txtContraseña.Visible = false;
                grpMantenimiento.Text = NombreEmp();
                lblID.Text = $"{id} (NO EDITABLE).";
                btnOk.Text = "ACTUALIZAR";
                LlenadoCampos();
            }
        }
        private string NombreEmp()
        {            
            var empleado = from empl in BD.EMPLEADO
                           where empl.IDEMPLEADO.Equals(id)
                           select new { empl.NOMBREEMPLEADO, empl.APPATERNO, empl.APMATERNO };

            foreach (var em in empleado) Nombre = ($"EDITANDO EMPLEADO: {em.NOMBREEMPLEADO} {em.APPATERNO} {em.APMATERNO}").ToString();
            
            return Nombre;
        }
        private string ConteoID()
        {
            var conteo = (from emp in BD.EMPLEADO select emp.IDEMPLEADO).ToList();
            string c = (conteo.Count() + 1).ToString();
            return c;
        }
        private void LlenarCmBx()
        {
            cmBxModalidad.DataSource = BD.TIPOMODALIDAD;
            cmBxModalidad.ValueMember = "IDTIPOMODALIDAD";
            cmBxModalidad.DisplayMember = "NOMBRE";

            cmBxTipoEmpleado.DataSource = BD.TIPOEMPLEADO;
            cmBxTipoEmpleado.ValueMember = "IDTIPOEMPLEADO";
            cmBxTipoEmpleado.DisplayMember = "NOMBRE";

        }
        private string[] CapturaValores()
        {
            string[] datos =
            {
                txtNombre.Text,
                txtApellidoP.Text,
                txtApellidoM.Text,
                txtSueldo.Text,
                txtFechaInicio.Text,
                cmBxModalidad.SelectedValue.ToString(),
                cmBxTipoEmpleado.SelectedValue.ToString(),
                txtUsuario.Text
            };

            return datos;
        }
        private void LlenadoCampos()
        {
            var consulta = (from empl in BD.EMPLEADO
                            where empl.IDEMPLEADO.Equals(id)
                            select empl).ToList();

            foreach(var  cons in consulta)
            {
                txtNombre.Text = cons.NOMBREEMPLEADO.ToString();
                txtApellidoP.Text = cons.APPATERNO.ToString();
                txtApellidoM.Text = cons.APMATERNO.ToString();
                txtSueldo.Text = cons.SUELDO.ToString();
                txtFechaInicio.Text = cons.FECHAINICIO.ToString();
                txtUsuario.Text = cons.USUARIO.ToString();
                cmBxModalidad.SelectedValue = cons.IDTIPOMODALIDAD;
                cmBxTipoEmpleado.SelectedValue = cons.IDTIPOEMPLEADO;
            }
        }
        private string Encriptar(string Contra)
        {
            SHA256Managed Osha256M = new SHA256Managed();
            byte[] bufferCadena = Encoding.Default.GetBytes(Contra);
            byte[] bufferCadenaCif = Osha256M.ComputeHash(bufferCadena);
            string ContraCifrada = BitConverter.ToString(bufferCadenaCif);

            return ContraCifrada;
        }
        private string DesEncriptar(byte[] ContraEncriptada)
        {
            string cadena = Encoding.UTF8.GetString(ContraEncriptada);
            return cadena;
        }
     //public static string Encriptar(dynamic Dato)
    //{
    //    string result = string.Empty;
    //    byte[] encryted = System.Text.Encoding.Unicode.GetBytes(Dato);
    //    result = Convert.ToBase64String(encryted);
    //    return result;
    //}
    //public static string DesEncriptar(dynamic Dato)
    //{
    //    string result = string.Empty;
    //    byte[] decryted = Convert.FromBase64String(Dato);
    //    //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
    //    result = System.Text.Encoding.Unicode.GetString(decryted);
    //    return result;
    //}   
        private void btnOk_Click(object sender, EventArgs e)
        {
            string[] Datos = CapturaValores();
            int i = 0;

            while(Datos.Length > i)
            {
                if (Datos[i] == "")
                {
                    MessageBox.Show("Debe llenar todos los campos para proceder a AGREGAR un nuevo empleado.");
                    DialogResult = DialogResult.None;
                    return;
                }
                i++;
            }
            if(accion == "AGREGAR")
            {          
                EMPLEADO empleado = new EMPLEADO
                {
                    NOMBREEMPLEADO = Datos[0],
                    APPATERNO = Datos[1],
                    APMATERNO = Datos[2],
                    SUELDO = int.Parse(Datos[3]),
                    FECHAINICIO = DateTime.Parse(Datos[4]),
                    IDTIPOMODALIDAD = int.Parse(Datos[5]),
                    IDTIPOEMPLEADO = int.Parse(Datos[6]),
                    USUARIO = Datos[7],
                    CONTRA = Encriptar(txtContraseña.Text),
                    BHABILITADO = true,
                    BBLOQUEADO = false                
                };

                BD.EMPLEADO.InsertOnSubmit(empleado);

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha agregado el empleado: {Datos[0]} a la base de datos, de forma correcta.", "AVISO");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }
            if(accion == "EDITAR")
            {
                var consulta = (from empl in BD.EMPLEADO
                               where empl.IDEMPLEADO.Equals(id)
                               select empl).ToList();

                foreach(var em in consulta)
                {
                    em.NOMBREEMPLEADO = Datos[0];
                    em.APPATERNO = Datos[1];
                    em.APMATERNO = Datos[2];
                    em.SUELDO = int.Parse(Datos[3]);
                    em.FECHAINICIO = DateTime.Parse(Datos[4]);
                    em.IDTIPOMODALIDAD = int.Parse(Datos[5]);
                    em.IDTIPOEMPLEADO = int.Parse(Datos[6]);
                }

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se actualizaron los datos del empleado: {Datos[0]} de forma correcta.", "AVISO");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }
        }
        private void OcultarRevelar(object sender, EventArgs e)
        {
            if (chRev.Checked)
            {
                txtContraseña.PasswordChar = '\0';
            }
            else
            {
                txtContraseña.PasswordChar = '*';
            }
        }
    }
}
