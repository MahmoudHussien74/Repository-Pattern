using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Pattern.Core.Models;

namespace Repository_Pattern.EF
{
    public class ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):DbContext(options)
    {
        public DbSet<Book> Books {  get; set; }
        public DbSet<Author> Authors {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
