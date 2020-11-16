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
    public class transportadorasController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: transportadoras
        public ActionResult Index()
        {
            return View(db.transportadora.ToList());
        }

        // GET: transportadoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transportadora transportadora = db.transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        // GET: transportadoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: transportadoras/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,cnpj,razao,nome_fantasia,logradouro,cidade,uf,numero,cep,complemento,telefone,email,site")] transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                db.transportadora.Add(transportadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transportadora);
        }

        // GET: transportadoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transportadora transportadora = db.transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        // POST: transportadoras/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,cnpj,razao,nome_fantasia,logradouro,cidade,uf,numero,cep,complemento,telefone,email,site")] transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transportadora);
        }

        // GET: transportadoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transportadora transportadora = db.transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        // POST: transportadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transportadora transportadora = db.transportadora.Find(id);
            db.transportadora.Remove(transportadora);
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
