using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace SistemaReservaCine
{
    public partial class FpUpFunc : Form
    {
        public FpUpFunc()
        {
            InitializeComponent();
        }
        public string accion { get; set; }
        public string id { get; set; }
        public string nombre { get; set; }
        ReservaCineDataContext BD = new ReservaCineDataContext();
        List<CENTRADA> ListaEntrada = new List<CENTRADA>();
        private void FpUpFunc_Load(object sender, EventArgs e)
        {
            ComboBoxRell();

            if (accion == "AGREGAR")
            {
                this.Text = "AGREGANDO NUEVA FUNCIÓN";
                btnOk.Text = "AGREGAR";                
            }
            if(accion == "EDITAR")
            {
                RecuperarValores();
                this.Text = "EDITANDO FUNCIÓN";
                btnOk.Text = "ACTUALIZAR";
            }
        }        
        private void ComboBoxRell()
        {
            cmBxPelicula.DataSource = BD.PELICULA;
            cmBxPelicula.ValueMember = "IDPELICULA";
            cmBxPelicula.DisplayMember = "TITULO";

            cmBxCine.DataSource = BD.CINE;
            cmBxCine.ValueMember = "IDCINE";
            cmBxCine.DisplayMember = "NOMBRE";

            cmBxTipoEntrada.DataSource = BD.TIPOENTRADA;
            cmBxTipoEntrada.ValueMember = "IDTIPOENTRADA";
            cmBxTipoEntrada.DisplayMember = "NOMBRE";
        }
        private string[] CapturaDatos()
        {
            string[] Datos = { 
                                Convert.ToString(txtFechaFuncion.Value), 
                                cmBxPelicula.SelectedValue.ToString(),
                                cmBxCine.SelectedValue.ToString(),
                                cmBxSala.SelectedValue.ToString() };
            return Datos;
        }
        private void CmBxSala(object sender, EventArgs e)
        {
            cmBxSala.DataSource = from sala in BD.SALA
                                  where sala.IDCINE.Equals(cmBxCine.SelectedValue)
                                  select sala;
            cmBxSala.ValueMember = "IDSALA";
            cmBxSala.DisplayMember = "NOMBRE";
        }
        private void RecuperarValores()
        {
            var consulta = from fun in BD.FUNCION
                           where fun.IDFUNCION.Equals(id)
                           select fun;
            foreach(var cons in consulta)
            {
                lblID.Text = $"{cons.IDFUNCION.ToString()} (NO EDITABLE).";
                txtFechaFuncion.Text = cons.FECHAFUNCION.ToString();
                cmBxPelicula.SelectedValue = cons.IDPELICULA;
                cmBxCine.SelectedValue = cons.IDCINE;
                cmBxSala.SelectedValue = cons.IDSALA;
            }
            var consultaPrecios = from pre in BD.FUNCIONENTRADA
                                  join tipo in BD.TIPOENTRADA
                                  on pre.IDTIPOENTRADA equals tipo.IDTIPOENTRADA
                                  where pre.IDFUNCION.Equals(id)
                                  select new { 
                                      NOMBRE = tipo.NOMBRE, 
                                      PRECIO = pre.PRECIO };

            dgvPrecios.DataSource = consultaPrecios;
        }
        private int ConteoID()
        {
            int nuevoIDFuncion = (from id in BD.FUNCION
                                  select id.IDFUNCION).Max() + 1;
            return nuevoIDFuncion;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            string[] Datos = CapturaDatos();

            if(accion == "AGREGAR")
            {
                if (dgvPrecios.Rows.Count.Equals(0))
                {
                    MessageBox.Show("No puede continuar sin ingresar todos los precios, por favor ingrese precios para todo tipo de entradas.");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                try
                {
                    using(var transaction = new TransactionScope())
                    {
                        FUNCION funcion = new FUNCION
                        {                            
                            FECHAFUNCION = DateTime.Parse(Datos[0]),
                            IDPELICULA = int.Parse(Datos[1]),
                            IDCINE = int.Parse(Datos[2]),
                            IDSALA = int.Parse(Datos[3]),
                            BHABILITADO = true
                        };

                        BD.FUNCION.InsertOnSubmit(funcion);

                        BD.SubmitChanges();                        

                        int idFuncion = funcion.IDFUNCION;
                        int columnas = 0;
                        int filas = 0;
                        var consultas = from col in BD.SALA
                                        where col.IDSALA.Equals(Datos[3])
                                        select col;

                        foreach(var cons in consultas)
                        {
                            columnas = (int)cons.NUMEROCOLUMNAS;
                            filas = (int)cons.NUMEROFILAS;
                        }

                        int contAsiento = 1;
                        for (int i = 1;  i <= filas; i++)
                        {
                            for(int j = 1; j <= columnas; j++)
                            {                           
                                BUTACA asiento = new BUTACA
                                {
                                    IDFUNCION = idFuncion,
                                    IDBUTACA = contAsiento,
                                    INDICEFILA = i,
                                    INDICECOLUMNA = j,
                                    BHABILITADO = true,
                                    BLIBRE = true
                                };

                                BD.BUTACA.InsertOnSubmit(asiento);

                                contAsiento++;
                            }
                        }

                        for(int i = 0; i < ListaEntrada.Count; i++)
                        {
                            FUNCIONENTRADA funcionEntrada = new FUNCIONENTRADA
                            {
                                IDFUNCION = idFuncion,
                                IDTIPOENTRADA = ListaEntrada[i].idTipoEntrada,
                                PRECIO = ListaEntrada[i].precioEntrada,
                                BHABILITADO = true
                            };

                            BD.FUNCIONENTRADA.InsertOnSubmit(funcionEntrada);
                        }                           

                        BD.SubmitChanges();
                        transaction.Complete();
                        MessageBox.Show("Se ha agregado la FUNCIÓN de manera correcta.");
                    }               
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                    this.DialogResult = DialogResult.None;
                }
            }
            if (accion == "EDITAR")
            {
                var consulta = from fun in BD.FUNCION
                               where fun.IDFUNCION.Equals(id)
                               select fun;

                foreach(var c in consulta)
                {
                    c.FECHAFUNCION = DateTime.Parse(Datos[0]);
                    c.IDPELICULA = int.Parse(Datos[1]);
                    c.IDCINE = int.Parse(Datos[2]);
                    c.IDSALA = int.Parse(Datos[3]);
                }

                try
                {
                    BD.SubmitChanges();
                    MessageBox.Show($"Se han realizado los cambios de forma correcta.");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}");
                }
            }
        }
        private void btnPrecio_Click(object sender, EventArgs e)
        {
            int IDTipoEntrada = ((TIPOENTRADA)cmBxTipoEntrada.SelectedItem).IDTIPOENTRADA;
            string nombre = ((TIPOENTRADA)cmBxTipoEntrada.SelectedItem).NOMBRE;
            decimal precio = numPrecio.Value;

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que 0");
                return;
            }

            var repetido = (from entrada in ListaEntrada
                           where entrada.idTipoEntrada.Equals(IDTipoEntrada)
                           select entrada).Count();

            if( repetido > 0 )
            {
                MessageBox.Show($"Ya se registró un precio para el tipo de entrada: {nombre}");
                return;
            }              

                dgvPrecios.DataSource = null;

                ListaEntrada.Add(new CENTRADA
                {
                    idTipoEntrada = IDTipoEntrada,
                    nombreTipoEntrada = nombre,
                    precioEntrada = precio
                });

                dgvPrecios.DataSource = (from pre in ListaEntrada
                                        select new { NOMBRE = pre.nombreTipoEntrada, PRECIO = pre.precioEntrada }).ToList();
         
        }
    }
}
