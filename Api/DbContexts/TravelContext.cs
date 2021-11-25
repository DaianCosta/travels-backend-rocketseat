using Microsoft.EntityFrameworkCore;
using Api.Entities;
using System;

namespace Api.DbContexts
{
    public class TravelContext : DbContext
    {
        public TravelContext()
        {

        }

        public TravelContext(DbContextOptions<TravelContext> options)
           : base(options)
        {

        }

        public virtual DbSet<Travel> Travel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Travel>().HasData(

                new Travel() { Id = Guid.NewGuid(), Destiny = "Rio de Janeiro", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Natal", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Maceio", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "São Paulo", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Florianopolis", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Milão", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Roma", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Turim", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Cancum", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Nova York", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Londres", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Manchester", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Liverpool", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Madrid", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Valencia", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Barcelona", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Porto", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Lisboa", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Munique", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Berlim", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Hamburgo", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Boston", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Porto Alegre", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Tokio", Date = DateTime.Now, DateRegister = DateTime.Now },
                new Travel() { Id = Guid.NewGuid(), Destiny = "Moscow", Date = DateTime.Now, DateRegister = DateTime.Now }

            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
