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
    public class CidadesController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/Cidades
        public IQueryable<Cidade> GetCidade()
        {
            return db.Cidade;
        }

        // GET: api/Cidades/5
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult GetCidade(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return NotFound();
            }

            return Ok(cidade);
        }

        // PUT: api/Cidades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCidade(int id, Cidade cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cidade.Id)
            {
                return BadRequest();
            }

            db.Entry(cidade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(id))
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

        // POST: api/Cidades
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult PostCidade(Cidade cidade)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cidade.Add(cidade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cidade.Id }, cidade);
        }

        // DELETE: api/Cidades/5
        [ResponseType(typeof(Cidade))]
        public IHttpActionResult DeleteCidade(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            if (cidade == null)
            {
                return NotFound();
            }

            db.Cidade.Remove(cidade);
            db.SaveChanges();

            return Ok(cidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CidadeExists(int id)
        {
            return db.Cidade.Count(e => e.Id == id) > 0;
        }
    }
}