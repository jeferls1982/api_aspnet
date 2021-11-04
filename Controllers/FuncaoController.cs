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
    public class FuncaoController : ApiController
    {
        private jlsEntities1 db = new jlsEntities1();

        // GET: api/Funcao
        public IQueryable<Funcao> GetFuncao()
        {
            return db.Funcao;
        }

        // GET: api/Funcao/5
        [ResponseType(typeof(Funcao))]
        public IHttpActionResult GetFuncao(int id)
        {
            Funcao funcao = db.Funcao.Find(id);
            if (funcao == null)
            {
                return NotFound();
            }

            return Ok(funcao);
        }

        // PUT: api/Funcao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncao(int id, Funcao funcao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcao.Id)
            {
                return BadRequest();
            }

            db.Entry(funcao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncaoExists(id))
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

        // POST: api/Funcao
        [ResponseType(typeof(Funcao))]
        public IHttpActionResult PostFuncao(Funcao funcao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Funcao.Add(funcao);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = funcao.Id }, funcao);
        }

        // DELETE: api/Funcao/5
        [ResponseType(typeof(Funcao))]
        public IHttpActionResult DeleteFuncao(int id)
        {
            Funcao funcao = db.Funcao.Find(id);
            if (funcao == null)
            {
                return NotFound();
            }

            db.Funcao.Remove(funcao);
            db.SaveChanges();

            return Ok(funcao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncaoExists(int id)
        {
            return db.Funcao.Count(e => e.Id == id) > 0;
        }
    }
}