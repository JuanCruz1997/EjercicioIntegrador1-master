using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.LibreriaNegocio.Entidades
{
    public class Directivo : Empleado
    {
        public Directivo(int cod, string nombre, string apellido, DateTime fechaIngreso, Salario salario) : base(cod, nombre, apellido, fechaIngreso, salario)
        {
        }

        public override string GetNombreCompleto()
        {
            return "SR. Director " + this._apellido;
        }
    }
}
