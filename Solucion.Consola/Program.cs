using Solucion.LibreriaConsola;
using Solucion.LibreriaNegocio;
using Solucion.LibreriaNegocio.Entidades;
using Solucion.LibreriaNegocio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion.Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            // variables de estado de consola, flag de control de la aplicación
            bool continuarActivo = true;

            // menú que se va a mostrar luego de CADA acción
            string menu = "1) Listar Alumnos \n2) Listar Empleados \n3) Agregar Alumno " +
                "\n4) Agregar Empleado \n5) Borrar Alumno \n6) Borrar Empleado \n7) Limpiar Consola \nX) Salir";
         
            
            // Creo el objeto con el que voy a trabajar en este programa
            Facultad fce = new Facultad("FCE");

            // pantalla de bienvenida
            Console.WriteLine("Bienvenido a " + fce.Nombre);

            do
            {
                Console.WriteLine(menu); //mostramos el menú

                try
                {
                    //capturamos la seleccion
                    string opcionSeleccionada = Console.ReadLine(); 

                    // validamos si el input es válido (en este caso podemos tmb dejar que el switch se encargue en el default.
                    // lo dejo igual por las dudas si quieren usar el default del switch para otra cosa.
                    if (ConsolaHelper.EsOpcionValida(opcionSeleccionada,"1234567X"))
                    {
                        if (opcionSeleccionada.ToUpper() == "X")
                        {
                            continuarActivo = false;
                            continue;
                        }

                        switch (opcionSeleccionada)
                        {
                            case "1":
                                // listar
                                Program.ListarAlumnos(fce);
                                break;
                            case "2":
                                // listar
                                Program.ListarEmpleados(fce);
                                
                                break;
                            case "3":
                                // alta
                                Program.AgregarAlumno(fce);
                                
                                break;
                            case "4":
                                // alta
                                Program.AgregarEmpleado(fce);
                                break;
                            case "5":
                                // borrar
                                Program.EliminarAlumno(fce);
                                break;
                            case "6":
                                // borrar
                                Program.EliminarEmpleado(fce);
                                break;
                            case "7":
                                Console.Clear();
                                break;
                            //etc... si tenemos más opciones...
                            default:
                                Console.WriteLine("Opción inválida.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida.");
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Error durante la ejecución del comando. Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Ingrese una tecla para continuar.");
                
                Console.ReadKey();
                Console.Clear();
            }
            while (continuarActivo);

            Console.WriteLine("Gracias por usar la app.");
            Console.ReadKey();
        }


        #region "Métodos Propios de este programa, no reutilizables ya que piden ingresos solo para interfaz consola"
        private static void EliminarEmpleado(Facultad fce)
        {
            try
            {
                ListarEmpleados(fce);
                Console.WriteLine("¿Qué empleado desea eliminar? Ingrese número de legajo:");
                int legajo = ValidacionHelper.ValidarInt(Console.ReadLine());
                fce.EliminarEmpleado(legajo);
                Console.WriteLine("Empleado eliminado.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error en uno de los datos ingresados. " + ex.Message + " Intente nuevamente. \n\n");
                EliminarEmpleado(fce);
            }
        }
        private static void AgregarEmpleado(Facultad facultad)
        {
            try
            {
                
                string n = ConsolaHelper.PedirString("Nombre");
                string a = ConsolaHelper.PedirString("Apellido");
                int c = ConsolaHelper.PedirInt("Legajo");
                string t = ConsolaHelper.PedirString("tipo empleado (D docente, B bedel, A directivo)");
                DateTime f = ConsolaHelper.PedirFecha("Ingreso laboral");
                Salario s = ConsolaHelper.PedirSalario();

                string ap = string.Empty;
                if (t.ToUpper() == "B")
                {
                    ap = ConsolaHelper.PedirString("Apodo");
                }
                string m = string.Empty;
                if (t.ToUpper() == "D")
                {
                    m = ConsolaHelper.PedirString("Materia");
                }
                // acá si necesitamos enviarle los param al método para que sepa que tipo de obj crear
                facultad.AgregarEmpleado(n,a,c,f,s,t,ap,m);
                Console.WriteLine("Empleado agregado.");

            }
            catch (Exception ex)
            {
                // podemos usar recursión para que no salga del método hasta que no lo haga bien.
                Console.WriteLine("Error en uno de los datos ingresados. " + ex.Message + " Intente nuevamente. \n\n");

                // podemos preguntarle si quiere hacerlo de nuevo. Depende de nuestro negocio.
                // if(quiereIntentarNuevamente)
                AgregarEmpleado(facultad);
            }
        }

        private static void EliminarAlumno(Facultad fce)
        {
            try
            {
                ListarAlumnos(fce);
                Console.WriteLine("¿Qué alumno desea eliminar? Ingrese código de alumno:");
                int codigo = ValidacionHelper.ValidarInt(Console.ReadLine());
                fce.EliminarAlumno(codigo);
                Console.WriteLine("Alumno eliminado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en uno de los datos ingresados. " + ex.Message + " Intente nuevamente. \n\n");
                EliminarAlumno(fce);
            }
        }

        private static void AgregarAlumno(Facultad facultad)
        {
            try
            {
                string n = ConsolaHelper.PedirString("Nombre");
                string a = ConsolaHelper.PedirString("Apellido");
                int c = ConsolaHelper.PedirInt("Código");
                DateTime f = ConsolaHelper.PedirFecha("nacimiento");

                // opcion 1 generamos el objeto acá
                Alumno al = new Alumno(c,n,a,f);
                facultad.AgregarAlumno(al);
                Console.WriteLine("Alumno agregado.");
                // opción 2 mandamos valores y que lo genere el propio método
                // facultad.AgregarAlumno(n,a,c,f);
            }
            catch (Exception ex)
            {
                // podemos usar recursión para que no salga del método hasta que no lo haga bien.
                Console.WriteLine("Error en uno de los datos ingresados. " + ex.Message + " Intente nuevamente. \n\n");

                // podemos preguntarle si quiere hacerlo de nuevo. Depende de nuestro negocio.
                // if(quiereIntentarNuevamente)
                AgregarAlumno(facultad);
            }

        }

        public static void ListarAlumnos(Facultad facultad)
        {
            if (facultad.Alumnos.Count == 0)
            {
                Console.WriteLine("No hay alumnos para mostrar.");
            }
            else
            {
                foreach (Alumno a in facultad.Alumnos)
                {
                    MostrarCredencial(a);
                }
                Console.WriteLine("Se listaron " + facultad.Alumnos.Count + "alumnos.");
            }
        }

        public static void ListarEmpleados(Facultad facultad)
        {
            if (facultad.Empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados para mostrar.");
            }
            else
            {
                foreach (Empleado e in facultad.Empleados)
                {
                    MostrarCredencial(e);
                }
                Console.WriteLine("Se listaron " + facultad.Empleados.Count + "empleados.");
            }
        }

        private  static void MostrarCredencial(Persona persona)
        {
            Console.WriteLine(persona.GetCredencial());
        }

        #endregion

    }
}
