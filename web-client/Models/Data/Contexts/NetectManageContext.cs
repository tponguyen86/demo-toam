using Microsoft.EntityFrameworkCore;
using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Data.Entities;

namespace web_client.Models.Data.Contexts;

public class NetectManageContext : DbContext
{
    public NetectManageContext(DbContextOptions<NetectManageContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryDetail> CategoryDetails { get; set; }
    public DbSet<RoleFeature> RoleFeatures { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<PageConfiguration> PageConfigurations { get; set; }
    public DbSet<SystemConfiguration> SystemConfigurations { get; set; }
    public DbSet<CustomerRating> CustomerRatings { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<GroupProductSetting> GroupProductSettings { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PredefineData> PredefinesData { get; set; }
}
