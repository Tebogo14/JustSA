using Just.Entityframeworkcore.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Just.Entityframeworkcore.EntityFramework
{
    public class JustDbContextFactory : IDesignTimeDbContextFactory<JustDbContext>
    {

        public JustDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JustDbContext>();

            var configuration = AppConfgurations.Get(Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("\\") + 1));

            JustDbContextConfigurer.Configure(builder, configuration.GetConnectionString(JustConst.ConnectionStringName));

            return new JustDbContext(builder.Options);
        }
    }
}
