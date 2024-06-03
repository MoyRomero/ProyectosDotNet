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
    public partial class FpUpPeli : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        public string nombre { get; set; }
        bool Validacion = false;
        ReservaCineDataContext BD = new ReservaCineDataContext();
        public FpUpPeli()
        {
            InitializeComponent();
        }
        private void FpUpPeli_Load(object sender, EventArgs e)
        {
            ComboBoxes();

            if (accion == "AGREGAR")
            {
                this.Text = "AGREGANDO NUEVA PELÍCULA";
                lblID.Text = $"{ConteoID()} (NO EDITABLE).";
                btnOk.Text = "AGREGAR";
                groupBox1.Text = "AGREGANDO NUEVA PELÍCULA";
            }
            if (accion == "EDITAR")
            {
                this.Text = "EDITANDO PELÍCULA";
                lblID.Text = $"{id} (NO EDITABLE).";
                btnOk.Text = "ACTUALIZAR";
                groupBox1.Text = $"EDITANDO PELÍCULA: {nombre} ";
                LlenarCampos();
            }
        }
        private void LlenarCampos()
        {
            var consulta = from pel in BD.PELICULA
                           where pel.IDPELICULA.Equals(id)
                           select pel;

            foreach (var c in consulta)
            {
                txtTitulo.Text = c.TITULO ;
                txtFechaEstreno.Text = c.FECHAESTRENO.ToString();
                cmBxGenero.SelectedValue = c.IDGENERO;
                cmBxPais.SelectedValue = c.IDPAIS;
                txtSinopsis.Text = c.SINOPSIS;
                cmBxCensura.SelectedValue = c.IDTIPOCENSURA;
                numDuracion.Value = (decimal)c.DURACION;
            }
        }
        private void ComboBoxes()
        {
            cmBxGenero.DataSource = BD.GENERO;
            cmBxGenero.ValueMember = "IDGENERO";
            cmBxGenero.DisplayMember = "NOMBRE";

            cmBxPais.DataSource = BD.PAIS;
            cmBxPais.ValueMember = "IDPAIS";
            cmBxPais.DisplayMember = "NOMBRE";

            cmBxCensura.DataSource = BD.TIPOCENSURA;
            cmBxCensura.ValueMember = "IDTIPOCENSURA";
            cmBxCensura.DisplayMember = "NOMBRE";
        }
        private int ConteoID()
        {
            int NuevoID = (from pel in BD.PELICULA
                          select pel.IDPELICULA).Count() + 1;
            return NuevoID;
        }
        private void Validaciones(dynamic[] Datos)
        {
            for(int i = 0; i < Datos.Length; i++)
            {   
                if (Datos[i] is string)
                {
                    if (Datos[i] == "" )
                    {
                        MessageBox.Show("Debe llenar todos los campos, para proceder a agregar la nueva Película a la base de datos.");
                        DialogResult = DialogResult.None;
                        return;
                    }
                }
                
                if (Datos[i] is int)
                {
                    if (Datos[i] == 0)
                    {
                        MessageBox.Show("La duración de la Película, debe ser mayor que 0.");
                        DialogResult = DialogResult.None;
                        return;
                    }
                }                
            }
            Validacion = true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            string Titulo = txtTitulo.Text;
            string Sinopsis = txtSinopsis.Text;
            DateTime FechaEstreno = DateTime.Parse(txtFechaEstreno.Text);
            int Genero = int.Parse(cmBxGenero.SelectedValue.ToString());
            int Pais = int.Parse(cmBxPais.SelectedValue.ToString());
            int TipoCensura = int.Parse(cmBxCensura.SelectedValue.ToString());
            int Duracion = int.Parse(numDuracion.Value.ToString());

            dynamic[] Datos = { Titulo, Sinopsis, FechaEstreno, Genero, Pais, TipoCensura, Duracion };

            Validaciones(Datos);

            if (Validacion == true)
            {
                if (accion == "AGREGAR")
                {                               
                    PELICULA pelicula = new PELICULA 
                    {
                        TITULO = Titulo,
                        SINOPSIS = Sinopsis,
                        FECHAESTRENO = FechaEstreno.ToString(),
                        IDGENERO = Genero,
                        IDPAIS = Pais,
                        IDTIPOCENSURA = TipoCensura,
                        DURACION = Duracion,
                        BHABILITADO = true
                    };

                    BD.PELICULA.InsertOnSubmit(pelicula);

                    try
                    {
                        BD.SubmitChanges();
                        MessageBox.Show($"Se ha agregado la película: {Titulo} a la base de datos, de forma correcta.");
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show($"Ocurrió un error: {ex}");
                    }
                }

                if( accion == "EDITAR")
                {
                    var consulta = from pel in BD.PELICULA
                                   where pel.IDPELICULA.Equals(id)
                                   select pel;

                    foreach(var c in consulta)
                    {
                        c.TITULO = Titulo;
                        c.FECHAESTRENO = FechaEstreno.ToString();
                        c.IDGENERO = Genero;
                        c.IDPAIS = Pais;
                        c.SINOPSIS = Sinopsis;
                        c.IDTIPOCENSURA = TipoCensura;
                    }

                    try
                    {
                        BD.SubmitChanges();
                        MessageBox.Show($"Se actualizó la Película: {nombre} de forma correcta.");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex}");
                    }
                }
            }
        }
    }
}
