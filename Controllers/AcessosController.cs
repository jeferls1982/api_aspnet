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
    public class AcessosController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/Acessos
        public IQueryable<Acesso> GetAcesso()
        {
            return db.Acesso;
        }

        // GET: api/Acessos/5
        [ResponseType(typeof(Acesso))]
        public IHttpActionResult GetAcesso(int id)
        {
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return NotFound();
            }

            return Ok(acesso);
        }

        // PUT: api/Acessos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAcesso(int id, Acesso acesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acesso.Id)
            {
                return BadRequest();
            }

            db.Entry(acesso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcessoExists(id))
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

        // POST: api/Acessos
        [ResponseType(typeof(Acesso))]
        public IHttpActionResult PostAcesso(Acesso acesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Acesso.Add(acesso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = acesso.Id }, acesso);
        }

        // DELETE: api/Acessos/5
        [ResponseType(typeof(Acesso))]
        public IHttpActionResult DeleteAcesso(int id)
        {
            Acesso acesso = db.Acesso.Find(id);
            if (acesso == null)
            {
                return NotFound();
            }

            db.Acesso.Remove(acesso);
            db.SaveChanges();

            return Ok(acesso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AcessoExists(int id)
        {
            return db.Acesso.Count(e => e.Id == id) > 0;
        }
    }
}