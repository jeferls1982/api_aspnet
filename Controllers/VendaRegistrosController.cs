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
    public class VendaRegistrosController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/VendaRegistros
        public IQueryable<VendaRegistro> GetVendaRegistro()
        {
            return db.VendaRegistro;
        }

        // GET: api/VendaRegistros/5
        [ResponseType(typeof(VendaRegistro))]
        public IHttpActionResult GetVendaRegistro(int id)
        {
            VendaRegistro vendaRegistro = db.VendaRegistro.Find(id);
            if (vendaRegistro == null)
            {
                return NotFound();
            }

            return Ok(vendaRegistro);
        }

        // PUT: api/VendaRegistros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendaRegistro(int id, VendaRegistro vendaRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendaRegistro.Id)
            {
                return BadRequest();
            }

            db.Entry(vendaRegistro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaRegistroExists(id))
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

        // POST: api/VendaRegistros
        [ResponseType(typeof(VendaRegistro))]
        public IHttpActionResult PostVendaRegistro(VendaRegistro vendaRegistro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VendaRegistro.Add(vendaRegistro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vendaRegistro.Id }, vendaRegistro);
        }

        // DELETE: api/VendaRegistros/5
        [ResponseType(typeof(VendaRegistro))]
        public IHttpActionResult DeleteVendaRegistro(int id)
        {
            VendaRegistro vendaRegistro = db.VendaRegistro.Find(id);
            if (vendaRegistro == null)
            {
                return NotFound();
            }

            db.VendaRegistro.Remove(vendaRegistro);
            db.SaveChanges();

            return Ok(vendaRegistro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendaRegistroExists(int id)
        {
            return db.VendaRegistro.Count(e => e.Id == id) > 0;
        }
    }
}