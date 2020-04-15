using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.LibreriaNegocio
{
    public abstract class Persona
    {
        protected string _nombre;
        protected string _apellido;
        protected DateTime _fechaNac;

        

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        
        // la realiadad es que esta validación se debería hacer al construir el objeto, pero 
        // para explicar el if inline y una validación de fecha nos tomamos esta licencia
        public int Edad {  get => DateTime.Now.Year > 1900 ? (DateTime.Now.Year - _fechaNac.Year) : throw new Exception("Nadie tiene mas de 120 años"); }



        public abstract string GetCredencial();

        public virtual string GetNombreCompleto() {
            return string.Format("{0}, {1}",this._apellido,this._nombre);
        }
    }
}
