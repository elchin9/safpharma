using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAF.DAL
{
    public class Db_Saf : IdentityDbContext<AppUser>
    {
        public Db_Saf(DbContextOptions<Db_Saf> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<SendSms> Messages { get; set; }
    }
}
