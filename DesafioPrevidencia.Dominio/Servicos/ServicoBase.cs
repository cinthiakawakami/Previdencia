﻿using DesafioPrevidencia.Dominio.Interfaces.Repositorios;
using DesafioPrevidencia.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace DesafioPrevidencia.Dominio.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Add(TEntity obj)
        {
            _repositorio.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repositorio.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repositorio.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repositorio.Remove(obj);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
