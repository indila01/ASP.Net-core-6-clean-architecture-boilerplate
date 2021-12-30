using Boilerplate.Common.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Common.Repository
{
    public interface IUserRepository
    {
        public DbSet<User> Users { get; set; }
    }
}
