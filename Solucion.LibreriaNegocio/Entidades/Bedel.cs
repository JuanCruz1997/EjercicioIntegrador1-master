using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.LibreriaNegocio.Entidades
{
    public class Bedel : Empleado
    {
        protected string _apodo;

        public string Apodo { get => _apodo; set => _apodo = value; }
        public Bedel(int cod, string nombre, string apellido, DateTime fechaIngreso, Salario salario, string apodo) : base(cod, nombre, apellido, fechaIngreso, salario)
        {
            this._apodo = apodo;
        }

        public override string GetNombreCompleto()
        {
            return "Bedel " + this.Apodo;
        }

    }
}
