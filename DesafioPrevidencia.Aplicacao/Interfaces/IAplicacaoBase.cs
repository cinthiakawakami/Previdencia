using System.Collections.Generic;

namespace DesafioPrevidencia.Aplicacao.Interfaces
{
    public interface IAplicacaoBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
