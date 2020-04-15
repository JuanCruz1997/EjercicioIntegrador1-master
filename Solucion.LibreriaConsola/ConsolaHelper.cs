using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solucion.LibreriaNegocio.Helpers;
using Solucion.LibreriaNegocio.Entidades;

namespace Solucion.LibreriaConsola
{
    public static class ConsolaHelper
    {
        public static string PedirString(string msg)
        {
            Console.WriteLine("Ingrese " +msg);
            string n = Console.ReadLine();
            string chequeo = ValidacionHelper.ValidarString(n);
            if (chequeo == "")
            {
                throw new Exception("El valor ingresado no es válido.");
            }
            else
            {
                return n;
            }
        }

        public static int PedirInt(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            int c = ValidacionHelper.ValidarInt(Console.ReadLine());
            if (c < 0)
            {
                throw new Exception("El valor ingresado no es válido.");
            }
            else
            {
                return c;
            }
        }

        public static DateTime PedirFecha(string msg)
        {
            Console.WriteLine("Ingrese fecha " + msg +" solo en este formato YYYY-MM-DD");
            // se puede validar fechas inexistentes o dejar que lo haga el framework
            DateTime f = Convert.ToDateTime(Console.ReadLine());
            return f;
        }
        public static Salario PedirSalario()
        {
            Console.WriteLine("Ingrese salario bruto:");
            double bruto = ValidacionHelper.ValidarDouble(Console.ReadLine());
            if (bruto < 0)
            {
                throw new Exception("El valor ingresado no es válido.");
            }
            Console.WriteLine("Ingrese descuentos:");
            double desc = ValidacionHelper.ValidarDouble(Console.ReadLine());
            if (desc < 0)
            {
                throw new Exception("El valor ingresado no es válido.");
            }
            Console.WriteLine("Ingrese fecha del último salario:");
            DateTime fechaSalario = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese código de transferencia:");
            string transferencia = ValidacionHelper.ValidarString(Console.ReadLine());
            if (transferencia == "")
            {
                throw new Exception("El valor ingresado no es válido.");
            }
            Salario s = new Salario();
            s.Bruto = bruto;
            s.Descuentos = desc;
            s.Fecha = fechaSalario;
            s.CodigoTransferencia = transferencia;
            return s;
        }

        //devuelve si la validacion está bien o no
        public static bool EsOpcionValida(string input, string opcionesValidas)
        {
            // manejamos expciones
            try
            {
                // validamos algo
                if (string.IsNullOrEmpty(input)  // es nulo o vacío
                    || input.Length > 1          // tiene más de un caracter       
                    || !opcionesValidas.ToUpper().Contains(input.ToUpper())) // no está dentro de las opciones válidas
                {
                    return false;
                }

                return true;
            }
            // podemos capturar más exceptions asi mostramos errpores más personalizados
            // en este caso no nos importa arrojar una ex porque decidimos que el método devuelva T o F
            catch
            {
                // podemos mostrar un error

                return false;
            }
        }
    }
}
