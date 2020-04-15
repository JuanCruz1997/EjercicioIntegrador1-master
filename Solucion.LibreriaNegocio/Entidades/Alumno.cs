using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.LibreriaNegocio
{
    public class Alumno : Persona
    {
        private int _codigo;


        public Alumno(int cod, string nom, string ape, DateTime fechaNac)
        {
            this._codigo = cod;
            this._nombre = nom;
            this._apellido = ape;
            this._fechaNac = fechaNac;
        }

        public int Codigo { get => _codigo; set => _codigo = value; }


        public override string GetCredencial()
        {
            string ficha = string.Format("Código {0} {1}, {2}", this.Codigo, this.Apellido, this.Nombre);
            return ficha;
        }

        public virtual string GetPassword()
        {
            return this.Nombre.Length.ToString() + this.Apellido.Length.ToString() + this.Codigo.ToString();
        }
       
    }
}
