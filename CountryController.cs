using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication5.Models;

namespace WebApplication5.Controllers

{
    // [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>()
        {
            new Country{Id=1, Cname="India",Capital="Delhi"},
            new Country{Id=2, Cname="German",Capital="Berlin"},
            new Country{Id=3, Cname="Korea",Capital="Seoul"},

        };
        //Get request
        [HttpGet]
        [Route("Countrydetails")]

        public IEnumerable<Country> Get()
        {
            return countrylist;
        }



        [HttpGet]
        [Route("countrylist")]

        public HttpResponseMessage GetCountryList()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countrylist);
            return response;
        }
        //get by id
        [HttpGet]
        [Route("c")]
        public HttpResponseMessage GetP(int cid)
        {
            var country = countrylist.Find(x => x.Id == cid);

            if (country == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, cid);
            }
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

        //post request
       

        public country Post([FromBody] Country c)
        {
            countrylist.Add(c);
            return c;
        }

        //put request from body
        public IEnumerable<Country> Put(int id, [FromBody] Country country)
        {
            countrylist[id - 1] = country;
            return countrylist;
        }

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetID(int cid)
        {
            var country = countrylist.Find(x => x.Id == cid);

            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpGet]
        [Route("Name")]
        public IHttpActionResult GetCname(int cid)
        {
            string country = countrylist.Where(x => x.Id == cid).SingleOrDefault()?.Cname;

            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);



        }
    }
}
           
    

        