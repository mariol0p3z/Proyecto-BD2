using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_CineGT
{
    public class ReservaDetalle
    {

            public int SesionID { get; set; }
            public string NombrePelicula { get; set; } // Cambio para almacenar el nombre de la película
            public int SalaID { get; set; }
            public string Fila { get; set; }
            public int Numero { get; set; }
            public DateTime FechaTransaccion { get; set; } // Para mostrar la fecha de la transacción
        


        public ReservaDetalle(int sesionID, string peliculaID, int salaID, string fila, int numero)
        {
            SesionID = sesionID;
            NombrePelicula = peliculaID;
            SalaID = salaID;
            Fila = fila;
            Numero = numero;
        }

        public ReservaDetalle() { }

        public override string ToString()
        {
            return $"Sesión ID: {SesionID}, Película ID: {NombrePelicula}, Sala ID: {SalaID}, Fila: {Fila}, Número: {Numero}";
        }
    }
}
