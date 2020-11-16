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
    public class embalagemsController : Controller
    {
        private DadosEntities db = new DadosEntities();

        // GET: embalagems
        public ActionResult Index()
        {
            return View(db.embalagem.ToList());
        }

        // GET: embalagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            embalagem embalagem = db.embalagem.Find(id);
            if (embalagem == null)
            {
                return HttpNotFound();
            }
            return View(embalagem);
        }

        // GET: embalagems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: embalagems/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descricao,altura,largura,comprimento")] embalagem embalagem)
        {
            if (ModelState.IsValid)
            {
                db.embalagem.Add(embalagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(embalagem);
        }

        // GET: embalagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            embalagem embalagem = db.embalagem.Find(id);
            if (embalagem == null)
            {
                return HttpNotFound();
            }
            return View(embalagem);
        }

        // POST: embalagems/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descricao,altura,largura,comprimento")] embalagem embalagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(embalagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(embalagem);
        }

        // GET: embalagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            embalagem embalagem = db.embalagem.Find(id);
            if (embalagem == null)
            {
                return HttpNotFound();
            }
            return View(embalagem);
        }

        // POST: embalagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            embalagem embalagem = db.embalagem.Find(id);
            db.embalagem.Remove(embalagem);
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
