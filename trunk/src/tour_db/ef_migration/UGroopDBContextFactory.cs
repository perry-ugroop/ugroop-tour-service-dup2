using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace UGroopData.Sql.Repository2.Data
{
    public class UGroopDBContextFactory: IDbContextFactory<UGroopDBContext>
    {
        public UGroopDBContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<UGroopDBContext>();
            builder.UseSqlServer(@"Server=.; Database=UGroopDB2; User Id=sa; Password=Password1*");
            return new UGroopDBContext(builder.Options);            
        }
    }   
}
