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
    public class EntradaProdutoDetalhesController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/EntradaProdutoDetalhes
        public IQueryable<EntradaProdutoDetalhe> GetEntradaProdutoDetalhe()
        {
            return db.EntradaProdutoDetalhe;
        }

        // GET: api/EntradaProdutoDetalhes/5
        [ResponseType(typeof(EntradaProdutoDetalhe))]
        public IHttpActionResult GetEntradaProdutoDetalhe(int id)
        {
            EntradaProdutoDetalhe entradaProdutoDetalhe = db.EntradaProdutoDetalhe.Find(id);
            if (entradaProdutoDetalhe == null)
            {
                return NotFound();
            }

            return Ok(entradaProdutoDetalhe);
        }

        // PUT: api/EntradaProdutoDetalhes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntradaProdutoDetalhe(int id, EntradaProdutoDetalhe entradaProdutoDetalhe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entradaProdutoDetalhe.Quantidade)
            {
                return BadRequest();
            }

            db.Entry(entradaProdutoDetalhe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaProdutoDetalheExists(id))
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

        // POST: api/EntradaProdutoDetalhes
        [ResponseType(typeof(EntradaProdutoDetalhe))]
        public IHttpActionResult PostEntradaProdutoDetalhe(EntradaProdutoDetalhe entradaProdutoDetalhe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EntradaProdutoDetalhe.Add(entradaProdutoDetalhe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EntradaProdutoDetalheExists(entradaProdutoDetalhe.Quantidade))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = entradaProdutoDetalhe.Quantidade }, entradaProdutoDetalhe);
        }

        // DELETE: api/EntradaProdutoDetalhes/5
        [ResponseType(typeof(EntradaProdutoDetalhe))]
        public IHttpActionResult DeleteEntradaProdutoDetalhe(int id)
        {
            EntradaProdutoDetalhe entradaProdutoDetalhe = db.EntradaProdutoDetalhe.Find(id);
            if (entradaProdutoDetalhe == null)
            {
                return NotFound();
            }

            db.EntradaProdutoDetalhe.Remove(entradaProdutoDetalhe);
            db.SaveChanges();

            return Ok(entradaProdutoDetalhe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntradaProdutoDetalheExists(int id)
        {
            return db.EntradaProdutoDetalhe.Count(e => e.Quantidade == id) > 0;
        }
    }
}