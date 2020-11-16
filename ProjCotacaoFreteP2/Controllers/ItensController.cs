using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjCotacaoFreteP2.Controllers
{
    public class ItensController : Controller
    {
        private DadosEntities db = new DadosEntities();
        // GET: Itens
        public ActionResult ListarItens(int id)
        {
            var lista = db.cotacao.Where(c => c.pedido.Id == id);
            ViewBag.Pedido = id;
            return PartialView(lista);
        }

        public ActionResult SalvarCotacao(int idPedido, int fktransportadora, int dias_entrega, string valor)
        {
            var cotacao = new cotacao()
            {
                fkpedido = idPedido,
                fktransportadora = fktransportadora,
                dias_entrega = dias_entrega,
                valor = valor
            };

            db.cotacao.Add(cotacao);
            db.SaveChanges();

            return Json(new { Resultado = cotacao.Id }, JsonRequestBehavior.AllowGet);

        }
    }
}