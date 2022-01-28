using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Models;
using ProvaCandidato.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace ProvaCandidato.Controllers
{
    public class ComboController : ApiController
    {
        private readonly CidadeService _cidadeService;
        private readonly ClienteService _clienteService;
        public ComboController()
        {
            _cidadeService = new CidadeService();
            _clienteService = new ClienteService();
        }

        [HttpGet]
        public IEnumerable<Cidade> Get() => _cidadeService.GetAll();

        [HttpPost]
        public void CreateObservacao(ObservacaoModel observacaoModel) => _clienteService.SaveObservasao(observacaoModel.codigo, observacaoModel.observacao);
    }
}
