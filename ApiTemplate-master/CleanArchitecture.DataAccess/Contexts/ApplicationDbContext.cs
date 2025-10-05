using CleanArchitecture.DataAccess.Models;
using CleanArchitecture.DataAccess.Models.Fact_models;
using CleanArchitecture.DataAccess.Models.Staging_models;
using CleanArchitecture.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CleanArchitecture.DataAccess.Contexts
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Governrate> Governrates { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Tower> Towers { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Cable> Cables { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ProblemType> ProblemTypes { get; set; }
        public DbSet<CuttingDownA> CuttingDownAs { get; set; }
        public DbSet<CuttingDownB> CuttingDownBs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Cutting_Down_Header> Cutting_Down_Headers { get; set; }
        public DbSet<Cutting_Down_Detail> Cutting_Down_Details { get; set; }
        public DbSet<Cutting_Down_Ignored> Cutting_Down_Ignoreds { get; set; }
        public DbSet<Network_Element> Network_Elements { get; set; }
        public DbSet<Network_Element_Hierarchy_Path> Network_Element_Hierarchy_Paths { get; set; }
        public DbSet<Network_Element_Type> Network_Element_Type { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Governrate -> Sector (1-to-many)
            builder.Entity<Governrate>()
                .HasKey(g => g.Governrate_Key);

            builder.Entity<Governrate>()
                .HasMany(g => g.Sectors)
                .WithOne(s => s.Governrate)
                .HasForeignKey(s => s.Governrate_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Sector -> Zone (1-to-many)
            builder.Entity<Sector>()
                .HasKey(s => s.Sector_Key);

            builder.Entity<Sector>()
                .HasMany(s => s.Zones)
                .WithOne(z => z.Sector)
                .HasForeignKey(z => z.Sector_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Zone -> City (1-to-many)
            builder.Entity<Zone>()
                .HasKey(z => z.Zone_Key);

            builder.Entity<Zone>()
                .HasMany(z => z.Cities)
                .WithOne(c => c.Zone)
                .HasForeignKey(c => c.Zone_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // City -> Station (1-to-many)
            builder.Entity<City>()
                .HasKey(c => c.City_Key);

            builder.Entity<City>()
                .HasMany(c => c.Stations)
                .WithOne(st => st.City)
                .HasForeignKey(st => st.City_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Station -> Tower (1-to-many) 
            builder.Entity<Station>()
                .HasKey(st => st.Station_Key);

            builder.Entity<Station>()
                .HasMany(st => st.Towers)
                .WithOne(t => t.Station)
                .HasForeignKey(t => t.Station_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Tower -> Cabin (1-to-many)
            builder.Entity<Tower>()
                .HasKey(t => t.Tower_Key);

            builder.Entity<Tower>()
                .HasMany(t => t.Cabins)
                .WithOne(ca => ca.Tower)
                .HasForeignKey(ca => ca.Tower_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Cabin -> Cable (1-to-many)
            builder.Entity<Cabin>()
                .HasKey(ca => ca.Cabin_Key);

            builder.Entity<Cabin>()
                .HasMany(ca => ca.Cables)
                .WithOne(cb => cb.Cabin)
                .HasForeignKey(cb => cb.Cabin_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Cable -> Block (1-to-many)
            builder.Entity<Cable>()
                .HasKey(cb => cb.Cable_Key);

            builder.Entity<Cable>()
                .HasMany(cb => cb.Blocks)
                .WithOne(b => b.Cable)
                .HasForeignKey(b => b.Cable_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Block -> Building (1-to-many)
            builder.Entity<Block>()
                .HasKey(b => b.Block_Key);

            builder.Entity<Block>()
                .HasMany(b => b.Buildings)
                .WithOne(bu => bu.Block)
                .HasForeignKey(bu => bu.Block_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Building -> Flat (1-to-many)
            builder.Entity<Building>()
                .HasKey(bu => bu.Building_Key);

            builder.Entity<Building>()
                .HasMany(bu => bu.Flats)
                .WithOne(f => f.Building)
                .HasForeignKey(f => f.Building_Key)
                .OnDelete(DeleteBehavior.Cascade);

            
            // Flat: composite key
            builder.Entity<Flat>()
                .HasKey(f => new { f.Flat_Key, f.Building_Key });

            // Flat -> Building (many-to-one)
            builder.Entity<Flat>()
                .HasOne(f => f.Building)
                .WithMany(b => b.Flats)
                .HasForeignKey(f => f.Building_Key)
                .OnDelete(DeleteBehavior.Cascade);

            // Subscription: primary key
            builder.Entity<Subscription>()
                .HasKey(s => s.Subscription_Key);

            // Subscription -> Flat (many-to-one) using composite FK, cascade delete on Subscription when Flat is deleted
            builder.Entity<Subscription>()
                .HasOne(s => s.Flat)
                .WithMany(f => f.Subscriptions)
                .HasForeignKey(s => new { s.Flat_Key, s.Building_Key })
                .OnDelete(DeleteBehavior.Cascade);

            // Subscription -> Building (many-to-one) only restrict delete to avoid multiple cascade paths
            builder.Entity<Subscription>()
                .HasOne<Building>()
                .WithMany()
                .HasForeignKey(s => s.Building_Key)
                .OnDelete(DeleteBehavior.Restrict);
            // fact models-------------------------------------------------------------------------------------
            // User
            builder.Entity<User>().HasKey(u => u.User_Key);



            // Channel
            builder.Entity<Channel>(entity =>
            {
                entity.HasKey(e => e.Channel_Key);
                entity.Property(e => e.Channel_Name).IsRequired().HasMaxLength(100);
            });

            // Cutting_Down_Header
            builder.Entity<Cutting_Down_Header>(entity =>
            {
                // Define the primary key for the entity
                entity.HasKey(e => e.Cutting_Down_Key);

                // Define required properties
                entity.Property(e => e.Cutting_Down_Incident_ID).IsRequired();
                entity.Property(e => e.ActualCreatetDate).IsRequired();
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                // Configure the relationship with the Channel entity
                entity.HasOne(e => e.Channel)
                    .WithMany()
                    .HasForeignKey(e => e.Channel_Key)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure the relationship with the Cutting_Down_Problem_Type entity
                entity.HasOne(e => e.Problem_Type)
                    .WithMany()
                    .HasForeignKey(e => e.Cutting_Down_Problem_Type_Key)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure the one-to-many relationship with Cutting_Down_Details
                entity.HasMany(e => e.Cutting_Down_Details)
                    .WithOne(d => d.Cutting_Down_Header)
                    .HasForeignKey(d => d.Cutting_Down_Key)
                    .OnDelete(DeleteBehavior.Cascade);

                // Update the relationship with Cutting_Down_Ignored entity
                entity.HasMany(e => e.Cutting_Down_Ignoreds)
                    .WithOne(i => i.Cutting_Down_Header)
                    .HasForeignKey(i => i.Cutting_Down_Key)  // Use Cutting_Down_Key instead of Cutting_Down_HeaderCutting_Down_Key
                    .IsRequired(false)  // Allow the relationship to be optional (nullable foreign key)
                    .OnDelete(DeleteBehavior.SetNull);  // If the Cutting_Down_Header is deleted, set Cutting_Down_Key to NULL
            });


            // Cutting_Down_Detail
            builder.Entity<Cutting_Down_Detail>(entity =>
            {
                entity.HasKey(e => e.Cutting_Down_Detail_Key);

                entity.Property(e => e.ActualCreatetDate).IsRequired();

                entity.HasOne(e => e.Cutting_Down_Header)
                    .WithMany(h => h.Cutting_Down_Details)
                    .HasForeignKey(e => e.Cutting_Down_Key)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Network_Element)
                    .WithMany()
                    .HasForeignKey(e => e.Network_Element_Key)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Cutting_Down_Ignored
          

            // If you want to add a second nullable foreign key relationship (Cutting_Down_Key)
            builder.Entity<Cutting_Down_Ignored>()
                .HasOne(c => c.Cutting_Down_Header)  // Relating to Cutting_Down_Header
                .WithMany()  // Assuming a one-to-many relationship
                .HasForeignKey(c => c.Cutting_Down_Key)  // This is the nullable foreign key property
                .OnDelete(DeleteBehavior.SetNull);

            // Network_Element
            builder.Entity<Network_Element>(entity =>
            {
                entity.HasKey(e => e.Network_Element_Key);

                entity.Property(e => e.Network_Element_Name).IsRequired().HasMaxLength(200);

                entity.HasOne(e => e.Network_Element_Type)
                    .WithMany(t => t.Network_Elements)
                    .HasForeignKey(e => e.Network_Element_Type_Key)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Parent_Network_Element)
                    .WithMany(p => p.Child_Elements)
                    .HasForeignKey(e => e.Parent_Network_Element_Key)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Child_Elements)
                    .WithOne(c => c.Parent_Network_Element)
                    .HasForeignKey(c => c.Parent_Network_Element_Key)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Network_Element_Hierarchy_Path
            builder.Entity<Network_Element_Hierarchy_Path>(entity =>
            {
                entity.HasKey(e => e.Network_Element_Hierarchy_Path_Key);

                entity.Property(e => e.Netwrok_Element_Hierarchy_Path_Name).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Abbreviation).IsRequired().HasMaxLength(200);

                entity.HasMany(e => e.Network_Element_Types)
                    .WithOne(t => t.Network_Element_Hierarchy_Path)
                    .HasForeignKey(t => t.Network_Element_Hierarchy_Path_Key)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Network_Element_Type
            builder.Entity<Network_Element_Type>(entity =>
            {
                // Define the primary key
                entity.HasKey(e => e.Network_Element_Type_key);

                // Define the property for Network_Element_Type_Name
                entity.Property(e => e.Network_Element_Type_Name)
                    .IsRequired()
                    .HasMaxLength(100);

                // Configure the self-referencing relationship for Parent-Network_Element_Type
                entity.HasOne(e => e.Parent_Network_Element_Type)  // This refers to the parent Network_Element_Type
                    .WithMany(p => p.Child_Types)  // This refers to the children (Child_Types)
                    .HasForeignKey(e => e.Parent_Network_Element_Type_Key)  // Foreign Key in child
                    .IsRequired(false)  // Parent is not mandatory, so child can exist without a parent
                    .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion to prevent cascading delete

                // Configure the Network_Element_Hierarchy_Path relationship
                entity.HasOne(e => e.Network_Element_Hierarchy_Path)  // This refers to the hierarchy path
                    .WithMany(h => h.Network_Element_Types)  // This refers to all the types in the path
                    .HasForeignKey(e => e.Network_Element_Hierarchy_Path_Key)  // Foreign Key
                    .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on path deletion

                // Configure the relationship with Network_Elements
                entity.HasMany(e => e.Network_Elements)  // Network_Element_Type has many Network_Elements
                    .WithOne(n => n.Network_Element_Type)  // Each Network_Element has one Network_Element_Type
                    .HasForeignKey(n => n.Network_Element_Type_Key)  // Foreign Key in Network_Elements
                    .OnDelete(DeleteBehavior.Cascade);  // Cascade delete on Network_Element_Type deletion
            });




            SeedAllModels(builder);
            SeedRoles(builder);
        }



        private static void SeedAllModels(ModelBuilder builder)
        {

            builder.Entity<Governrate>().HasData(
     new Governrate { Governrate_Key = 1, Governrate_Name = "Cairo" },
     new Governrate { Governrate_Key = 2, Governrate_Name = "Alex" },
     new Governrate { Governrate_Key = 3, Governrate_Name = "Giza" },
     new Governrate { Governrate_Key = 4, Governrate_Name = "Suez" }
          );

            builder.Entity<Sector>().HasData(
                new Sector { Sector_Key = 1, Governrate_Key = 1, Sector_Name = "North" },
                new Sector { Sector_Key = 2, Governrate_Key = 1, Sector_Name = "East" },
                new Sector { Sector_Key = 3, Governrate_Key = 1, Sector_Name = "West" },
                new Sector { Sector_Key = 4, Governrate_Key = 1, Sector_Name = "South" }
            );

            builder.Entity<Zone>().HasData(
       new Zone { Zone_Key = 1, Sector_Key = 1, Zone_Name = "منطقه اولى" },
       new Zone { Zone_Key = 2, Sector_Key = 1, Zone_Name = "منطقه ثانيه" },
       new Zone { Zone_Key = 3, Sector_Key = 1, Zone_Name = "منطقه ثالثه" },
       new Zone { Zone_Key = 4, Sector_Key = 1, Zone_Name = "منطقه رابعه" }
   );
            builder.Entity<City>().HasData(
       new City { City_Key = 1, Zone_Key = 1, City_Name = "Nasr City" },
       new City { City_Key = 2, Zone_Key = 1, City_Name = "Al Salam City" },
       new City { City_Key = 3, Zone_Key = 2, City_Name = "Dar Al Salam" },
       new City { City_Key = 4, Zone_Key = 2, City_Name = "Helwan" }
   );

            // Station seeds
            builder.Entity<Station>().HasData(
                new Station { Station_Key = 1, City_Key = 1, Station_Name = "prod-1-1" },
                new Station { Station_Key = 2, City_Key = 1, Station_Name = "prod-1-2" },
                new Station { Station_Key = 3, City_Key = 2, Station_Name = "prod-2-1" },
                new Station { Station_Key = 4, City_Key = 2, Station_Name = "prod-2-2" }
            );

            // Tower seeds
            builder.Entity<Tower>().HasData(
                new Tower { Tower_Key = 1, Station_Key = 1, Tower_Name = "dc-1-1" },
                new Tower { Tower_Key = 2, Station_Key = 1, Tower_Name = "dc-1-2" },
                new Tower { Tower_Key = 3, Station_Key = 2, Tower_Name = "dc-2-1" },
                new Tower { Tower_Key = 4, Station_Key = 2, Tower_Name = "dc-2-2" }
            );

            // Cabin seeds
            builder.Entity<Cabin>().HasData(
                new Cabin { Cabin_Key = 1, Tower_Key = 1, Cabin_Name = "cab-1-1" },
                new Cabin { Cabin_Key = 2, Tower_Key = 1, Cabin_Name = "cab-1-2" },
                new Cabin { Cabin_Key = 3, Tower_Key = 2, Cabin_Name = "cab-2-1" },
                new Cabin { Cabin_Key = 4, Tower_Key = 2, Cabin_Name = "cab-2-2" }
            );

            // Cable seeds
            builder.Entity<Cable>().HasData(
                new Cable { Cable_Key = 1, Cabin_Key = 1, Cable_Name = "ch-1-1" },
                new Cable { Cable_Key = 2, Cabin_Key = 1, Cable_Name = "ch-1-2" },
                new Cable { Cable_Key = 3, Cabin_Key = 2, Cable_Name = "ch-2-1" },
                new Cable { Cable_Key = 4, Cabin_Key = 2, Cable_Name = "ch-2-2" }
            );
            // Block seeds
            builder.Entity<Block>().HasData(
                new Block { Block_Key = 1, Cable_Key = 1, Block_Name = "111-111-111" },
                new Block { Block_Key = 2, Cable_Key = 1, Block_Name = "222-222-222" },
                new Block { Block_Key = 3, Cable_Key = 2, Block_Name = "333-333-333" },
                new Block { Block_Key = 4, Cable_Key = 2, Block_Name = "444-444-444" }
            );

            // Building seeds
            builder.Entity<Building>().HasData(
                new Building { Building_Key = 1, Block_Key = 1, Building_Name = "asd-1-1" },
                new Building { Building_Key = 2, Block_Key = 1, Building_Name = "asd-1-2" },
                new Building { Building_Key = 3, Block_Key = 2, Building_Name = "asd-2-1" },
                new Building { Building_Key = 4, Block_Key = 2, Building_Name = "asd-2-1" }
            );

            // Flat seeds
            builder.Entity<Flat>().HasData(
                new Flat { Flat_Key = 1, Building_Key = 1 },
                new Flat { Flat_Key = 2, Building_Key = 1 },
                new Flat { Flat_Key = 3, Building_Key = 2 },
                new Flat { Flat_Key = 4, Building_Key = 2 }
            );

            // Subscription seeds
            builder.Entity<Subscription>().HasData(
                new Subscription { Subscription_Key = 1, Flat_Key = 1, Building_Key = 1, Meter_Key = 1, Palet_Key = 11 },
                new Subscription { Subscription_Key = 2, Flat_Key = 2, Building_Key = 1, Meter_Key = 1, Palet_Key = 2 },
                new Subscription { Subscription_Key = 3, Flat_Key = 3, Building_Key = 2, Meter_Key = 3, Palet_Key = null },
                new Subscription { Subscription_Key = 4, Flat_Key = 4, Building_Key = 2, Meter_Key = 4, Palet_Key = null }
            );


            // Seed Problem Types
            builder.Entity<ProblemType>().HasData(
                new ProblemType { Problem_Type_Key = 1, Problem_Type_Name = "حريق" },
                new ProblemType { Problem_Type_Key = 2, Problem_Type_Name = "ضغط عالى" },
                new ProblemType { Problem_Type_Key = 3, Problem_Type_Name = "استهلاك عالى" },
                new ProblemType { Problem_Type_Key = 4, Problem_Type_Name = "مديونيه" },
                new ProblemType { Problem_Type_Key = 5, Problem_Type_Name = "تلف عداد" },
                new ProblemType { Problem_Type_Key = 6, Problem_Type_Name = "سرقة تيار" },
                new ProblemType { Problem_Type_Key = 7, Problem_Type_Name = "امطار" },
                new ProblemType { Problem_Type_Key = 8, Problem_Type_Name = "كسر ماسورة مياه" },
                new ProblemType { Problem_Type_Key = 9, Problem_Type_Name = "كسر ماسورة غاز" },
                new ProblemType { Problem_Type_Key = 10, Problem_Type_Name = "تحديث واحلال" },
                new ProblemType { Problem_Type_Key = 11, Problem_Type_Name = "صيانه" },
                new ProblemType { Problem_Type_Key = 12, Problem_Type_Name = "كابل مقطوع" },
                new ProblemType { Problem_Type_Key = 13, Problem_Type_Name = "توصيل كابل" }
            );

            // CuttingDownA Seed
            builder.Entity<CuttingDownA>().HasData(
                new { Cutting_Down_A_Incident_ID = 1, Cutting_Down_Cabin_Name = "cab-1-1", Problem_Type_Key = 1, CreateDate = new DateTime(2020, 1, 1), EndDate = (DateTime?)null, IsPlanned = false, IsGlobal = false, PlannedStartDTS = (DateTime?)null, PlannedEndDTS = (DateTime?)null, IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_A_Incident_ID = 2, Cutting_Down_Cabin_Name = "cab-1-2", Problem_Type_Key = 2, CreateDate = new DateTime(2021, 1, 1), EndDate = (DateTime?)null, IsPlanned = true, IsGlobal = false, PlannedStartDTS = new DateTime(2021, 1, 1), PlannedEndDTS = new DateTime(2021, 6, 30), IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_A_Incident_ID = 3, Cutting_Down_Cabin_Name = "cab-1-3", Problem_Type_Key = 3, CreateDate = new DateTime(2022, 1, 1), EndDate = (DateTime?)null, IsPlanned = false, IsGlobal = true, PlannedStartDTS = (DateTime?)null, PlannedEndDTS = (DateTime?)null, IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_A_Incident_ID = 4, Cutting_Down_Cabin_Name = "cab-1-4", Problem_Type_Key = 4, CreateDate = new DateTime(2019, 1, 1), EndDate = (DateTime?)null, IsPlanned = true, IsGlobal = true, PlannedStartDTS = new DateTime(2019, 1, 1), PlannedEndDTS = new DateTime(2019, 6, 30), IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_A_Incident_ID = 5, Cutting_Down_Cabin_Name = "cab-1-5", Problem_Type_Key = 5, CreateDate = new DateTime(2020, 3, 1), EndDate = new DateTime(2020, 6, 30), IsPlanned = false, IsGlobal = false, PlannedStartDTS = (DateTime?)null, PlannedEndDTS = (DateTime?)null, IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_A_Incident_ID = 6, Cutting_Down_Cabin_Name = "cab-1-6", Problem_Type_Key = 6, CreateDate = new DateTime(2021, 2, 1), EndDate = new DateTime(2021, 10, 30), IsPlanned = true, IsGlobal = true, PlannedStartDTS = new DateTime(2021, 1, 1), PlannedEndDTS = new DateTime(2021, 11, 30), IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null }
            );

            // CuttingDownB Seed
            builder.Entity<CuttingDownB>().HasData(
                new { Cutting_Down_B_Incident_ID = 1, Cutting_Down_Cable_Name = "ch-1-1", Problem_Type_Key = 11, CreateDate = new DateTime(2020, 1, 1), EndDate = (DateTime?)null, IsPlanned = false, IsGlobal = false, PlannedStartDTS = (DateTime?)null, PlannedEndDTS = (DateTime?)null, IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_B_Incident_ID = 2, Cutting_Down_Cable_Name = "ch-1-2", Problem_Type_Key = 12, CreateDate = new DateTime(2021, 1, 1), EndDate = (DateTime?)null, IsPlanned = true, IsGlobal = false, PlannedStartDTS = new DateTime(2021, 1, 1), PlannedEndDTS = new DateTime(2021, 6, 30), IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_B_Incident_ID = 3, Cutting_Down_Cable_Name = "ch-1-3", Problem_Type_Key = 13, CreateDate = new DateTime(2022, 1, 1), EndDate = (DateTime?)null, IsPlanned = false, IsGlobal = true, PlannedStartDTS = (DateTime?)null, PlannedEndDTS = (DateTime?)null, IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_B_Incident_ID = 4, Cutting_Down_Cable_Name = "ch-1-4", Problem_Type_Key = 4, CreateDate = new DateTime(2019, 1, 1), EndDate = (DateTime?)null, IsPlanned = true, IsGlobal = true, PlannedStartDTS = new DateTime(2019, 1, 1), PlannedEndDTS = new DateTime(2019, 6, 30), IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_B_Incident_ID = 5, Cutting_Down_Cable_Name = "ch-1-5", Problem_Type_Key = 5, CreateDate = new DateTime(2020, 3, 1), EndDate = new DateTime(2020, 6, 30), IsPlanned = false, IsGlobal = false, PlannedStartDTS = (DateTime?)null, PlannedEndDTS = (DateTime?)null, IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null },
                new { Cutting_Down_B_Incident_ID = 6, Cutting_Down_Cable_Name = "ch-1-6", Problem_Type_Key = 6, CreateDate = new DateTime(2021, 2, 1), EndDate = new DateTime(2021, 10, 30), IsPlanned = true, IsGlobal = true, PlannedStartDTS = new DateTime(2021, 1, 1), PlannedEndDTS = new DateTime(2021, 11, 30), IsActive = true, CreatedUser = (string?)null, UpdatedUser = (string?)null }
            );
            // fact models seeding can be added here similarly
            // Seed data example for Users
            // Seed Users
            builder.Entity<User>().HasData(
                new User { User_Key = 1, Name = "admin", Password = "admin" },
                new User { User_Key = 2, Name = "test", Password = "test" },
                new User { User_Key = 3, Name = "SourceA", Password = "Source_A" },
                new User { User_Key = 4, Name = "SourceB", Password = "Source_B" }
            );


            // seed chanel
            // Channel
            builder.Entity<Channel>().HasData(
                new Channel
                {
                    Channel_Key = 1,
                    Channel_Name = "Source A"
                },
                new Channel
                {
                    Channel_Key = 2,
                    Channel_Name = "Source B"
                }
            );
            // network elemnt hirera
            builder.Entity<Network_Element_Hierarchy_Path>().HasData(
     new Network_Element_Hierarchy_Path
     {
         Network_Element_Hierarchy_Path_Key = 1,
         Netwrok_Element_Hierarchy_Path_Name = "Governrate, Sector, Zone, City, Station, Tower, Cabin, Cable, Buidling, Flat, Individual Subscription",
         Abbreviation = "Governrate -> Individual Subscription"
     },
     new Network_Element_Hierarchy_Path
     {
         Network_Element_Hierarchy_Path_Key = 2,
         Netwrok_Element_Hierarchy_Path_Name = "Governrate, Sector, Zone, City, Station, Tower, Cabin, Cable, Buidling, Corporate Subscription",
         Abbreviation = "Governrate -> Corporate Subscription"
     }
 );

            //Network_Element_Type
            builder.Entity<Network_Element_Type>().HasData(
    new Network_Element_Type
    {
        Network_Element_Type_key = 1,
        Network_Element_Type_Name = "Governrate",
        Parent_Network_Element_Type_Key = null,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 2,
        Network_Element_Type_Name = "Sector",
        Parent_Network_Element_Type_Key = 1,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 3,
        Network_Element_Type_Name = "Zone",
        Parent_Network_Element_Type_Key = 2,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 4,
        Network_Element_Type_Name = "City",
        Parent_Network_Element_Type_Key = 3,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 5,
        Network_Element_Type_Name = "Station",
        Parent_Network_Element_Type_Key = 4,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 6,
        Network_Element_Type_Name = "Tower",
        Parent_Network_Element_Type_Key = 5,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 7,
        Network_Element_Type_Name = "Cabin",
        Parent_Network_Element_Type_Key = 6,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 8,
        Network_Element_Type_Name = "Cable",
        Parent_Network_Element_Type_Key = 7,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 9,
        Network_Element_Type_Name = "Block",
        Parent_Network_Element_Type_Key = 8,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 10,
        Network_Element_Type_Name = "Building",
        Parent_Network_Element_Type_Key = 9,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 11,
        Network_Element_Type_Name = "Flat",
        Parent_Network_Element_Type_Key = 10,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 12,
        Network_Element_Type_Name = "Individual Subscription",
        Parent_Network_Element_Type_Key = 11,
        Network_Element_Hierarchy_Path_Key = 1
    },
    new Network_Element_Type
    {
        Network_Element_Type_key = 13,
        Network_Element_Type_Name = "Corporate Subscription",
        Parent_Network_Element_Type_Key = 10,
        Network_Element_Hierarchy_Path_Key = 2
    }
);

            //Network_Element
            builder.Entity<Network_Element>().HasData(
    new Network_Element
    {
        Network_Element_Key = 1,
        Network_Element_Name = "gov 1 (cairo for example)",
        Network_Element_Type_Key = 1,
        Parent_Network_Element_Key = null
    },
    new Network_Element
    {
        Network_Element_Key = 2,
        Network_Element_Name = "sec 1 (north)",
        Network_Element_Type_Key = 2,
        Parent_Network_Element_Key = 1
    },
    new Network_Element
    {
        Network_Element_Key = 3,
        Network_Element_Name = "Zone 1 (1st)",
        Network_Element_Type_Key = 3,
        Parent_Network_Element_Key = 2
    },
    new Network_Element
    {
        Network_Element_Key = 4,
        Network_Element_Name = "Cty 1 (Nasr City)",
        Network_Element_Type_Key = 4,
        Parent_Network_Element_Key = 3
    },
    new Network_Element
    {
        Network_Element_Key = 5,
        Network_Element_Name = "Stion 1 (prod-1-1)",
        Network_Element_Type_Key = 5,
        Parent_Network_Element_Key = 4
    },
    new Network_Element
    {
        Network_Element_Key = 6,
        Network_Element_Name = "Toer 1 (dc-1-1)",
        Network_Element_Type_Key = 6,
        Parent_Network_Element_Key = 5
    },
    new Network_Element
    {
        Network_Element_Key = 7,
        Network_Element_Name = "Cbn 1 (cab-1-1)",
        Network_Element_Type_Key = 7,
        Parent_Network_Element_Key = 6
    },
    new Network_Element
    {
        Network_Element_Key = 8,
        Network_Element_Name = "Cbl 1 (ch-1-1)",
        Network_Element_Type_Key = 8,
        Parent_Network_Element_Key = 7
    },
    new Network_Element
    {
        Network_Element_Key = 9,
        Network_Element_Name = "Blk 1 (111-111-111)",
        Network_Element_Type_Key = 9,
        Parent_Network_Element_Key = 8
    },
    new Network_Element
    {
        Network_Element_Key = 10,
        Network_Element_Name = "Blding 1 (asd-1-1)",
        Network_Element_Type_Key = 10,
        Parent_Network_Element_Key = 9
    },
    new Network_Element
    {
        Network_Element_Key = 11,
        Network_Element_Name = "Flt 1 (1)",
        Network_Element_Type_Key = 11,
        Parent_Network_Element_Key = 10
    },
    new Network_Element
    {
        Network_Element_Key = 12,
        Network_Element_Name = "Indv Subs 1 (1)",
        Network_Element_Type_Key = 12,
        Parent_Network_Element_Key = 11
    },
    new Network_Element
    {
        Network_Element_Key = 13,
        Network_Element_Name = "Corp Subs 1 (3)",
        Network_Element_Type_Key = 13,
        Parent_Network_Element_Key = 10
    }
);
            // Cutting_Down_Header
            builder.Entity<Cutting_Down_Header>().HasData(
                new Cutting_Down_Header
                {
                    Cutting_Down_Key = 1,
                    Cutting_Down_Incident_ID = 1,
                    Channel_Key = 1,
                    Cutting_Down_Problem_Type_Key = 1,
                    ActualCreatetDate = new DateTime(2020, 01, 01),
                    SynchCreateDate = new DateTime(2020, 01, 05),
                    SynchUpdateDate = null,
                    ActualEndDate = null,
                    IsPlanned = false,
                    IsGlobal = false,
                    PlannedStartDTS = null,
                    PlannedEndDTS = null,
                    IsActive = true,
                    CreateSystemUserID = 1,
                    UpdateSystemUserID = 1
                },
                new Cutting_Down_Header
                {
                    Cutting_Down_Key = 2,
                    Cutting_Down_Incident_ID = 2,
                    Channel_Key = 2,
                    Cutting_Down_Problem_Type_Key = 2,
                    ActualCreatetDate = new DateTime(2020, 01, 01),
                    SynchCreateDate = new DateTime(2020, 01, 01),
                    SynchUpdateDate = null,
                    ActualEndDate = null,
                    IsPlanned = false,
                    IsGlobal = false,
                    PlannedStartDTS = null,
                    PlannedEndDTS = null,
                    IsActive = true,
                    CreateSystemUserID = 2,
                    UpdateSystemUserID = 2
                },
                // Add the missing records to the Cutting_Down_Header table
                new Cutting_Down_Header
                {
                    Cutting_Down_Key = 3,
                    Cutting_Down_Incident_ID = 123,
                    Channel_Key = 1,
                    Cutting_Down_Problem_Type_Key = 3,
                    ActualCreatetDate = new DateTime(2020, 01, 01),
                    SynchCreateDate = new DateTime(2021, 01, 01),
                    SynchUpdateDate = null,
                    ActualEndDate = null,
                    IsPlanned = false,
                    IsGlobal = false,
                    PlannedStartDTS = null,
                    PlannedEndDTS = null,
                    IsActive = true,
                    CreateSystemUserID = 3,
                    UpdateSystemUserID = 3
                },
                new Cutting_Down_Header
                {
                    Cutting_Down_Key = 4,
                    Cutting_Down_Incident_ID = 321,
                    Channel_Key = 2,
                    Cutting_Down_Problem_Type_Key = 4,
                    ActualCreatetDate = new DateTime(2020, 01, 01),
                    SynchCreateDate = new DateTime(2021, 06, 30),
                    SynchUpdateDate = null,
                    ActualEndDate = null,
                    IsPlanned = false,
                    IsGlobal = false,
                    PlannedStartDTS = null,
                    PlannedEndDTS = null,
                    IsActive = true,
                    CreateSystemUserID = 4,
                    UpdateSystemUserID = 4
                }
            );

            // Cutting_Down_Detail
            builder.Entity<Cutting_Down_Detail>().HasData(
                new Cutting_Down_Detail
                {
                    Cutting_Down_Detail_Key = 11,
                    Cutting_Down_Key = 1, // Consistent with Cutting_Down_Header
                    Network_Element_Key = 7,
                    ActualCreatetDate = new DateTime(2020, 01, 01),
                    ActualEndDate = null,
                    ImpactedCustomers = 100
                },
                new Cutting_Down_Detail
                {
                    Cutting_Down_Detail_Key = 12,
                    Cutting_Down_Key = 1, // Consistent with Cutting_Down_Header
                    Network_Element_Key = 8,
                    ActualCreatetDate = new DateTime(2020, 01, 01),
                    ActualEndDate = null,
                    ImpactedCustomers = 50
                }
            );

            // Cutting_Down_Ignored
            builder.Entity<Cutting_Down_Ignored>().HasData(
                new Cutting_Down_Ignored
                {
                    Cutting_Down_Incident_ID = 1, // Matches the Cutting_Down_Incident_ID from Cutting_Down_Header
                    ActualCreatetDate = new DateTime(2020, 01, 01),
                    SynchCreateDate = new DateTime(2021, 01, 01),
                    Cabel_Name = "147",
                    Cabin_Name = "963",
                    CreatedUser = "admin"
                },
                new Cutting_Down_Ignored
                {
                    Cutting_Down_Incident_ID = 2, // Matches the Cutting_Down_Incident_ID from Cutting_Down_Header
                    ActualCreatetDate = new DateTime(2020, 01, 01),
                    SynchCreateDate = new DateTime(2021, 06, 30),
                    Cabel_Name = "",
                    Cabin_Name = "963",
                    CreatedUser = "admin"
                }
            );











        }


        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = SD.Role_Admin, ConcurrencyStamp = "1", NormalizedName = SD.Role_Admin },
                new IdentityRole() { Name = SD.Role_User, ConcurrencyStamp = "2", NormalizedName = SD.Role_User }
                );
        }
    }
}
