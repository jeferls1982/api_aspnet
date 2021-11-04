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
    public class TipoFornecedorController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/TipoFornecedor
        public IQueryable<TipoFornecedor> GetTipoFornecedor()
        {
            return db.TipoFornecedor;
        }

        // GET: api/TipoFornecedor/5
        [ResponseType(typeof(TipoFornecedor))]
        public IHttpActionResult GetTipoFornecedor(int id)
        {
            TipoFornecedor tipoFornecedor = db.TipoFornecedor.Find(id);
            if (tipoFornecedor == null)
            {
                return NotFound();
            }

            return Ok(tipoFornecedor);
        }

        // PUT: api/TipoFornecedor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoFornecedor(int id, TipoFornecedor tipoFornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoFornecedor.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoFornecedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoFornecedorExists(id))
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

        // POST: api/TipoFornecedor
        [ResponseType(typeof(TipoFornecedor))]
        public IHttpActionResult PostTipoFornecedor(TipoFornecedor tipoFornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoFornecedor.Add(tipoFornecedor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoFornecedor.Id }, tipoFornecedor);
        }

        // DELETE: api/TipoFornecedor/5
        [ResponseType(typeof(TipoFornecedor))]
        public IHttpActionResult DeleteTipoFornecedor(int id)
        {
            TipoFornecedor tipoFornecedor = db.TipoFornecedor.Find(id);
            if (tipoFornecedor == null)
            {
                return NotFound();
            }

            db.TipoFornecedor.Remove(tipoFornecedor);
            db.SaveChanges();

            return Ok(tipoFornecedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoFornecedorExists(int id)
        {
            return db.TipoFornecedor.Count(e => e.Id == id) > 0;
        }
    }
}