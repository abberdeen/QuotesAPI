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

        // GET api/quotes/5
        [HttpGet("{id}")]
        public ActionResult<QuoteModel> Get(int id)
        {
            if (_myService.Exists(id))           
            {
                return _myService.quotes[id];
            }
            return NotFound();
        }

        // GET api/quotes/category/abc
        [HttpGet("category/{category}")]
        public ActionResult<List<QuoteModel>> Get(string category)
        {
            return _myService.QuotesByCategory(category);
        }


        // GET api/quotes/random
        [HttpGet("random")]
        public ActionResult<QuoteModel> Random()
        {
            return _myService.RandomQuote();
        }

        // POST api/quotes
        [HttpPost]
        public void Post([FromBody] QuoteModel value)
        {
            _myService.AddQuote(value);
        }

        // PUT api/quotes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] QuoteModel value)
        {
            if (_myService.Exists(id)) 
            {
                _myService.UpdateQuote(id,value);
            }
            NotFound();
        }

        // DELETE api/quotes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_myService.Exists(id))
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

        private bool IsHourElapsed(QuoteModel item) 
        {
            return DateTime.Now.Subtract(item.CreationTime).TotalMinutes > 60; 
        }
    }
}
