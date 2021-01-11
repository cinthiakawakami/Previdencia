using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace DesafioPrevidencia.Data.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public Usuario ObterUsuarioPeloEmail(string email)
        {
            return Db.Usuarios.Where(a => a.Email == email).FirstOrDefault();
        }
    }
}
