using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_CineGT
{
    public partial class EdicionBoletos : Form
    {
        private int usuarioId;
        private int transaccionID;
        private int peliculaID; // Asegúrate de tener estos valores
        private int salaID;
        private DateTime fechaSesion;

        public EdicionBoletos(int usuarioId)
        {
            InitializeComponent();
            this.usuarioId = usuarioId;
            if (!dgDetallesReserva.Columns.Contains("Seleccionado"))
            {
                DataGridViewCheckBoxColumn seleccionadoColumn = new DataGridViewCheckBoxColumn();
                seleccionadoColumn.Name = "Seleccionado";
                seleccionadoColumn.HeaderText = "Seleccionado";
                seleccionadoColumn.FalseValue = false;
                seleccionadoColumn.TrueValue = true;
                dgDetallesReserva.Columns.Add(seleccionadoColumn);
            }
        }

        private void btnValidarT_Click(object sender, EventArgs e)
        {
            int transaccionID;
            if (int.TryParse(txtTransaccionID.Text, out transaccionID))
            {
                var detallesReserva = ObtenerDetallesReserva(transaccionID, usuarioId);
                if (detallesReserva != null && detallesReserva.Any())
                {
                    // Asignar los valores de película, sala, y fecha de la sesión
                    var primeraReserva = detallesReserva.First();
                    peliculaID = primeraReserva.SesionID; // O el ID de la película según tu lógica
                    salaID = primeraReserva.SalaID;
                    fechaSesion = primeraReserva.FechaTransaccion;
                    dgDetallesReserva.DataSource = detallesReserva;
                }
                else
                {
                    MessageBox.Show("Número de transacción no válido o sin reservas asociadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número de transacción válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private List<ReservaDetalle> ObtenerDetallesReserva(int transaccionID, int usuarioID)
        {
            List<ReservaDetalle> detalles = new List<ReservaDetalle>();

            string conn = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection conexion = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerDetallesReserva", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransaccionID", transaccionID);
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioID); // Agregar UsuarioID como parámetro

                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detalles.Add(new ReservaDetalle
                        {
                            SesionID = reader.GetInt32(0),
                            NombrePelicula = reader.GetString(1), // Cambiado para mostrar el nombre de la película
                            SalaID = reader.GetInt32(2),
                            Fila = reader.GetString(3),
                            Numero = reader.GetInt32(4),
                            FechaTransaccion = reader.GetDateTime(5) // Guardar la fecha de la transacción
                        });
                    }
                }
            }

            return detalles;
        }

        private List<ReservaDetalle> asientosSeleccionados = new List<ReservaDetalle>();

        private void dgDetallesReserva_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgDetallesReserva_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgDetallesReserva.Columns["Seleccionado"].Index)
            {
                // Obtener los datos del asiento
                ReservaDetalle asiento = new ReservaDetalle
                {
                    SesionID = Convert.ToInt32(dgDetallesReserva.Rows[e.RowIndex].Cells["SesionID"].Value),
                    Fila = dgDetallesReserva.Rows[e.RowIndex].Cells["Fila"].Value.ToString(),
                    Numero = Convert.ToInt32(dgDetallesReserva.Rows[e.RowIndex].Cells["Numero"].Value),
                };

                // Obtener el estado del checkbox en la celda cambiada
                bool isSelected = Convert.ToBoolean(dgDetallesReserva.Rows[e.RowIndex].Cells["Seleccionado"].Value);

                // Si el checkbox está marcado, añadir el asiento
                if (isSelected)
                {
                    if (!asientosSeleccionados.Contains(asiento))
                    {
                        asientosSeleccionados.Add(asiento);  // Agregar el asiento
                    }
                }
                else
                {
                    // Si el checkbox no está marcado, eliminar el asiento
                    if (asientosSeleccionados.Contains(asiento))
                    {
                        asientosSeleccionados.Remove(asiento);  // Eliminar el asiento
                    }
                }

                // Mostrar un mensaje con la cantidad de asientos seleccionados
                MessageBox.Show($"{asientosSeleccionados.Count} asientos seleccionados");
            }

        }

        private void dgDetallesReserva_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dgDetallesReserva.IsCurrentCellDirty)
            {
                dgDetallesReserva.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (asientosSeleccionados.Any())
            {
                var detallesAsientos = new DetallesCambioAsientos
                {
                    TransaccionID = transaccionID,
                    AsientosSeleccionados = asientosSeleccionados,
                    PeliculaID = peliculaID,
                    SalaID = salaID,
                    FechaSesion = fechaSesion
                };

                CambioAsiento cambioForm = new CambioAsiento(detallesAsientos);
                cambioForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar al menos un asiento para cambiar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public class DetallesCambioAsientos
        {
            public int TransaccionID { get; set; }
            public List<ReservaDetalle> AsientosSeleccionados { get; set; }  // Cambiar Asiento por ReservaDetalle
            public int PeliculaID { get; set; }
            public int SalaID { get; set; }
            public DateTime FechaSesion { get; set; }
        }

    }
}
