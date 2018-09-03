using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        private List<Car> _cars = new List<Car>()
        {
            new Car { Id = 1, Name = "BMW", Price = 50000 },
            new Car { Id = 2, Name = "Lada", Price = 10000 },
            new Car { Id = 3, Name = "Honda", Price = 20000 }
        };

        // GET api/values
        [HttpGet]
        [Route("api/values")]
        public IEnumerable<string> AllString()
        {
            return new string[] { "value1", "value2" };
        }


        [Route("api/values/{id}")]
        public string Get(int id)
        {
            return $"Id: {id}";
        }

        [Route("api/values")]
        public string Get(int id, string name)
        {
            return $"Id: {id}, Name: {name}";
        }

        [HttpGet]
        [Route("api/cars")]
        public IEnumerable<Car> Cars(string orderBy = "Id", string carName = "", decimal? maxPrice = null)
        {
            List<Car> cars = _cars; 

            if(maxPrice != null)
            {
                cars = cars.Where(_ => _.Price <= maxPrice).ToList();
            }

            if(!string.IsNullOrEmpty(carName))
            {
                cars = cars.Where(_ => _.Name.Contains(carName)).ToList();
            }

            switch (orderBy) {
                case "Name":
                    return cars.OrderBy(_ => _.Name);
                case "Price":
                    return cars.OrderBy(_ => _.Price);
                default:
                    return cars.OrderBy(_ => _.Id);
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
