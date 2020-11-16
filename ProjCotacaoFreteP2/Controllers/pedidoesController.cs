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
    public class pedidoesController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: pedidoes
        public ActionResult Index()
        {
            var pedido = db.pedido.Include(p => p.embalagem).Include(p => p.empresa);
            return View(pedido.ToList());
        }

        // GET: pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.fkembalagem = new SelectList(db.embalagem, "Id", "descricao");
            ViewBag.fkempresa = new SelectList(db.empresa, "Id", "nome_fantasia");
            return View();
        }

        // POST: pedidoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome_cliente,cpf_cnpj,logradouro,cidade,uf,numero,cep,complemento,peso,valor,fkembalagem,fkempresa")] pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.pedido.Add(pedido);
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //ViewBag.fkempresa = new SelectList(db.embalagem, "Id", "descricao", pedido.fkempresa);
            ViewBag.fkempresa = new SelectList(db.empresa, "Id", "nome_fantasia", pedido.fkempresa);
            //return View(pedido);
            return Json(new { Resultado = pedido.Id }, JsonRequestBehavior.AllowGet);
        }

        // GET: pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.fkembalagem = new SelectList(db.embalagem, "Id", "descricao", pedido.fkempresa);
            ViewBag.fkempresa = new SelectList(db.empresa, "Id", "nome_fantasia", pedido.fkempresa);
            return View(pedido);
        }

        // POST: pedidoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome_cliente,cpf_cnpj,logradouro,cidade,uf,numero,cep,complemento,peso,valor,fkembalagem,fkempresa")] pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fkembalagem = new SelectList(db.embalagem, "Id", "descricao", pedido.fkempresa);
            ViewBag.fkempresa = new SelectList(db.empresa, "Id", "nome_fantasia", pedido.fkempresa);
            return View(pedido);
        }

        // GET: pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedido pedido = db.pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pedido pedido = db.pedido.Find(id);
            db.pedido.Remove(pedido);
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
