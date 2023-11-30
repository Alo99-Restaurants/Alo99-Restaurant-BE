using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Entities.Contexts
{
    public class BookingDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookingDbContext(DbContextOptions<BookingDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual DbSet<Entities.Customers> Customers { get; set; }
        public virtual DbSet<Entities.RestaurantInformation> RestaurantInformation { get; set; }
        public virtual DbSet<Entities.RestaurantImages> RestaurantImages { get; set; }
        public virtual DbSet<Entities.Users> Users { get; set; }
        public virtual DbSet<Entities.Restaurants> Restaurants { get; set; }
        public virtual DbSet<Entities.RestaurantFloors> RestaurantFloors { get; set; }
        public virtual DbSet<Entities.Tables> Tables { get; set; }
        public virtual DbSet<Entities.Bookings> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureBaseService();
        }

        public override int SaveChanges()
        {
            SetAuditInformation();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            SetAuditInformation();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetAuditInformation()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userId = Guid.Empty;

            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedBy").CurrentValue = userId;
                    entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedBy").IsModified = false;
                    entry.Property("CreatedDate").IsModified = false;
                }
                entry.Property("ModifiedBy").CurrentValue = userId;
                entry.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
