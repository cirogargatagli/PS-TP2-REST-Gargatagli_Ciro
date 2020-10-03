using System;
using System.Text.RegularExpressions;

namespace TP2.REST.Application
{
    public class Validacion
    {
        public static bool ComprobarFormatoEmail(string EmailAComprobar)
        {
            string formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(EmailAComprobar, formato))
            {
                if (Regex.Replace(EmailAComprobar, formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                } 
            }
            else
            {
                return false;
            }
        }
        public static bool ValidarSoloLetras(string input)
        {             
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }
        public static string Dni(string dni)
        {
            while (dni.Length < 8 || dni.Length > 8)
            {
                Console.Write("\n         Ingrese DNI valido:");
                dni = Console.ReadLine();
            }
            return dni;
        }
    }
}
