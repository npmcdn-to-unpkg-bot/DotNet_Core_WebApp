using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCore.Common;

namespace DotNet_Core.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private SQLiteHelper helper;
        public ValuesController(SQLiteHelper sqiteHelper)
        {
            helper = sqiteHelper;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var reader = helper.ExecuteReader("select * from person", System.Data.CommandType.Text);

            List<string> list = new List<string>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = reader.GetString(1);
                    list.Add(name);
                }
            }

            return list;
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
}
