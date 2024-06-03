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
    public partial class FConsPeliculaGenero : Form
    {
        ReservaCineDataContext BD = new ReservaCineDataContext();
        public FConsPeliculaGenero()
        {
            InitializeComponent();
        }
        private void FConsPeliculaGenero_Load(object sender, EventArgs e)
        {
            RellenarTabla(tabla: null);
        }
        private void RellenarTabla(object tabla)
        {
            cmBxGenero.DataSource = BD.GENERO;
            cmBxGenero.ValueMember = "IDGENERO";
            cmBxGenero.DisplayMember = "NOMBRE";

            dgvPelicula.DataSource = null;

            if(tabla == null)
            {
                tabla = (from pel in BD.PELICULA
                         join gen in BD.GENERO
                         on pel.IDGENERO equals gen.IDGENERO
                         where pel.BHABILITADO.Equals(true)
                         select new
                         {
                             ID_PELICULA = pel.IDPELICULA,
                             TITULO = pel.TITULO,
                             GENERO = gen.NOMBRE,
                             SINOPSIS = pel.SINOPSIS
                         }).ToList();
            }
            else if(tabla != null)
            {
                tabla = (from pel in BD.PELICULA
                         join gen in BD.GENERO
                         on pel.IDGENERO equals gen.IDGENERO
                         where pel.BHABILITADO.Equals(true) &&
                         pel.IDGENERO.Equals(cmBxGenero.SelectedValue)
                         select new
                         {
                             ID_PELICULA = pel.IDPELICULA,
                             TITULO = pel.TITULO,
                             GENERO = gen.NOMBRE,
                             SINOPSIS = pel.SINOPSIS
                         }).ToList();
            }
            dgvPelicula.DataSource = tabla;
        }
        private void FiltradoPorGenero(object sender, EventArgs e)
        {
            RellenarTabla(cmBxGenero.SelectedItem);
        }
    }
}

