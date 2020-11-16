using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjCotacaoFreteP2;

namespace ProjCotacaoFreteP2.Controllers
{
    public class fretesController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: fretes
        public ActionResult Index()
        {
            var frete = db.frete.Include(f => f.cotacao);
            return View(frete.ToList());
        }

        // GET: fretes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            frete frete = db.frete.Find(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // GET: fretes/Create
        public ActionResult Create()
        {
            ViewBag.fkcotacao = new SelectList(db.cotacao, "Id", "valor");
            return View();
        }

        // POST: fretes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fkcotacao,codigo_rastreio,data_postagem")] frete frete)
        {
            if (ModelState.IsValid)
            {
                db.frete.Add(frete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkcotacao = new SelectList(db.cotacao, "Id", "valor", frete.fkcotacao);
            return View(frete);
        }

        // GET: fretes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            frete frete = db.frete.Find(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkcotacao = new SelectList(db.cotacao, "Id", "valor", frete.fkcotacao);
            return View(frete);
        }

        // POST: fretes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fkcotacao,codigo_rastreio,data_postagem")] frete frete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkcotacao = new SelectList(db.cotacao, "Id", "valor", frete.fkcotacao);
            return View(frete);
        }

        // GET: fretes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            frete frete = db.frete.Find(id);
            if (frete == null)
            {
                return HttpNotFound();
            }
            return View(frete);
        }

        // POST: fretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            frete frete = db.frete.Find(id);
            db.frete.Remove(frete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
