using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RandomNumberGeneratorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomNumberController : ControllerBase
    {
        private readonly RandomNumberGeneratorContext _context;
        private readonly ILogger<RandomNumberController> _logger;

        public RandomNumberController(RandomNumberGeneratorContext context, ILogger<RandomNumberController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<RandomNumber> GetPreviouslyGeneratedRandomNumbers()
        {
            return _context.RandomNumber;
        }
        
        [HttpPost]
        public RandomNumber CreateRandomNumber()
        {
            //create random number
            var rng = new Random();
            RandomNumber res = new RandomNumber
            {
                Value = rng.Next(10000, 99999)
            };

            //add it to db
            _context.RandomNumber.Add(res);
            _context.SaveChanges();

            return res;
        }

        [HttpDelete]
        public void DeleteAllRandomNumbers()
        {
            _context.RandomNumber.RemoveRange(_context.RandomNumber);
            _context.SaveChanges();
        }
    }
}
