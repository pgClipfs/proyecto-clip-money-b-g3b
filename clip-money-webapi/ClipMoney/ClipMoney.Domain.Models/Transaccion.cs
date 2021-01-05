using System;
using System.Collections.Generic;
using System.Text;

namespace ClipMoney.Domain.Models
{
    public class Transaccion
    {
        private int id;
        private int numeroTransaccion;
        private string fecha;
        private string hora;
        private decimal monto;
		private TipoTransaccion tipoTransaccion;
        private int idCuenta;
        private string destinatario;

        public Transaccion()
        {
        }

        public Transaccion(decimal monto, TipoTransaccion tipoTrans)
        {
            this.Monto = monto;
            this.tipoTransaccion = tipoTrans;
        }

        public Transaccion(string fecha, string hora, TipoTransaccion tipoTransaccion, decimal monto, int idCue)
        {
            this.fecha = fecha;
            this.hora = hora;
            this.tipoTransaccion = tipoTransaccion;
            this.monto = monto;
            this.idCuenta = idCue;
        }

        public Transaccion(int numeroTransaccion, string fecha, string hora, decimal monto, string destinatario, TipoTransaccion tipoTrans, Estado est, int idCue)
        {
            this.numeroTransaccion = numeroTransaccion;
            this.fecha = fecha;
            this.hora = hora;
            this.monto = monto;
            this.destinatario = destinatario;
            this.tipoTransaccion = tipoTrans;
            this.Estado = est;
            this.idCuenta = idCue;

        }

        public int NumeroTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public decimal Monto { get; set; }
        public int Id { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }
		public Estado Estado { get; set; }
		public string Destinatario { get; set; }
    }
}
