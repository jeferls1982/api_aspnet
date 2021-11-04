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
    public class VendaDetalhesController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/VendaDetalhes
        public IQueryable<VendaDetalhe> GetVendaDetalhe()
        {
            return db.VendaDetalhe;
        }

        // GET: api/VendaDetalhes/5
        [ResponseType(typeof(VendaDetalhe))]
        public IHttpActionResult GetVendaDetalhe(int id)
        {
            VendaDetalhe vendaDetalhe = db.VendaDetalhe.Find(id);
            if (vendaDetalhe == null)
            {
                return NotFound();
            }

            return Ok(vendaDetalhe);
        }

        // PUT: api/VendaDetalhes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendaDetalhe(int id, VendaDetalhe vendaDetalhe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendaDetalhe.VendaRegistroId)
            {
                return BadRequest();
            }

            db.Entry(vendaDetalhe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaDetalheExists(id))
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

        // POST: api/VendaDetalhes
        [ResponseType(typeof(VendaDetalhe))]
        public IHttpActionResult PostVendaDetalhe(VendaDetalhe vendaDetalhe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VendaDetalhe.Add(vendaDetalhe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VendaDetalheExists(vendaDetalhe.VendaRegistroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vendaDetalhe.VendaRegistroId }, vendaDetalhe);
        }

        // DELETE: api/VendaDetalhes/5
        [ResponseType(typeof(VendaDetalhe))]
        public IHttpActionResult DeleteVendaDetalhe(int id)
        {
            VendaDetalhe vendaDetalhe = db.VendaDetalhe.Find(id);
            if (vendaDetalhe == null)
            {
                return NotFound();
            }

            db.VendaDetalhe.Remove(vendaDetalhe);
            db.SaveChanges();

            return Ok(vendaDetalhe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendaDetalheExists(int id)
        {
            return db.VendaDetalhe.Count(e => e.VendaRegistroId == id) > 0;
        }
    }
}