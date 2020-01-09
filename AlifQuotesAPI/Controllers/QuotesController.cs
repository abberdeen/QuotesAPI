using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlifQuotesAPI.Models;
using Microsoft.AspNetCore.Mvc; 

namespace AlifQuotesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private MyAppData _myService;

        public QuotesController( MyAppData myService)
        {
           _myService = myService;
        }

        // GET api/quotes
        [HttpGet]
        public ActionResult<List<QuoteModel>> Get()
        {
            return _myService.quotes;
        }

        // GET by id api/quotes/5
        [HttpGet("{id}")]
        public ActionResult<QuoteModel> Get(int id)
        {
            if (Exists(id))           
            {
                return _myService.quotes[id];
            }
            return NotFound();
        }

        // GET by category api/quotes/category/abc
        [HttpGet("category/{category}")]
        public ActionResult<List<QuoteModel>> Get(string category)
        {
           return _myService.quotes.FindAll((QuoteModel q) => { return q.Category.ToLower() == category.ToLower(); });      
        }


        // GET random api/quotes/random
        [HttpGet("random")]
        public ActionResult<QuoteModel> Random()
        { 
            int RandomId = new Random().Next(0, _myService.quotes.Count);
            return _myService.quotes[RandomId];
        }

        // POST api/quotes
        [HttpPost]
        public void Post([FromBody] QuoteModel value)
        {
            value.CreationTime = DateTime.Now;
            value.EditTime = DateTime.Now;
            _myService.quotes.Add(value);
        }

        // PUT api/quotes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] QuoteModel value)
        {
            if (Exists(id)) 
            {
                var creationTime = _myService.quotes[id].CreationTime;
                _myService.quotes[id] = value;
                _myService.quotes[id].EditTime = DateTime.Now;
                _myService.quotes[id].CreationTime = creationTime;
            }
            NotFound();
        }

        // DELETE api/quotes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (Exists(id))
            {
                _myService.quotes.RemoveAt(id);
            }
        }

        // DELETE api/quotes/clear
        [HttpDelete("clear")]
        public void DeleteByOffset()
        { 
            _myService.quotes.RemoveAll(IsHourElapsed);
        }

        private bool Exists(int id)
        {
            return (id < _myService.quotes.Count && id > -1);
        }

        private bool IsHourElapsed(QuoteModel item) 
        {
            return DateTime.Now.Subtract(item.CreationTime).TotalMinutes > 60; 
        }
    }
}
