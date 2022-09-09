using Application.Features.Developers.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Models
{
    public class DevelopersListModel : BasePageableModel
    {
        public IList<DeveloperListDto> Items { get; set; }
    }
}
