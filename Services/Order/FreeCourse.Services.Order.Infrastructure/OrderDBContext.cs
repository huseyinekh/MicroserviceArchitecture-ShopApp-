using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Services.Order.Infrastructure
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options)
        {

        }
        private readonly string DEFAULT_SCHEME = "order";

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public DbSet<Sevices.Order.Domain.OrderAggregate.Order> Orders { get; set; }
        public DbSet<Sevices.Order.Domain.OrderAggregate.OrderItem> OrderItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sevices.Order.Domain.OrderAggregate.Order>().ToTable("Orders", DEFAULT_SCHEME);
            modelBuilder.Entity<Sevices.Order.Domain.OrderAggregate.OrderItem>().ToTable("OrderItems", DEFAULT_SCHEME);
            modelBuilder.Entity<Sevices.Order.Domain.OrderAggregate.OrderItem>()
                .Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Sevices.Order.Domain.OrderAggregate.Order>().OwnsOne(o => o.Address).WithOwner();

            base.OnModelCreating(modelBuilder);
        }



    }
}
