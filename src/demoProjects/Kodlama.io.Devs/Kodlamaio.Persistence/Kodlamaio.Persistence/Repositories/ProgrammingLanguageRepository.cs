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
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
