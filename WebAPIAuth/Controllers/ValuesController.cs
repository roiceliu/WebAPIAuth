using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIAuth.DAL;
using System.Data.Entity;

namespace WebAPIAuth.Controllers
{
    [Authorize]
    //[AllowAnonymous]
    public class ValuesController : ApiController
    {
        internal TestEntities context = new TestEntities();

        
        // GET api/values
        [AllowAnonymous]
        public IEnumerable<Student> Get()
        {            
            return context.Students.ToList();
        }

        // GET api/values/5
        public Student Get(int id)
        {
            return context.Students.Find(id.ToString());
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            context.Students.Add(student);
            context.SaveChanges();
            return Ok();

        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            context.Students.Attach(student);
            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Student student = Get(id);
            context.Students.Remove(student);
            context.SaveChanges();
        }
    }
}
