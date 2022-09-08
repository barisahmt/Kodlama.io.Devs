using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Kodlamaio.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlamaio.Persistence.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
