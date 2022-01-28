using ProvaCandidato.Data;
using ProvaCandidato.Data.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProvaCandidato.Services
{
    public class ClienteService : IDisposable
    {
        private readonly ContextoPrincipal _contextoPrincipal;
        private readonly DbSet<Cliente> _dbSet;
        private readonly DbSet<ClienteObservacao> _dbSetClienteObservacaos;

        public ClienteService()
        {
            _contextoPrincipal = new ContextoPrincipal();
            _dbSet = _contextoPrincipal.Clientes;
            _dbSetClienteObservacaos = _contextoPrincipal.ClienteObservacoes;
        }

        public List<Cliente> GetAll()
        {
            try
            {
                return _dbSet.Include(c => c.Cidade).ToList();
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        public Cliente Get(int codigo)
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

        public void Save(Cliente cliente)
        {
            try
            {
                if (cliente.Codigo <= 0)
                    _dbSet.Add(cliente);
                else
                    _contextoPrincipal.Entry(cliente).State = EntityState.Modified;

                _contextoPrincipal.SaveChanges();
            }
            catch(Exception ex) { }
        }

        public void Delete(int id)
        {
            try
            {
                Cliente cliente = Get(id);
                var observacoes = _dbSetClienteObservacaos.Include(x => x.Cliente).Where(x => x.Cliente.Codigo == id);
                _dbSetClienteObservacaos.RemoveRange(observacoes);
                _dbSet.Remove(cliente);
                _contextoPrincipal.SaveChanges();
            }
            catch (Exception ex) { }
        }

        public void SaveObservasao(int id, string descricao)
        {
            try
            {
                Cliente cliente = Get(id);
                cliente.ClienteObservacoes.Add(new ClienteObservacao() { Observacao = descricao, Cliente = cliente });
                _contextoPrincipal.Entry(cliente).State = EntityState.Modified;
                _contextoPrincipal.SaveChanges();
            }
            catch (Exception ex) { }
        }

        public IEnumerable<Cliente> ByName(string nome) => _dbSet.Where(c => c.Nome.ToLower().Contains(nome.ToLower())).Include(c => c.Cidade);

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