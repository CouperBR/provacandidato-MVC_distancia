using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProvaCandidato.Services
{
    public class CidadeService : IDisposable
    {
        private readonly ContextoPrincipal _contextoPrincipal;
        private readonly DbSet<Cidade> _dbSet;

        public CidadeService()
        {
            _contextoPrincipal = new ContextoPrincipal();
            _dbSet = _contextoPrincipal.Cidades;
        }

        public List<Cidade> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch(Exception ex)
            {
                return new List<Cidade>();
            }
        }

        public Cidade Get(int codigo)
        {
            try
            {
                return _dbSet.Find(codigo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Save(Cidade cidade)
        {
            try
            {
                if (cidade.Codigo <= 0)
                    _dbSet.Add(cidade);
                else
                    _contextoPrincipal.Entry(cidade).State = EntityState.Modified;

                _contextoPrincipal.SaveChanges();
            }
            catch (Exception ex) { }
        }

        public void Delete(int id)
        {
            try
            {
                Cidade cidade = Get(id);
                _dbSet.Remove(cidade);
                _contextoPrincipal.SaveChanges();
            }
            catch (Exception ex) { }
        }

        public void Dispose()
        {
            try
            {
                _contextoPrincipal.Dispose();
            }
            catch (Exception ex) { }
        }
    }
}