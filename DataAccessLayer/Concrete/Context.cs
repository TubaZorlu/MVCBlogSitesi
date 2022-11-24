using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {

        public Context(): base("Server=DESKTOP-CJELTSN\\MSSQLSERVER2019;Database=DbMvcProjeKampi;Uid=sa;Pwd=1234")
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Meassage> Meassages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Heading>().HasRequired(x=>x.Category).WithMany(x=>x.Headings).HasForeignKey(x => x.CategoryID);
            modelBuilder.Entity<Heading>().HasRequired(x=>x.Writer).WithMany(x=>x.Headings).HasForeignKey(x => x.WriterID);

            modelBuilder.Entity<Content>().HasRequired(x=>x.Heading).WithMany(x=>x.Contents).HasForeignKey(x => x.HeadingID);
   

        }

    }
}
