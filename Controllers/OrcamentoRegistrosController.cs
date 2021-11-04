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
    public class OrcamentoRegistrosController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/OrcamentoRegistros
        public IQueryable<OrcamentoRegistro> GetOrcamentoRegistro()
        {
            return db.OrcamentoRegistro;
        }

        // GET: api/OrcamentoRegistros/5
        [ResponseType(typeof(OrcamentoRegistro))]
        public IHttpActionResult GetOrcamentoRegistro(int id)
        {
            OrcamentoRegistro orcamentoRegistro = db.OrcamentoRegistro.Find(id);
            if (orcamentoRegistro == null)
            {
                return NotFound();
            }

            return Ok(orcamentoRegistro);
        }

        // PUT: api/OrcamentoRegistros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrcamentoRegistro(int id, OrcamentoRegistro orcamentoRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orcamentoRegistro.Id)
            {
                return BadRequest();
            }

            db.Entry(orcamentoRegistro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrcamentoRegistroExists(id))
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

        // POST: api/OrcamentoRegistros
        [ResponseType(typeof(OrcamentoRegistro))]
        public IHttpActionResult PostOrcamentoRegistro(OrcamentoRegistro orcamentoRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrcamentoRegistro.Add(orcamentoRegistro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orcamentoRegistro.Id }, orcamentoRegistro);
        }

        // DELETE: api/OrcamentoRegistros/5
        [ResponseType(typeof(OrcamentoRegistro))]
        public IHttpActionResult DeleteOrcamentoRegistro(int id)
        {
            OrcamentoRegistro orcamentoRegistro = db.OrcamentoRegistro.Find(id);
            if (orcamentoRegistro == null)
            {
                return NotFound();
            }

            db.OrcamentoRegistro.Remove(orcamentoRegistro);
            db.SaveChanges();

            return Ok(orcamentoRegistro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrcamentoRegistroExists(int id)
        {
            return db.OrcamentoRegistro.Count(e => e.Id == id) > 0;
        }
    }
}