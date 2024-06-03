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
    public partial class FMantPeliculas : Form
    {
        public FMantPeliculas()
        {
            InitializeComponent();
        }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        string ID;
        string Nombre;
        private void FMantPeliculas_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            FpUpPeli formulario = new FpUpPeli();
            formulario.accion = "AGREGAR";
            formulario.ShowDialog();

            if(formulario.DialogResult == DialogResult.OK )
            {
                RellenarTabla(tabla: null);
            }
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (ID == "" || ID == null || Nombre == "" || Nombre == null)
            {
                MessageBox.Show($"Debe seleccionar una película, dando click sobre la fila en la tabla, para proceder a editarla.");
                return;
            }

            FpUpPeli formulario = new FpUpPeli();
            formulario.accion = "EDITAR";
            formulario.id = ID;
            formulario.nombre = Nombre;
            formulario.ShowDialog();

            if (formulario.DialogResult == DialogResult.OK)
            {
                RellenarTabla(tabla: null);
            }
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            if(ID == "" || ID == null || Nombre == "" || Nombre == null)
            {
                MessageBox.Show($"Debe seleccionar una película, dando click sobre la fila en la tabla, antes de proceder a eliminar.");
                return;
            }

            if (MessageBox.Show($"¿Realmente desea eliminar la Película: {Nombre} de la tabla de PELICULAS ?","AVISO IMPORTANTE",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var consulta = from pel in BD.PELICULA
                               where pel.IDPELICULA.Equals(ID)
                               select pel;
                foreach (var c in consulta) c.BHABILITADO = false;

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se ha removido la película: {Nombre} de la lista, de forma correcta.");
                    RellenarTabla(tabla: null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex}");
                }
            }

        }
        private void RellenarTabla(object tabla)
        {
            dgvPeliculas.DataSource = null;

            if(tabla == null )
            {
                tabla = from peli in BD.PELICULA
                        join gen in BD.GENERO
                        on peli.IDGENERO equals gen.IDGENERO
                        join pais in BD.PAIS
                        on peli.IDPAIS equals pais.IDPAIS
                        join cen in BD.TIPOCENSURA
                        on peli.IDTIPOCENSURA equals cen.IDTIPOCENSURA
                        where peli.BHABILITADO.Equals(1)
                        select new
                        {
                            ID = peli.IDPELICULA,
                            TÍTULO = peli.TITULO,
                            FECHA_ESTRENO = peli.FECHAESTRENO,
                            GENERO = gen.NOMBRE,
                            PAÍS = pais.NOMBRE,
                            SINÓPSIS = peli.SINOPSIS,
                            DURACIÓN = peli.DURACION,
                            CENSURA = cen.NOMBRE                            
                        };
                dgvPeliculas.DataSource = tabla;
            }
        }
        private void CapturarID(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgvPeliculas.CurrentRow.Cells[0].Value.ToString();
            Nombre = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
        }        
    }
}
