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
    public partial class FpUpSalas : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        bool validado = false;
        ReservaCineDataContext BD = new ReservaCineDataContext();
        public FpUpSalas()
        {
            InitializeComponent();
        }
        private void FpUpSalas_Load(object sender, EventArgs e)
        {
            CmBxCine();

            if (accion == "AGREGAR")
            {
                this.Text = "AGREGANDO NUEVA SALA";
                lblID.Text = ConteoID().ToString();
                btnOk.Text = "AGREGAR";
            }

            if(accion == "EDITAR")
            {
                this.Text = $"EDITANDO SALA";
                lblID.Text = $"{id} (NO EDITABLE).";
                grpMantenimiento.Text = $"EDITANDO SALA (ID: {id})";
                btnOk.Text = "ACTUALIZAR";
                CapturarValores();
            }
        }
        private void CapturarValores()
        {
            var consulta = from sala in BD.SALA
                           where sala.IDSALA.Equals(id)
                           select sala;

            foreach (var c in consulta)
            {
                cmBxIdCine.SelectedValue = c.IDCINE;
                numAsientos.Value = (decimal)c.NUMBUTACAS;
                numFilas.Value = (decimal)c.NUMEROFILAS;
                numColumnas.Value = (decimal)c.NUMEROCOLUMNAS;
            }
        }
        private void CmBxCine()
        {
            cmBxIdCine.DataSource = BD.CINE;
            cmBxIdCine.ValueMember = "IDCINE";
            cmBxIdCine.DisplayMember = "NOMBRE";
        }
        private int ConteoID()
        {
            int total = (from id in BD.SALA
                           select id.IDSALA).Count();
            return total + 1;
        }
        private void ValidacionesAsientos(int Asientos, int Filas, int Columnas)
        {
            if (Asientos <= 0 || Filas <= 0 || Columnas <= 0)
            {
                MessageBox.Show("\" NUMERO DE ASIENTOS\",\" NUMERO DE FILAS\" y \" NUMERO DE COLUMNAS\" deben ser mayor a 0.");
                DialogResult = DialogResult.None;
                return;
            }

            if ((Filas * Columnas) > Asientos)
            {
                MessageBox.Show($"El número de FILAS ({Filas}) * COLUMNAS ({Columnas}) ({Filas} * {Columnas} = {Filas * Columnas}), debe ser menor que el número de ASIENTOS: ({Asientos}).");
                DialogResult = DialogResult.None;
                return;
            }
            validado = true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            int Cine = (int)cmBxIdCine.SelectedValue;
            int Asientos = (int)numAsientos.Value;
            int Filas = (int)numFilas.Value;
            int Columnas = (int)numColumnas.Value;            
            int NuevoID = ConteoID();

            if(accion == "AGREGAR")
            {
                ValidacionesAsientos(Asientos, Filas, Columnas);

                if(validado == true) {

                    SALA sala = new SALA 
                    {
                        IDCINE = (int)Cine,
                        NUMBUTACAS = (int)Asientos,
                        NUMEROFILAS = (int)Filas,
                        NUMEROCOLUMNAS = (int)Columnas,
                        BHABILITADO = true
                    };

                    BD.SALA.InsertOnSubmit(sala);

                    try
                    {
                        BD.SubmitChanges();
                        MessageBox.Show($"Se agregó la sala con el ID: {NuevoID} a la base de datos, de forma correcta.");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex}");
                    }
                }
            }
            
            if( accion == "EDITAR")
            {                
                ValidacionesAsientos(Asientos, Filas, Columnas);

                if (validado == true) 
                { 
                    var consulta = from sala in BD.SALA
                                   where sala.IDSALA.Equals(id)
                                   select sala;

                    foreach (var c in consulta)
                    {
                        c.IDCINE = Cine;
                        c.NUMBUTACAS = Asientos;
                        c.NUMEROFILAS = Filas;
                        c.NUMEROCOLUMNAS = Columnas;
                    }

                    try
                    {
                        BD.SubmitChanges();
                        MessageBox.Show($"Se actualizó la sala de ID: {id}, de forma correcta.");
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
