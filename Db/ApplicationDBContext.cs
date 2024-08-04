namespace getData.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserInfo> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=Cqibbv6n;Database=userAuth");
        }
    }
}
