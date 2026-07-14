using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CapyTech.Seguridad
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        private string Password { get; set; }
        public DateTime FechaCambio { get; set; }

        public Usuario(string nombreUsuario, string password)
        {
            NombreUsuario = nombreUsuario;
            Password = Encriptar(password);
            FechaCambio = DateTime.Now;
        }

        private string Encriptar(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public bool VerificarPassword(string password)
        {
            return Password == Encriptar(password);
        }

        public bool CambiarPassword(string nuevaPassword)
        {
            if (!ValidarPassword(nuevaPassword))
                return false;

            Password = Encriptar(nuevaPassword);
            FechaCambio = DateTime.Now;
            return true;
        }

        public static bool ValidarPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool tieneLetra = Regex.IsMatch(password, "[A-Za-z]");
            bool tieneNumero = Regex.IsMatch(password, "[0-9]");

            return tieneLetra && tieneNumero;
        }

        public bool PasswordVencida()
        {
            return (DateTime.Now - FechaCambio).Days >= 365;
        }
    }
}