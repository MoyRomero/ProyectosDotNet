using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Transactions;

namespace SistemaReservaCine
{
    public partial class FProceso : Form
    {
        ReservaCineDataContext BD = new ReservaCineDataContext();

        List<CRESERVA> NuevaReserva = new List<CRESERVA>();

        bool DatosGeneralesValidados = false;

        int? id = null;

        public FProceso()
        {
            InitializeComponent();
        }
        private void FProceso_Load(object sender, EventArgs e)
        {
            ComboBoxGUI();
            RellenarTablaClientes(tabla: null);
        }
        private void FondoNegro(DataGridView tabla)
        {
            tabla.ForeColor = System.Drawing.Color.Black;
        }
        private void RellenarTablaClientes(object tabla) 
        {
            dgvClientes.DataSource = null;

            FondoNegro(dgvClientes);

            if (tabla == null)
            {
                tabla = (from cli in BD.CLIENTE
                        where cli.BHABILITADO.Equals(1)
                        select new
                        {
                            DNI = cli.DNICLIENTE,
                            NOMBRE = $"{cli.NOMBRE} {cli.APPATERNO} {cli.APMATERNO}",
                            FECHA_NACI = cli.FECHANAC,
                            TEL_FIJO = cli.TELEFONOFIJO,
                            TEL_CEL = cli.TELEFONOCELULAR
                        }).ToList();
            }
            else if (tabla != null)
            {
                tabla = (from cli in BD.CLIENTE
                        where cli.BHABILITADO.Equals(1) &&
                        (cli.APPATERNO.Contains(txtApellidos.Text) ||
                        cli.APMATERNO.Contains(txtApellidos.Text))
                        select new
                        {
                            DNI = cli.DNICLIENTE,
                            NOMBRE = $"{cli.NOMBRE} {cli.APPATERNO} {cli.APMATERNO}",
                            FECHA_NACI = cli.FECHANAC,
                            TEL_FIJO = cli.TELEFONOFIJO,
                            TEL_CEL = cli.TELEFONOCELULAR
                        }).ToList();
            }           

            dgvClientes.DataSource = tabla;
        }
        private void btnBuscarCdEmpleado_Click(object sender, EventArgs e)
        {
            FBuscarEmpl formulario = new FBuscarEmpl();
            formulario.ShowDialog();

            if(formulario.DialogResult == DialogResult.OK)
            {
                txtNombreEmpleado.Text = formulario.nombreEmpleado;
                txtCodEmpleado.Text = formulario.codigoEmpleado;
            }
        }
        private void btnBuscarDNI_Click(object sender, EventArgs e)
        {
            FBuscarClien formulario = new FBuscarClien();
            formulario.ShowDialog();

            if (formulario.DialogResult == DialogResult.OK)
            {
                txtNombreCliente.Text = formulario.nombreCliente;
                txtIDCliente.Text = formulario.ID_CLIENTE;
            }
        }
        private void ComboBoxGUI()
        {
            cmBxCine.DataSource = BD.CINE;
            cmBxCine.ValueMember = "IDCINE";
            cmBxCine.DisplayMember = "NOMBRE";
        }
        private void ObtencionPeliculas(object sender, EventArgs e)
        {
            if(cmBxCine.SelectedValue != null)
            {            
                int IDCine = ((CINE)cmBxCine.SelectedItem).IDCINE;

                var peliculas = (from fun in BD.FUNCION
                                 join pel in BD.PELICULA
                                 on fun.IDPELICULA equals pel.IDPELICULA
                                 where fun.IDCINE.Equals(IDCine)
                                 && fun.FECHAFUNCION > DateTime.Now
                                 select new CPELICULA
                                 {
                                     IDpelicula = pel.IDPELICULA,
                                     TitPelicula = pel.TITULO

                                 }).Distinct().ToList();

                if(peliculas.Count() == 0)
                {
                    cmBxPelicula.Text = null;
                    cmBxFuncion.Text = null;
                    cmBxFuncion.DataSource = null;
                    cmBxTipoEntrada.DataSource = null;
                    txtSala.Text = "";
                    lblPeso.Visible = false;
                    lblPrecio.Text = "";
                }

                cmBxPelicula.DataSource = peliculas;
                cmBxPelicula.ValueMember = "IDpelicula";
                cmBxPelicula.DisplayMember = "TitPelicula";
            }
        }
        private void ObtencionFunciones(object sender, EventArgs e)
        {
            if(cmBxPelicula.SelectedValue != null )
            {

                int IDCine = ((CINE)cmBxCine.SelectedItem).IDCINE;
                int IDPelicula = ((CPELICULA)cmBxPelicula.SelectedItem).IDpelicula;

                var funciones = (from fun in BD.FUNCION
                                 where fun.IDCINE.Equals(IDCine) &&
                                 fun.IDPELICULA.Equals(IDPelicula) &&
                                 fun.FECHAFUNCION > DateTime.Now
                                 select new CFUNCION
                                 {
                                     FECHA = (DateTime) fun.FECHAFUNCION,
                                     IDFUNCION = fun.IDFUNCION

                                 }).ToList();

                    cmBxFuncion.DataSource = funciones;
                    cmBxFuncion.ValueMember = "IDFUNCION";
                    cmBxFuncion.DisplayMember = "FECHA";
            }
        }
        private void ObtencionSala(object sender, EventArgs e)
        {
            if (cmBxFuncion.SelectedValue != null)
            {
                int IDFuncion = ((CFUNCION)cmBxFuncion.SelectedItem).IDFUNCION;

                var consultaSala = from fun in BD.FUNCION
                                   join sala in BD.SALA
                                   on fun.IDSALA equals sala.IDSALA
                                   where fun.IDFUNCION.Equals(IDFuncion)
                                   select new { fun, sala };

                foreach (var sala in consultaSala)
                {
                    txtSala.Text = sala.sala.NOMBRE;

                    FondoNegro(dgvAsientos);

                    dgvAsientos.DataSource = (from asi in BD.BUTACA
                                              where asi.IDFUNCION.Equals(IDFuncion) &&
                                              asi.BLIBRE.Equals(true) &&
                                              asi.BHABILITADO.Equals(true)
                                              select new
                                              {
                                                  NUMERO_ASIENTO = asi.IDBUTACA,
                                                  COLUMNA = asi.INDICECOLUMNA,
                                                  FILA = asi.INDICEFILA,
                                                  ESTADO = asi.BLIBRE == false ? "OCUPADO" : "LIBRE"
                                              }).ToList();
                }

                var consultaTipoEntrada = (from tEntr in BD.TIPOENTRADA
                                           join fEntr in BD.FUNCIONENTRADA
                                           on tEntr.IDTIPOENTRADA equals fEntr.IDTIPOENTRADA
                                           where tEntr.BHABILITADO.Equals(true)
                                           where fEntr.IDFUNCION.Equals(IDFuncion)
                                           select new CFUNENTRADA 
                                           {
                                               idTipoEntrada = fEntr.IDTIPOENTRADA,
                                               NombreTipoEntrada = tEntr.NOMBRE
                                           }).ToList();

                cmBxTipoEntrada.DataSource = consultaTipoEntrada;
                cmBxTipoEntrada.ValueMember = "idTipoEntrada";
                cmBxTipoEntrada.DisplayMember = "NombreTipoEntrada";
            }
            else
            {
                dgvAsientos.DataSource = null;
            }
        }
        private void CambioPrecio(object sender, EventArgs e)
        {
            decimal precio = 0;
            var consultaPrecio = (from pre in BD.FUNCIONENTRADA
                                  where pre.IDTIPOENTRADA.Equals(cmBxTipoEntrada.SelectedValue) &&
                                  pre.BHABILITADO.Equals(true)
                                  select pre.PRECIO).ToList();
            foreach (var pre in consultaPrecio) precio = (decimal)pre;
            lblPeso.Visible = true;
            lblPrecio.Text = $"{precio}";
        }
        private void FiltradoClientes(object sender, EventArgs e)
        {
            RellenarTablaClientes(txtApellidos.Text);
        }
        private void FiltrarDNI(object sender, EventArgs e)
        {            
                dgvClientes.DataSource = (from cli in BD.CLIENTE
                        where cli.BHABILITADO.Equals(1) &&
                        cli.DNICLIENTE.Contains(txtDNI.Text)
                        select new
                        {
                            DNI = cli.DNICLIENTE,
                            NOMBRE = $"{cli.NOMBRE} {cli.APPATERNO} {cli.APMATERNO}",
                            FECHA_NACI = cli.FECHANAC,
                            TEL_FIJO = cli.TELEFONOFIJO,
                            TEL_CEL = cli.TELEFONOCELULAR
                        }).ToList();            
        }
        private decimal TotalPrecio(List<CRESERVA> NuevaReserva) 
        {
            decimal suma = 0;

            lblPesoTotal.Visible = true;

            for (int i = 0; i < NuevaReserva.Count; i++)
            {
                suma += NuevaReserva[i].Precio;
            }

            return suma;
        }
        private void DatosGeneralesValidacion()
        {
            string[] datosGeneralesText = {
                txtCodEmpleado.Text,
                txtNombreEmpleado.Text,
                txtIDCliente.Text,
                txtNombreCliente.Text
            };
            TextBox[] datosGenerales = {
                txtCodEmpleado,
                txtNombreEmpleado,
                txtIDCliente,
                txtNombreCliente
            };

            for (int i = 0; i < datosGenerales.Length; i++)
            {
                if (datosGeneralesText[i] == "")
                {
                    MessageBox.Show("Antes de continuar, debe llenar todos los campos de \"DATOS GENERALES\".");
                    errorAqui.SetError(datosGenerales[i], "Debe llenar este campo dando click sobre el botón de 3 puntos (...).");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else if (datosGeneralesText[i] != "")
                {
                    errorAqui.SetError(datosGenerales[i], "");
                }
            }

            DatosGeneralesValidados = true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DatosGeneralesValidacion();
            if (DatosGeneralesValidados == false) return;
            
            if (DatosGeneralesValidados == true)
            {
                int idCliente = int.Parse(txtIDCliente.Text);
                int idFuncion = ((CFUNCION)cmBxFuncion.SelectedItem).IDFUNCION;
                int idTipoEntrada = ((CFUNENTRADA)cmBxTipoEntrada.SelectedItem).idTipoEntrada;
                int idButaca = int.Parse(dgvAsientos.CurrentRow.Cells[0].Value.ToString());
                decimal Precio = decimal.Parse(lblPrecio.Text.ToString());
                string NombreCliente = txtNombreCliente.Text;
                string NombreCine = ((CINE)cmBxCine.SelectedItem).NOMBRE;
                string TituloPelicula = ((CPELICULA)cmBxPelicula.SelectedItem).TitPelicula;
                string NombreSala = txtSala.Text;
                string NombreTipoEntrada = ((CFUNENTRADA)cmBxTipoEntrada.SelectedItem).NombreTipoEntrada;
                DateTime FechaFuncion = ((CFUNCION)cmBxFuncion.SelectedItem).FECHA;

                for (int i = 0; i < NuevaReserva.Count(); i++)
                {
                    if (NuevaReserva[i].IDButaca == idButaca)
                    {
                        MessageBox.Show($"El asiento: {idButaca}, ya está reservado. Por favor, selecciona otro \"asiento\" en la tabla: DISPONIBILIDAD DE ASIENTOS, que no esté reservado ya por la tabla de \"TOTAL DE ENTRADAS\"");
                        return;
                    }
                }

                CRESERVA reserva = new CRESERVA
                {
                    IDCliente = idCliente,
                    IDFuncion = idFuncion,
                    IDTipoEntrada = idTipoEntrada,
                    IDButaca = idButaca,
                    Precio = Precio,
                    NombreComCliente = NombreCliente,
                    NombreCine = NombreCine,
                    TituloPelicula = TituloPelicula,
                    NombreSala = NombreSala,
                    TipoEntradaNom = NombreTipoEntrada,
                    FechaFuncion = FechaFuncion
                };

                NuevaReserva.Add(reserva);

                var TablaReservas = (from re in NuevaReserva
                                     select new
                                     {
                                         ID = re.IDCliente,
                                         NOMBRE = re.NombreComCliente,
                                         TIPO_ENTR = re.TipoEntradaNom,
                                         CINE = re.NombreCine,
                                         PELICULA = re.TituloPelicula,
                                         ASIENTO = re.IDButaca,
                                         FECHA = re.FechaFuncion
                                     }).ToList();

                dgvEntradas.DataSource = null;

                lblTotal.Text = TotalPrecio(NuevaReserva).ToString();

                dgvEntradas.DataSource = TablaReservas;

                FondoNegro(dgvEntradas);

                this.DialogResult = DialogResult.None;
            }            
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            id = int.Parse(dgvEntradas.CurrentRow.Cells[0].Value.ToString());

            if (NuevaReserva.Count() <= 0)
            {
                MessageBox.Show("Aún no ha agregado entradas para eliminar a su reserva.");
                return;
            }
            if(NuevaReserva.Count() > 0 && id == null)
            {
                MessageBox.Show("Debe seleccionar una fila en la tabla, para remover la entrada seleccionada.");
                return;
            }
            else if (NuevaReserva.Count() > 0 && id != null)
            {
                if(MessageBox.Show("¿Desea eliminar la entrada seleccionada en la tabla?","AVISO: ELIMINANDO ENTRADA",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    NuevaReserva.RemoveAll(x => x.IDCliente.Equals(id));

                    var TablaReservas = (from re in NuevaReserva
                                         select new
                                         {
                                             ID = re.IDCliente,
                                             NOMBRE = re.NombreComCliente,
                                             CINE = re.NombreCine,
                                             PELICULA = re.TituloPelicula,
                                             ASIENTO = re.IDButaca,
                                             FECHA = re.FechaFuncion
                                         }).ToList();

                    lblTotal.Text = $"{TotalPrecio(NuevaReserva)}";

                    dgvEntradas.DataSource = null;

                    dgvEntradas.DataSource = TablaReservas;

                    FondoNegro(dgvEntradas);
                }
            }
        }
        private void btnRealizarReserva_Click(object sender, EventArgs e)
        {
            DatosGeneralesValidacion();
            if (DatosGeneralesValidados == false) return;

            try
            {                
                using(var transaccion = new TransactionScope())
                {
                    RESERVA reserva = new RESERVA 
                    {
                        IDCLIENTE = int.Parse(txtIDCliente.Text),
                        IDEMPLEADO = int.Parse(txtCodEmpleado.Text),
                        TOTAL = decimal.Parse(lblTotal.Text.ToString()),
                        BHABILITADO = true
                    };

                    BD.RESERVA.InsertOnSubmit(reserva);
                    BD.SubmitChanges();

                    int idReserva = reserva.IDRESERVA;
                    
                    for (int i = 0; i < NuevaReserva.Count; i++)
                    {
                        int idFuncion = NuevaReserva[i].IDFuncion;
                        int idButaca = NuevaReserva[i].IDButaca;

                        DETALLERESERVA detallesReserva = new DETALLERESERVA
                        {
                            IDRESERVA = idReserva,
                            IDCLIENTE = NuevaReserva[i].IDCliente,
                            PRECIO = NuevaReserva[i].Precio,
                            IDFUNCION = NuevaReserva[i].IDFuncion,
                            IDBUTACA = NuevaReserva[i].IDButaca,
                            BHABILITADO = true
                        };                        

                        BD.DETALLERESERVA.InsertOnSubmit(detallesReserva);

                        var butacaOcupada = from but in BD.BUTACA
                                            where but.IDFUNCION.Equals(idFuncion) &&
                                            but.IDBUTACA.Equals(idButaca)
                                            select but;

                        foreach (var d in butacaOcupada) d.BLIBRE = false;

                    }

                    BD.SubmitChanges();
                    transaccion.Complete();
                    MessageBox.Show("Se ha registrado su reserva, de forma correcta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex}");
            }           
        }
    }
}
