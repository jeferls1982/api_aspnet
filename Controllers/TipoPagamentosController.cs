using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEB_API_TAREFAS;

namespace WEB_API_TAREFAS.Controllers
{
    public class TipoPagamentosController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/TipoPagamentos
        public IQueryable<TipoPagamento> GetTipoPagamento()
        {
            return db.TipoPagamento;
        }

        // GET: api/TipoPagamentos/5
        [ResponseType(typeof(TipoPagamento))]
        public IHttpActionResult GetTipoPagamento(int id)
        {
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            if (tipoPagamento == null)
            {
                return NotFound();
            }

            return Ok(tipoPagamento);
        }

        // PUT: api/TipoPagamentos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoPagamento(int id, TipoPagamento tipoPagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoPagamento.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoPagamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPagamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TipoPagamentos
        [ResponseType(typeof(TipoPagamento))]
        public IHttpActionResult PostTipoPagamento(TipoPagamento tipoPagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoPagamento.Add(tipoPagamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoPagamento.Id }, tipoPagamento);
        }

        // DELETE: api/TipoPagamentos/5
        [ResponseType(typeof(TipoPagamento))]
        public IHttpActionResult DeleteTipoPagamento(int id)
        {
            TipoPagamento tipoPagamento = db.TipoPagamento.Find(id);
            if (tipoPagamento == null)
            {
                return NotFound();
            }

            db.TipoPagamento.Remove(tipoPagamento);
            db.SaveChanges();

            return Ok(tipoPagamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoPagamentoExists(int id)
        {
            return db.TipoPagamento.Count(e => e.Id == id) > 0;
        }
    }
}