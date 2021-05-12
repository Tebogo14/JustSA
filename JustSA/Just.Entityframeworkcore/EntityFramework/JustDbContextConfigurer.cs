using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Just.Entityframeworkcore.EntityFramework
{
    public static  class JustDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JustDbContext> builder , string connectionString)
        {
            builder.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }
    }
}
