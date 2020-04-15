using System;
using Solucion.LibreriaNegocio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.LibreriaNegocio
{
    public class Docente : Empleado
    {
        protected string materia;
        public string Materia { get => materia; set => materia = value; }
        public Docente(int cod, string nombre, string apellido, DateTime fechaIngreso, Salario salario, string materia) : base(cod,nombre,apellido,fechaIngreso,salario)
        {
            this.materia = materia;
        }

        public override string GetNombreCompleto()
        {
            return "Docente " + this.Apellido;
        }
        public override string GetCredencial()
        {
            string ficha = string.Format("Empleado {0} - {1} - {2} - {3}", this.Legajo, GetNombreCompleto(), this.UltimoSalario.GetSalarioNeto(), this.Materia);
            return ficha;
        }
    }
}
