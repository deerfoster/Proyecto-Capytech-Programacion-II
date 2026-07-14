using System.Collections.Generic;

namespace CapyTech.Seguridad
{
    public class Autenticacion
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public bool Registrar(Usuario usuario)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.NombreUsuario == usuario.NombreUsuario)
                    return false;
            }

            usuarios.Add(usuario);
            return true;
        }

        public bool IniciarSesion(string usuario, string password)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.NombreUsuario == usuario)
                {
                    return u.VerificarPassword(password);
                }
            }

            return false;
        }
    }
}