using AlifQuotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlifQuotesAPI.Controllers
{
    /// <summary>
    /// Based on:
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.1#dependency-injection
    /// </summary>
    public class MyAppData
    {
        public List<QuoteModel> quotes=new List<QuoteModel>();
    }
}
