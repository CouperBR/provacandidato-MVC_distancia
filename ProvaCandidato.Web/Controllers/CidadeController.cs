using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Services;
using System.Net;
using System.Web.Mvc;

namespace ProvaCandidato.Controllers
{
    public class CidadeController : GenericController<CidadeController>
    {
        private readonly CidadeService _cidadeService;

        public CidadeController()
        {
            _cidadeService = new CidadeService();
        }

        // GET: Cidade
        public ActionResult Index()
        {
            return View(_cidadeService.GetAll());
        }

        // GET: Cidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cidade cidade = _cidadeService.Get((int)id);

            if (cidade == null)
                return HttpNotFound();

            return View(cidade);
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nome")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _cidadeService.Save(cidade);
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        // GET: Cidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cidade cidade = _cidadeService.Get((int)id);

            if (cidade == null)
                return HttpNotFound();

            return View(cidade);
        }

        // POST: Cidade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nome")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _cidadeService.Save(cidade);
                return RedirectToAction("Index");
            }

            return View(cidade);
        }

        // GET: Cidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Cidade cidade = _cidadeService.Get((int)id);

            if (cidade == null)
                return HttpNotFound();

            return View(cidade);
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _cidadeService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
