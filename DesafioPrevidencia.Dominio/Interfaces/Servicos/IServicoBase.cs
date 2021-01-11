using System.Collections.Generic;

namespace DesafioPrevidencia.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
