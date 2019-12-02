using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBStuff
{
    public interface IMyContext
    {

    }
    public class MyContext : DbContext, IMyContext
    {
        public MyContext(DbContextOptions<MyContext> options)
          : base(options)
        {
        }
    }
}
