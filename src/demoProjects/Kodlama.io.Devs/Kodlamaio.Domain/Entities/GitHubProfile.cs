using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GitHubProfile : Entity
    {
        public int DevelopmenId { get; set; }
        public string Name { get; set; }
        public string ProfileUrl { get; set; }
        public virtual Developer Developer { get; set; }

        public GitHubProfile()
        {
        }

        public GitHubProfile(int developmenId, string name, string profileUrl)
        {
            DevelopmenId = developmenId;
            Name = name;
            ProfileUrl = profileUrl;
        }
    }
}
