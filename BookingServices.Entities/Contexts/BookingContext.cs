using BookingServices.Core.Identity;
using BookingServices.Entities.Entities.Others;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace BookingServices.Entities.Contexts;

public class BookingDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public BookingDbContext(DbContextOptions<BookingDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        _httpContextAccessor = httpContextAccessor;
    }

    public virtual DbSet<EntityHistories> EntityHistories { get; set; }

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
        SetAuditUser();
        return base.SaveChanges();
    }
    public override async Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default)
    {
        SetAuditUser();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetAuditUser()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var userId = ClaimsPrincipalExtension.GetUserId(httpContext?.User);

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
                LogChangeEntity(entry, userId);
                entry.Property("CreatedBy").IsModified = false;
                entry.Property("CreatedDate").IsModified = false;
                
            }

            entry.Property("ModifiedBy").CurrentValue = userId;
            entry.Property("ModifiedDate").CurrentValue = DateTime.UtcNow;
        }
    }

    private void LogChangeEntity(EntityEntry entry, Guid userId)
    {
        
        var primaryKey = entry.OriginalValues.Properties.FirstOrDefault(x => x.IsPrimaryKey())?.Name;
        var entityName = entry.Entity.GetType().Name;
        var entityId = entry.OriginalValues[primaryKey??"Id"]?.ToString();
        var changeData = new Dictionary<string, string>();
        
        foreach (var property in entry.OriginalValues.Properties)
        {
            var propertyName = property.Name;
            var originalValue = entry.OriginalValues[property]?.ToString();
            var currentValue = entry.CurrentValues[property]?.ToString();

            //if state add then add into changeData with format key is propertyName and value is null --> currentValue
           if (entry.State == EntityState.Added)
        {
            changeData.Add(propertyName, "null --> " + currentValue);
        }
        else if (entry.State == EntityState.Deleted)
        {
            changeData.Add(propertyName, originalValue + " --> null");
        }
        else if (originalValue != currentValue)
        {
            changeData.Add(propertyName, originalValue + " --> " + currentValue);
        }
        }

        if (changeData.Any())
        {
            var entityHistory = new EntityHistories
            {
                EntityName = entityName,
                EntityId = entityId,
                EntityChangeData = JsonConvert.SerializeObject(changeData),
                Action = entry.State.ToString(),
                ActionBy = userId.ToString(),
                ActionDate = DateTime.UtcNow

            };
            Set<EntityHistories>().Add(entityHistory);
        }

    }
}
