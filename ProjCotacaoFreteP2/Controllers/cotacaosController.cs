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
    public class cotacaosController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: cotacaos
        public ActionResult Index()
        {
            var cotacao = db.cotacao.Include(c => c.pedido).Include(c => c.transportadora);
            return View(cotacao.ToList());
        }

        // GET: cotacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cotacao cotacao = db.cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        // GET: cotacaos/Create
        public ActionResult Create()
        {
            ViewBag.fkpedido = new SelectList(db.pedido, "Id", "nome_cliente");
            ViewBag.fktransportadora = new SelectList(db.transportadora, "Id", "cnpj");
            return View();
        }

        // POST: cotacaos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fkpedido,fktransportadora,dias_entrega,valor")] cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                db.cotacao.Add(cotacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fkpedido = new SelectList(db.pedido, "Id", "nome_cliente", cotacao.fkpedido);
            ViewBag.fktransportadora = new SelectList(db.transportadora, "Id", "cnpj", cotacao.fktransportadora);
            return View(cotacao);
        }

        // GET: cotacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cotacao cotacao = db.cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkpedido = new SelectList(db.pedido, "Id", "nome_cliente", cotacao.fkpedido);
            ViewBag.fktransportadora = new SelectList(db.transportadora, "Id", "cnpj", cotacao.fktransportadora);
            return View(cotacao);
        }

        // POST: cotacaos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fkpedido,fktransportadora,dias_entrega,valor")] cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkpedido = new SelectList(db.pedido, "Id", "nome_cliente", cotacao.fkpedido);
            ViewBag.fktransportadora = new SelectList(db.transportadora, "Id", "cnpj", cotacao.fktransportadora);
            return View(cotacao);
        }

        // GET: cotacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cotacao cotacao = db.cotacao.Find(id);
            if (cotacao == null)
            {
                return HttpNotFound();
            }
            return View(cotacao);
        }

        // POST: cotacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cotacao cotacao = db.cotacao.Find(id);
            db.cotacao.Remove(cotacao);
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
