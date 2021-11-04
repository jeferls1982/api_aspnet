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
    public class PedidoRegistrosController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/PedidoRegistros
        public IQueryable<PedidoRegistro> GetPedidoRegistro()
        {
            return db.PedidoRegistro;
        }

        // GET: api/PedidoRegistros/5
        [ResponseType(typeof(PedidoRegistro))]
        public IHttpActionResult GetPedidoRegistro(int id)
        {
            PedidoRegistro pedidoRegistro = db.PedidoRegistro.Find(id);
            if (pedidoRegistro == null)
            {
                return NotFound();
            }

            return Ok(pedidoRegistro);
        }

        // PUT: api/PedidoRegistros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedidoRegistro(int id, PedidoRegistro pedidoRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidoRegistro.Id)
            {
                return BadRequest();
            }

            db.Entry(pedidoRegistro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoRegistroExists(id))
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

        // POST: api/PedidoRegistros
        [ResponseType(typeof(PedidoRegistro))]
        public IHttpActionResult PostPedidoRegistro(PedidoRegistro pedidoRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PedidoRegistro.Add(pedidoRegistro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidoRegistro.Id }, pedidoRegistro);
        }

        // DELETE: api/PedidoRegistros/5
        [ResponseType(typeof(PedidoRegistro))]
        public IHttpActionResult DeletePedidoRegistro(int id)
        {
            PedidoRegistro pedidoRegistro = db.PedidoRegistro.Find(id);
            if (pedidoRegistro == null)
            {
                return NotFound();
            }

            db.PedidoRegistro.Remove(pedidoRegistro);
            db.SaveChanges();

            return Ok(pedidoRegistro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PedidoRegistroExists(int id)
        {
            return db.PedidoRegistro.Count(e => e.Id == id) > 0;
        }
    }
}