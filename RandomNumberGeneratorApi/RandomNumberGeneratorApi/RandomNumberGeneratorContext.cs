using Microsoft.EntityFrameworkCore;

namespace RandomNumberGeneratorApi
    {
        public class RandomNumberGeneratorContext : DbContext
        {
            public RandomNumberGeneratorContext(DbContextOptions<RandomNumberGeneratorContext> options)
                : base(options)
            {
            }

            public DbSet<RandomNumber> RandomNumber { get; set; }
    }
}
