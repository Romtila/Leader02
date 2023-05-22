using Leader.Domain.Entity;
using Leader02.Infrastructure.DbConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Leader02.Infrastructure;

public class Leader02Context : DbContext
{
    public Leader02Context()
    {
    }

    public Leader02Context(DbContextOptions<Leader02Context> options) : base(options)
    {
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdminUserConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentUserConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new SubDepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new ConsultationConfiguration());
        modelBuilder.ApplyConfiguration(new ConsultationSlotConfiguration());
        modelBuilder.ApplyConfiguration(new ChatBotRequestConfiguration());
        modelBuilder.ApplyConfiguration(new ChatBotRequestMessageConfiguration());

        modelBuilder.DateTimeWithoutTimeZoneConfigure();

        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasPostgresExtension("fuzzystrmatch");
    }

    public DbSet<AdminUser> AdminUsers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<DepartmentUser> DepartmentUsers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<SubDepartment> SubDepartments { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<ConsultationSlot> ConsultationSlots { get; set; }
    public DbSet<ConsultationTopic> ConsultationTopics { get; set; }
    public DbSet<ChatBotRequest> ChatBotRequests { get; set; }
    public DbSet<ChatBotRequestMessage> ChatBotRequestsMessages { get; set; }
    public DbSet<LegalAct> LegalActs { get; set; }
    public DbSet<OpenControlService> OpenControlServices { get; set; }
    public DbSet<Requirement> Requirements { get; set; }
}