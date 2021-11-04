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
    public class OrcamentoDetalhesController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/OrcamentoDetalhes
        public IQueryable<OrcamentoDetalhe> GetOrcamentoDetalhe()
        {
            return db.OrcamentoDetalhe;
        }

        // GET: api/OrcamentoDetalhes/5
        [ResponseType(typeof(OrcamentoDetalhe))]
        public IHttpActionResult GetOrcamentoDetalhe(int id)
        {
            OrcamentoDetalhe orcamentoDetalhe = db.OrcamentoDetalhe.Find(id);
            if (orcamentoDetalhe == null)
            {
                return NotFound();
            }

            return Ok(orcamentoDetalhe);
        }

        // PUT: api/OrcamentoDetalhes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrcamentoDetalhe(int id, OrcamentoDetalhe orcamentoDetalhe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orcamentoDetalhe.OrcamentoRegistroId)
            {
                return BadRequest();
            }

            db.Entry(orcamentoDetalhe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrcamentoDetalheExists(id))
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

        // POST: api/OrcamentoDetalhes
        [ResponseType(typeof(OrcamentoDetalhe))]
        public IHttpActionResult PostOrcamentoDetalhe(OrcamentoDetalhe orcamentoDetalhe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrcamentoDetalhe.Add(orcamentoDetalhe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrcamentoDetalheExists(orcamentoDetalhe.OrcamentoRegistroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orcamentoDetalhe.OrcamentoRegistroId }, orcamentoDetalhe);
        }

        // DELETE: api/OrcamentoDetalhes/5
        [ResponseType(typeof(OrcamentoDetalhe))]
        public IHttpActionResult DeleteOrcamentoDetalhe(int id)
        {
            OrcamentoDetalhe orcamentoDetalhe = db.OrcamentoDetalhe.Find(id);
            if (orcamentoDetalhe == null)
            {
                return NotFound();
            }

            db.OrcamentoDetalhe.Remove(orcamentoDetalhe);
            db.SaveChanges();

            return Ok(orcamentoDetalhe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrcamentoDetalheExists(int id)
        {
            return db.OrcamentoDetalhe.Count(e => e.OrcamentoRegistroId == id) > 0;
        }
    }
}