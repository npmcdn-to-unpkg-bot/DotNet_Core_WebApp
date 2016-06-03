using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.Sqlite;

namespace DotNet_Core.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public DB DB { get; set; }

        public ValuesController(DB db)
        {
            this.DB = db;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var persons = DB.Persons.ToList();
            return persons;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [Table("person")]
    public class Person
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("age")]
        public int Age { get; set; }
    }

    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options)
            : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
