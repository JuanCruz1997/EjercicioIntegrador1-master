using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.LibreriaNegocio.Entidades
{
    public class Salario
    {
        private double _bruto;
        private double _descuentos;
        private DateTime _fecha;
        private string _codigoTransferencia;

        public double Bruto { get => _bruto; set => _bruto = value; }
        public double Descuentos { get => _descuentos; set => _descuentos = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string CodigoTransferencia { get => _codigoTransferencia; set => _codigoTransferencia = value; }

        public double GetSalarioNeto()
        {
            return _bruto - _descuentos;
        }
    }
}
