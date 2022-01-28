using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class ClienteController : GenericController<ClienteController>
    {
        private readonly ClienteService _clienteService;
        private readonly CidadeService _cidadeService;

        public ClienteController()
        {
            _clienteService = new ClienteService();
            _cidadeService = new CidadeService();
        }

        // GET: Cliente
        public ActionResult Index(string name = "")
        {
            if (string.IsNullOrEmpty(name))
                return View(_clienteService.GetAll());

            return View(_clienteService.ByName(name));
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cliente cliente = _clienteService.Get((int)id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.CidadeId = new SelectList(_cidadeService.GetAll(), "Codigo", "Nome");
            return View();
        }

        // POST: Cliente/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            List<string> errors = new List<string>();
            if (cliente.DataNascimento == null || cliente.DataNascimento.Value.Date > DateTime.UtcNow.Date)
                errors.Add("Date de nascimento é maior que a data atual ou é nula.");

            if (cliente.CidadeId <= 0)
                errors.Add("Selecione a cidade.");

            if (ModelState.IsValid && errors.Count <= 0)
            {
                _clienteService.Save(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(_cidadeService.GetAll(), "Codigo", "Nome", cliente.CidadeId);
            TempData["Errors"] = errors;

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cliente cliente = _clienteService.Get((int)id);

            if (cliente == null)
                return HttpNotFound();

            ViewBag.CidadeId = new SelectList(_cidadeService.GetAll(), "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome,DataNascimento,CidadeId,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Save(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.CidadeId = new SelectList(_cidadeService.GetAll(), "Codigo", "Nome", cliente.CidadeId);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cliente cliente = _clienteService.Get((int)id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clienteService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
