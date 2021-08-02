using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyManageAPI.Context;
using UdemyManageAPI.Models;

namespace UdemyManageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly AppDbContext context;
        public PersonController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = context.persons.ToArray();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public ActionResult Get(int id)
        {
            try
            {
                var result = context.persons.FirstOrDefault(p => p.Person_id == id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Person person)
        {
            try
            {
                context.persons.Add(person);
                context.SaveChanges();
                return CreatedAtRoute("GetPerson", new { id = person.Person_id }, person);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Person person)
        {
            try
            {
                if (person.Person_id == id)
                {
                    context.Entry(person).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPerson", new { id = person.Person_id }, person);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var showAll = context.persons.ToArray();
                var result = context.persons.FirstOrDefault(p => p.Person_id == id);
                if (result != null)
                {
                    context.persons.Remove(result);
                    context.SaveChanges();
                    return Ok(showAll);
                }   
                else
                {
                    return BadRequest();
                }             
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}