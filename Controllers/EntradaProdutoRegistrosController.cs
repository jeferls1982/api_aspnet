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
    public class EntradaProdutoRegistrosController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/EntradaProdutoRegistros
        public IQueryable<EntradaProdutoRegistro> GetEntradaProdutoRegistro()
        {
            return db.EntradaProdutoRegistro;
        }

        // GET: api/EntradaProdutoRegistros/5
        [ResponseType(typeof(EntradaProdutoRegistro))]
        public IHttpActionResult GetEntradaProdutoRegistro(int id)
        {
            EntradaProdutoRegistro entradaProdutoRegistro = db.EntradaProdutoRegistro.Find(id);
            if (entradaProdutoRegistro == null)
            {
                return NotFound();
            }

            return Ok(entradaProdutoRegistro);
        }

        // PUT: api/EntradaProdutoRegistros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntradaProdutoRegistro(int id, EntradaProdutoRegistro entradaProdutoRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entradaProdutoRegistro.Id)
            {
                return BadRequest();
            }

            db.Entry(entradaProdutoRegistro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaProdutoRegistroExists(id))
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

        // POST: api/EntradaProdutoRegistros
        [ResponseType(typeof(EntradaProdutoRegistro))]
        public IHttpActionResult PostEntradaProdutoRegistro(EntradaProdutoRegistro entradaProdutoRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EntradaProdutoRegistro.Add(entradaProdutoRegistro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entradaProdutoRegistro.Id }, entradaProdutoRegistro);
        }

        // DELETE: api/EntradaProdutoRegistros/5
        [ResponseType(typeof(EntradaProdutoRegistro))]
        public IHttpActionResult DeleteEntradaProdutoRegistro(int id)
        {
            EntradaProdutoRegistro entradaProdutoRegistro = db.EntradaProdutoRegistro.Find(id);
            if (entradaProdutoRegistro == null)
            {
                return NotFound();
            }

            db.EntradaProdutoRegistro.Remove(entradaProdutoRegistro);
            db.SaveChanges();

            return Ok(entradaProdutoRegistro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntradaProdutoRegistroExists(int id)
        {
            return db.EntradaProdutoRegistro.Count(e => e.Id == id) > 0;
        }
    }
}