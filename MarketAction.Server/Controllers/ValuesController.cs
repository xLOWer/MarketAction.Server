using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarketAction.Server.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketAction.Server.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            JArray array = new JArray();
            JObject o = new JObject();   
            for (int i = 0; i <= 5; ++i)
            {
                var user = new User()
                {
                    Login = "login" + i.ToString(),
                    Password = "password" + i.ToString()
                };

                array.Add(JsonConvert.SerializeObject(user));
            }

            o["Users"] = array;
            var result = o.ToString();
            return result;
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
