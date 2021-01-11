using DesafioPrevidencia.Dominio.Entidades;
using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace DesafioPrevidencia.Data.Repositorios
{
    public class RespostasFormularioRepositorio : RepositorioBase<RespostasFormulario>, IRespostasFormularioRepositorio
    {
        public RespostasFormulario BuscarPoIdUsuario(int idUsuario)
        {
            return Db.RespostasFormularios.Where(p => p.UsuarioId == idUsuario).SingleOrDefault();
        }

    }
}
