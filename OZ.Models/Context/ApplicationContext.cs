using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZ.Models.Context
{
    public class ApplicationContext : DbContext
    {
        private IDbContextTransaction dbContextTransaction;

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Addict> Addicts { get; set; }
        public DbSet<Drugs> Drugss { get; set; }
        public DbSet<Relations> Relations { get; set; }
        public DbSet<Classify> Classifys { get; set; }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<AddictDrugs> AddictDrugss { get; set; }
        public DbSet<AddictRelations> AddictRelations { get; set; }
        public DbSet<AddictManagePlace> AddictManagePlaces { get; set; }
        public DbSet<AddictVehicle> AddictVehicle { get; set; }
        public DbSet<AddictClassify> AddictClassifys { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ManagePlace> ManagePlaces { get; set; }
        public DbSet<ManageCity> ManageCity { get; set; }
        public DbSet<ManageCityType> ManageCityType { get; set; }
        public DbSet<ManageType> ManageTypes { get; set; }
        public DbSet<PlaceType> PlaceTypes { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Ethic> Ethic { get; set; }
        public DbSet<Religion> Religion { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<WorkStatus> WorkStatus { get; set; }
        public DbSet<Marriage> Marriage { get; set; }
        public DbSet<Uses> Usess { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbQuery<Dash01> Dash01s { get; set; }
        public DbQuery<Dash02> Dash02s { get; set; }
        public DbQuery<Dash03> Dash03s { get; set; }
        public DbQuery<Dash04> Dash04s { get; set; }
        public DbQuery<Dash05> Dash05s { get; set; }
        public DbQuery<DashClassify> DashClassifys { get; set; }
        public DbQuery<DashAddictType> DashAddictTypes { get; set; }
        public DbQuery<FaceList> FaceLists { get; set; }
        public new void SaveChanges()
        {
            base.SaveChanges();
        }
        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        public void BeginTransaction()
        {
            dbContextTransaction = Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Commit();
            }
        }
        public void RollbackTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Rollback();
            }
        }
        public void DisposeTransaction()
        {
            if (dbContextTransaction != null)
            {
                dbContextTransaction.Dispose();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.Entity<Drugs>().ToTable("Drugs");
            builder.Entity<Classify>().ToTable("Classify");
            builder.Entity<Addict>().ToTable("Addict");
            builder.Entity<User>().ToTable("AppUser");
            //builder.Entity<User>().HasKey(p => p.Oid);

            builder.Entity<AddictDrugs>().ToTable("AddictDrugs");
            builder.Entity<AddictClassify>().ToTable("AddictClassify");
            builder.Entity<AddictManagePlace>().ToTable("AddictManagePlace");
            builder.Entity<AddictVehicle>().ToTable("AddictVehicle");

            builder.Entity<EducationLevel>().ToTable("EducationLevel");
            builder.Entity<Gender>().ToTable("Gender");
            builder.Entity<ManagePlace>().ToTable("ManagePlace");
            builder.Entity<ManageType>().ToTable("ManageType");
            builder.Entity<PlaceType>().ToTable("PlaceType");
            builder.Entity<Province>().ToTable("Province");
            builder.Entity<Uses>().ToTable("Uses");
            builder.Entity<Ward>().ToTable("Ward");

            builder.Entity<FaceList>().ToTable("FaceList");
        }
    }
}
